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
    public class StreamComparer : IEqualityComparer<Stream>
    {
        public bool Equals(Stream x, Stream y)
        {
            // check for null values
            if (x == null || y == null)
                return false;

            // check if the two Stream objects are the same reference
            if (ReferenceEquals(x, y))
                return true;

            // compare the Url of the two Stream objects
            // to determine if they're the same
            return x.Url == y.Url;
        }
        public int GetHashCode(Stream obj)
        {
            if (obj == null || obj.Url == null)
                return 0;

            return obj.Url.GetHashCode();
        }
    }
    public class Stream : ListBoxItem, INotifyPropertyChanged
    {
        public enum OnlineStatus
        {
            Online,
            Offline,
            Unknown
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public int Index 
        { 
            get
            {
                M3U8.Group group = Parent.FindGroup(_group);
                return group.Streams.IndexOf(this);
            }
        }
        public int Id { get { return _id; } set {if (_id != value) {_id = value;} } }
        public string Name { get { return _name; } set {
                if (_name != value)
                {
                    _name = value;
                    Title = value;
                    OnPropertyChanged("Name");
                }
            } 
        }
        public string Group { get { return _group; } set { _group = value; OnPropertyChanged("Group"); } }
        public string Logo { get { return _logo; } set { _logo = value; OnPropertyChanged("Logo"); } }
        public string Url { get { return _url; } set { _url = value; Description = value; OnPropertyChanged("Url"); } }
        public string Duration { get { return _duration; } set { _duration = value; OnPropertyChanged("Duration"); } }
        public string TvgName { get => _tvgName; set { _tvgName = value; OnPropertyChanged("TvgName"); } }
        public string TvgId { get { return _tvgId; } set { _tvgId = value; OnPropertyChanged("TvgId"); } }
        public bool Export {  get { return _export; } set {  _export = value; OnPropertyChanged("Export"); } }
        public bool Favorite { get { return _favorite; } set { _favorite = value; OnPropertyChanged("Favorite"); } }
        public OnlineStatus Status { get => _status; set { _status = value; OnPropertyChanged(nameof(Status)); } }
        public string LastChecked { get => _lastChecked; set { _lastChecked = value; OnPropertyChanged(nameof(LastChecked)); } }

        private int _id;
        private string _name, _group, _logo, _url, _duration, _tvgId, _tvgName, _lastChecked;
        private bool _export, _favorite;
        private OnlineStatus _status;

        public Playlist Parent;

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

            // colors
            ColorDescription = Color.LightGray;
        }
        public override string ToString()
        {
            return _name;
        }
        public string ToExtInf(bool removeCountryTag = false)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(@"#EXTINF:{0}", _duration);

            if (_tvgId?.Length > 0)
                sb.AppendFormat(@" tvg-id=""{0}""", _tvgId);

            if (_tvgName?.Length > 0)
                sb.AppendFormat(@" tvg-name=""{0}""", _tvgName);

            if (_group?.Length > 0)
            {
                string tmpGroup = _group;

                if (removeCountryTag)
                    tmpGroup = tmpGroup.Replace("[DE]", "").Trim();
                
                sb.AppendFormat(@" group-title=""{0}""", tmpGroup);
            }

            if (_logo?.Length > 0)
                sb.AppendFormat(@" tvg-logo=""{0}""", _logo);
            
            if (_name?.Length > 0)
            {
                sb.AppendFormat(@",{0}", _name);
                sb.AppendLine();
            }

            if (_url?.Length > 0)
                sb.Append(_url);
            
            return sb.ToString();
        }
        public string ToExtInfFavorite(bool removeCountryTag = false)
        {
            string originalGroup = _group;
            _group = "Favorites";

            string favoriteExtInf = ToExtInf(removeCountryTag);
            _group = originalGroup;
            return favoriteExtInf;
        }

        public void Rename(string name)
        {
            Name = name;
        }

        public static Stream Clone(Stream stream)
        {
            Stream clone = new Stream();

            clone.Id = stream.Id;
            clone.Name = stream.Name;
            clone.Group = stream.Group;
            clone.Logo = stream.Logo;
            clone.Url = stream.Url;
            clone.Duration = stream.Duration;
            clone.TvgId = stream.TvgId;
            clone.Export = stream.Export;
            clone.Favorite = stream.Favorite;
            clone.Status = stream.Status;
            clone.LastChecked = stream.LastChecked;

            clone.Parent = stream.Parent;

            return clone;
        }
        public static List<object> DeepClone(Stream original)
        {
            List<object> result = new List<object>
            {
                original.Index,
                original
            };

            return result;
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
            writer.Write(_status.ToString());
            writer.Write(_lastChecked);
            if (_tvgId != null) { writer.Write(_tvgId); } else { writer.Write(""); }
            writer.Write(_favorite);
            if (_tvgName != null) { writer.Write(_tvgName); } else { writer.Write(""); }

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
