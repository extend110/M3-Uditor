using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace M3U8
{
    [Serializable]
    public class PlaylistCredentials
    {
        public string ServerUri { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public PlaylistCredentials()
        {
            ServerUri = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
            Port = 80;
        }
    }
}
