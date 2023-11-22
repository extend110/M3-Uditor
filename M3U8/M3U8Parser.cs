using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace M3U8
{
    public class M3U8Parser
    {
        public static event ProgressChangedEventHandler LoadingProgressChanged;

        internal static void OnLoadingProgressChanged(int progressPercent)
        {
            var _handler = LoadingProgressChanged;
            if (_handler != null)
            {
                ProgressChangedEventArgs args = new ProgressChangedEventArgs(progressPercent, null);
                Helper.AutoInvoke(_handler, new object[] {null, args});
            }
        }

        public static bool AbortLoading = false;

        public static Playlist LoadFromFile(string path)
        {
            AbortLoading = false;
            StreamReader reader = new StreamReader(path);

            //Check for #EXTM3U
            if (!reader.ReadLine().StartsWith(Helper.EXTM3U))
            {
                reader.Close();
                return null;
            }

            long fileLength = reader.BaseStream.Length;
            int step = 0;

            Playlist _playlist = new Playlist();

            while ( !reader.EndOfStream && !AbortLoading )
            {
                Stream _stream = new Stream();

                string _data = reader.ReadLine();
                // check if _data is empty
                if (_data.Length == 0)
                    continue;

                // check if _data is #EXTINF. continue when true, read next line if false
                if ( _data.StartsWith(Helper.EXTINF) == false)
                {
                    _playlist.AdditionalExt.Add(_data);
                    continue;
                }

                // all ok, resume loading

                string _url = reader.ReadLine();
                if (_url == null) _url = string.Empty;

                string duration = "-1";
                try
                {
                    duration = _data.Substring("#EXTINF:".Length, _data.IndexOf(" ") - "#EXTINF:".Length);
                    for (int i = 0; i < duration.Length; i++)
                    {
                        if (char.IsLetter(duration[i]))
                        {
                            duration = duration.Substring(0, i - 1);
                            break;
                        }
                    }
                }
                catch { }
                

                Match nameMatch = Regex.Match(_data, "tvg-name=\"(.*?)\"");
                if ( nameMatch.Success )
                {
                    _stream.Name = nameMatch.Groups[1].Value;
                } else
                {
                    _stream.Name = _data.Substring(_data.IndexOf(",") + 1, _data.Length - _data.IndexOf(",") - 1);
                }

                Match groupMatch = Regex.Match(_data, "group-title=\"(.*?)\"");
                _stream.Group = "Default";
                if (groupMatch.Success)
                {
                    _stream.Group = groupMatch.Groups[1].Value;
                }

                Match logoMatch = Regex.Match(_data, "tvg-logo=\"(.*?)\"");
                if (logoMatch.Success)
                {
                    _stream.Logo = logoMatch.Groups[1].Value;
                }

                Match tvgIdMatch = Regex.Match(_data, "tvg-id=\"(.*?)\"");
                if (tvgIdMatch.Success)
                {
                    _stream.TvgId = groupMatch.Groups[1].Value;
                }

                _stream.Duration = duration;
                _stream.Url = _url;

                _playlist.Add(_stream);

                step = (int)((double)reader.BaseStream.Position / fileLength * 100);
                OnLoadingProgressChanged(step);
            }

            if (AbortLoading)
            {
                Console.WriteLine("Import aborted");
                return null;
            }
            else
            {
                Console.WriteLine("Loaded {0} streams", _playlist.CountStreams.ToString());
                _playlist.IsM3U = true;
                _playlist.Filename = path;
                reader.Close();
                return _playlist;
            }
        }
    }
}
