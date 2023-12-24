using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace M3U8
{
    public static class Helper
    {
        public const string EXTINF = "#EXTINF"; // track information
        public const string EXTENC = "#EXTENC"; // encoding, must be second line
        public const string EXTM3U = "#EXTM3U"; // file header, must be first line
        public const string PLAYLIST = "#PLAYLIST"; // playlist title
        public const string EXTGRP = "#EXTGRP"; // group naming
        public const string EXTBYT = "#EXTBYT"; // file size
        public const string EXTBIN = "#EXTBIN"; // binary data
        public const string EXTIMG = "#EXTIMG"; // image data

        public const string MpegUrl = "application/x-mpegURL";
        public const string Mpeg2Url = "application/x-mpegurl";
        public const string Video = "video/mp2t";
        public const string AppleMpeg = "application/vnd.apple.mpegurl";
        public const string OctetStream = "application/octet-stream";

        public const string PanelAPI = "player_api.php?username={0}&password={1}";

        static MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();

        public static string CreateMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToBase64String(hashBytes);
            }
        }
        public static void AutoInvoke(Delegate theEvent, object[] args)
        {
            foreach (Delegate d in theEvent.GetInvocationList())
            {
                if (d.Target is ISynchronizeInvoke syncer && syncer.InvokeRequired)
                {
                    syncer.BeginInvoke(d, args);
                }
                else
                {
                    d.DynamicInvoke(args);
                }
            }
        }
        public static bool IsValidURL(this string URL)
        {
            string Pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            Regex Rgx = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return Rgx.IsMatch(URL);
        }
    }
}
