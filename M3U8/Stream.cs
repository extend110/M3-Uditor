using M3Controls;
using M3U8.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static M3U8.Stream;

namespace M3U8
{
    public class Stream : ListBoxItem, INotifyPropertyChanged
    {
        public enum OnlineStatus
        {
            Online,
            Offline,
            Unknown
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public int Id { 
            get { return _id; } 
            set 
            {
                if (_id != value)
                {
                    _id = value;
                }
            } 
        }
        public string Name 
        { 
            get { return _name; } 
            set 
            {
                if (_name != value)
                {
                    _name = value;
                    Title = value;
                    OnPropertyChanged("Name");
                }
            } 
        }
        public string Group { get { return _group; } set { _group = value; } }
        public string Logo { get { return _logo; } set { _logo = value; } }
        public string Url 
        { 
            get { return _url; } 
            set 
            { 
                _url = value; 
                Description = value; 
                OnPropertyChanged("Url");
            } 
        }
        public string Duration { get { return _duration; } set { _duration = value; } }
        public string TvgId
        {
            get { return _tvgId; }
            set
            {
                _tvgId = value;
                OnPropertyChanged("TvgId");
            }
        }
        public bool Export { 
            get 
            { 
                return _export; 
            } 
            set 
            { 
                _export = value; 
                OnPropertyChanged("Export"); 
            } 
        }
        public OnlineStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        public string LastChecked
        {
            get => _lastChecked;
            set
            {
                _lastChecked = value;
                OnPropertyChanged(nameof(LastChecked));
            }
        }

        int _id;
        string _name, _group, _logo, _url, _duration, _tvgId, _lastChecked;
        bool _export;
        OnlineStatus _status;

        public Stream()
        {
            Export = true;
            Status = OnlineStatus.Unknown;

            _id = Playlist.R.Next(int.MaxValue);
            _name = string.Empty;
            _group = string.Empty;
            _logo = string.Empty;
            _url = string.Empty;
            _duration = "-1";
            _tvgId = string.Empty;
            _lastChecked = "never";
        }

        public override string ToString()
        {
            return _name;
        }

        public string ToExtInf()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(@"#EXTINF:{0}", _duration);

            if (_tvgId.Length > 0)
                sb.AppendFormat(@" tvg-id=""{0}""", _tvgId);

            if ( _group.Length > 0 )
                sb.AppendFormat(@" group-title=""{0}""", _group);

            if (_logo.Length > 0)
                sb.AppendFormat(@" tvg-logo=""{0}""", _logo);
            
            if (_name.Length > 0)
            {
                sb.AppendFormat(@",{0}", _name);
                sb.AppendLine();
            }

            if (_url.Length > 0)
                sb.Append(_url);
            
            return sb.ToString();
        }

        public void Rename(string name)
        {
            Name = name;
        }

        internal void SaveBinary(BinaryWriter writer)
        {
            writer.Write("STREAMELEMENT");
            writer.Write(_name);
            writer.Write(_group);

            if (_logo != null) { writer.Write(_logo); } else { writer.Write(""); }
            writer.Write(_url);
            writer.Write(_duration);
            writer.Write(_export);
            writer.Write(_status.ToString()); //V2
            writer.Write(_lastChecked); //V2
            writer.Write(_tvgId); //V3
        }

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
