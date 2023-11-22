using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3U8
{
    public static class Helper
    {
        public const string EXTINF = "#EXTINF"; // track information
        public const string EXTENC = "#EXTENC"; // encoding, must be second line
        public const string EXTM3U = "#EXTM3U"; // file header, must be first line
        public const string PLAYLIST = "#PLAYLIST"; // playlist title
        public const string EXTGRP = "#EXTENC"; // group naming
        public const string EXTART = "#EXTART"; // artist
        public const string EXTALB = "#EXTALB"; // album information
        public const string EXTGENRE = "#EXTGENRE"; // album genre
        public const string EXTBYT = "#EXTBYT"; // file size
        public const string EXTBIN = "#EXTBIN"; // binary data
        public const string EXTIMG = "#EXTIMG"; // image data

        public const string MpegUrl = "application/x-mpegURL";
        public const string Mpeg2Url = "application/x-mpegurl";
        public const string Video = "video/mp2t";
        public const string AppleMpeg = "application/vnd.apple.mpegurl";
        public const string OctetStream = "application/octet-stream";

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
    }
}
