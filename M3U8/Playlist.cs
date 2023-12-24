using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M3U8
{

    public class Playlist : INotifyPropertyChanged
    {
        public PlaylistCredentials Credentials;
        public string XmlTvUrl { get; set; }
        public bool IsM3U {  get; set; }
        public bool HasFilename { get { return Filename.Length > 0; } }
        public bool HasChanges = false;
        public string Filename = string.Empty;
        public int CountStreams
        {
            get
            {
                int _count = 0;
                foreach (Group group in _groups)
                {
                    _count += group.Streams.Count;
                }
                return _count;
            }
        }
        public int CountGroups
        {
            get
            {
                return _groups.Count;
            }
        }
        public BindingList<Group> Groups
        {
            get
            {
                return _groups;
            }
        }
        public List<Stream> Streams
        {
            get
            {
                List<Stream> InternalList = new List<Stream>();
                foreach (Group group in _groups)
                {
                    InternalList.AddRange(group.Streams.ToArray());
                }
                return InternalList;
            }
        }
        public bool AbortLoading { get; set; }
        public List<string> AdditionalExt 
        { 
            get => _additionalExt;
        }
        public List<int> Favorites { get; set; }

        internal List<string> _additionalExt;
        internal BindingList<Group> _groups;
        internal static Random R = new Random();

        public event ProgressChangedEventHandler ProgressChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        //Initialize
        public Playlist(bool createDefault = true) 
        {
            Credentials = new PlaylistCredentials();
            Filename = string.Empty;
            HasChanges = false;
            IsM3U = false;
            XmlTvUrl = string.Empty;

            Favorites = new List<int>();
            _additionalExt = new List<string>();
            _groups = new BindingList<Group>();

            if (createDefault)
                _groups.Add(new Group(this));
        }

        public void InsertStream(Stream stream, int indexInGroup)
        {
            Group g = FindGroup(stream.Group);

            if (g != null)
            {
                stream.Parent = this;
                g.Streams.Insert(indexInGroup, stream);
            }
            else
            {
                _groups.Add(new Group(stream.Group, this));
                InsertStream(stream, indexInGroup);
            }
        }
        public void Add(Stream stream)
        {
            Group g = FindGroup(stream.Group);

            if ( g != null)
            {
                stream.Parent = this;
                g.Streams.Add(stream);
            } else
            {
                _groups.Add(new Group(stream.Group, this));
                Add(stream);
            }
        }
        public Stream FindStreamById(int id)
        {
            foreach (Group group in _groups)
            {
                foreach (Stream item in group.Streams)
                {
                    if (item.Id == id) return item;
                }
                //return group.Streams.Where(stream => stream.Id == id).FirstOrDefault();
            }
            return null;
        }

        //Group Operations
        #region "Groups"
        public void ShowAllGroups()
        {
            foreach (Group g in _groups)
                g.Export = true;

            HasChanges = true;
        }
        public void HideAllGroups()
        {
            foreach (Group g in _groups)
                g.Export = false;

            HasChanges = true;
        }
        public int FindGroupIndex(string group)
        {
            for (int i = 0; i < _groups.Count; i++)
            {
                if (_groups[i].Name == group)
                {
                    return i;
                }
            }
            return -1;
        }
        public Group FindGroup(string group)
        {
            for (int i = 0; i < _groups.Count; i++)
            {
                if (_groups[i].Name == group)
                {
                    return _groups[i];
                }
            }
            return null;
        }
        public bool ContainsGroup(string groupName)
        {
            for (int i = 0; i < _groups.Count; i++)
            {
                if (_groups[i].Name == groupName)
                {
                    return true;
                }
            }
            return false;
        }
        public bool AddGroup(string group)
        {
            return AddGroup(new Group(group, this));
        }
        public bool AddGroup(Group group)
        {
            if (!ContainsGroup(group.Name))
            {
                _groups.Add(group);
                return true;
            }
            return false;
        }
        public bool TryCreateGroup(string groupname)
        {
            return AddGroup(new Group(groupname, this));
        }
        public void RemoveGroup(Group group)
        {
            _groups.Remove(group);
        }
        public void RenameGroup(string oldGroup, string newGroup)
        {
            if ( ContainsGroup(newGroup) )
                return;

            BindingList<Stream> streams = FindGroup(oldGroup).Streams;
            int oldIndex = FindGroupIndex(oldGroup);

            foreach ( Stream stream in streams)
            {
                stream.Group = newGroup;
            }
            _groups.Remove(FindGroup(oldGroup));
            _groups.Insert(oldIndex, new Group(newGroup, streams, this));
            OnPropertyChanged("Groups");
        }
        public void GroupReplaceString(string pattern, string  replacement)
        {
            foreach (Group group in _groups)
            {
                if (group.Name.Contains(pattern))
                {
                    group.Name = group.Name.Replace(pattern, replacement);
                    HasChanges = true;
                }
            }
        }
        public void MoveGroup(Group group, int v)
        {
            _groups.Remove(group);
            _groups.Insert(v, group);
        }
        #endregion

        //IO Operations
        #region "Loading/Saving"
        public void Save(string filename)
        {
            FileStream fileStream = new FileStream(filename, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(fileStream, Encoding.UTF8);
            
            // write file header
            writer.Write("M3-Uditor");

            // write program version
            writer.Write("V2");

            // write playlist
            writer.Write("PLAYLIST");
            writer.Write(this.XmlTvUrl);

            // write additional data
            if (_additionalExt.Count > 0)
            {
                foreach (var ext in _additionalExt)
                {
                    writer.Write("ADD-DATA");
                    writer.Write(ext);
                }
            }

            // write credentials
            writer.Write("CREDENTIALS");
            writer.Write(Credentials.ServerUri);
            writer.Write(Credentials.Port);
            writer.Write(Credentials.Username);
            writer.Write(Credentials.Password);

            // write groups and streams
            foreach (Group group in _groups)
            {
                group.SaveBinary(writer);
                foreach (Stream stream in group.Streams)
                {
                    stream.SaveBinary(writer);
                }
            }

            writer.Flush();
            writer.Close();
            fileStream.Close();

            IsM3U = false;
            HasChanges = false;
            Filename = filename;
        }
        public void Load(string filename)
        {
            if ( !File.Exists(filename))
            {
                MessageBox.Show("File not found!", "M3-Uditor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (FileStream fileStream = new FileStream(filename, FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(fileStream, Encoding.UTF8))
                {
                    if (reader.BaseStream.Length == 0)
                    {
                        MessageBox.Show("Corrupt File!", "M3-Uditor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string fileVersion = reader.ReadString();
                    long fileLength = fileStream.Length;
                    int step = 0;

                    if (fileVersion != "M3-Uditor")
                    {
                        MessageBox.Show("Wrong fileformat!", "M3-Uditor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int programVersion = int.Parse(reader.ReadString().Replace("V", string.Empty));

                    _groups.Clear();
                    while (reader.BaseStream.Position != reader.BaseStream.Length && !AbortLoading)
                    {
                        switch (reader.ReadString())
                        {
                            case "PLAYLIST":
                                this.XmlTvUrl = reader.ReadString();
                                break;
                            case "ADD-DATA":
                                string _data = reader.ReadString();
                                _additionalExt.Add(_data);
                                break;
                            case "GROUPELEMENT":
                                Group group = new Group(this);
                                group.Name = reader.ReadString();
                                group.Export = reader.ReadBoolean();
                                AddGroup(group);
                                break;
                            case "STREAMELEMENT":
                                Stream stream = new Stream();
                                stream.Name = reader.ReadString();
                                stream.Group = reader.ReadString();
                                stream.Logo = reader.ReadString();
                                stream.Url = reader.ReadString();
                                stream.Duration = reader.ReadString();
                                stream.Export = reader.ReadBoolean();
                                stream.Status = (Stream.OnlineStatus)Enum.Parse(typeof(Stream.OnlineStatus), reader.ReadString());
                                stream.LastChecked = reader.ReadString();
                                stream.TvgId = reader.ReadString();
                                stream.Favorite = reader.ReadBoolean();
                                if (programVersion > 1) stream.TvgName = reader.ReadString();

                                if (stream.Status == Stream.OnlineStatus.Online)
                                    stream.ColorDescription = Color.MediumSeaGreen;
                                if (stream.Status == Stream.OnlineStatus.Offline)
                                    stream.ColorDescription = Color.IndianRed;

                                if (stream.Favorite) Favorites.Add(stream.Id);

                                Add(stream);
                                break;
                            case "CREDENTIALS":
                                Credentials = new PlaylistCredentials();
                                Credentials.ServerUri = reader.ReadString();
                                Credentials.Port = reader.ReadInt32();
                                Credentials.Username = reader.ReadString();
                                Credentials.Password = reader.ReadString();
                                break;
                            default:
                                break;
                        }
                        step = (int)((double)reader.BaseStream.Position / fileLength * 100);
                        OnProgressChanged(this, step);
                    }

                    if (AbortLoading)
                    {
                        Clear();
                        Credentials = new PlaylistCredentials();
                        Filename = string.Empty;
                        HasChanges = false;
                        IsM3U = false;
                        XmlTvUrl = string.Empty;

                        Favorites = new List<int>();
                        _additionalExt = new List<string>();

                        _groups = new BindingList<Group>();
                        _groups.Add(new Group(this));
                    }
                    else
                    {
                        Filename = fileStream.Name;
                        Console.WriteLine("Loaded {0} streams, {1} groups", CountStreams.ToString(), CountGroups.ToString());
                    }
                }
            }
        }
        public void Export(string filename, bool removeCountryTag = false, Group[] OnlySelected = null)
        {
            Group[] _export = OnlySelected ?? _groups.ToArray();

            using (StreamWriter streamWriter = new StreamWriter(filename, false))
            {
                // write header
                streamWriter.Write("#EXTM3U");

                // write xml tv?
                if (this.XmlTvUrl?.Length > 0)
                {
                    //streamWriter.Write(string.Format(@" url-tvg=""{0}""", this.XmlTvUrl));
                    //streamWriter.Write(string.Format(@" tvg-url=""{0}""", this.XmlTvUrl));
                    streamWriter.Write(string.Format(@" x-tvg-url=""{0}""", this.XmlTvUrl));
                }

                // write line
                streamWriter.Write("\n");

                // write additional m3u data
                if ( _additionalExt.Count > 0 )
                {
                    foreach ( var ext in _additionalExt )
                    {
                        streamWriter.Write(ext + "\n");
                    }
                }

                // write groups and streams
                foreach (Group group in _export)
                {
                    if (group.Export)
                    {
                        foreach (Stream stream in group.Streams)
                        {
                            if (stream.Export)
                                streamWriter.Write(stream.ToExtInf(removeCountryTag) + "\n");
                            //if (stream.Favorite)
                            //    streamWriter.Write(stream.ToExtInfFavorite(removeCountryTag) + "\n");
                        }
                    }
                }
            }
        }
        #endregion
       
        public void Clear()
        {
            _groups.Clear();
        }
        
        private void OnPropertyChanged(string v)
        {
            var handler = PropertyChanged;
            if ( handler != null )
            {
                handler(this, new PropertyChangedEventArgs(v));
            }
        }
        private void OnProgressChanged(object sender, int progress)
        {
            var handler = ProgressChanged;
            if ( handler != null )
            {
                ProgressChangedEventArgs args = new ProgressChangedEventArgs(progress, null);
                Helper.AutoInvoke(handler, new object[] { this, args });
            }
        }
    }
}
