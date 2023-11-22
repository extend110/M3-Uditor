using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public bool AbortLoading { get; set; }
        public List<string> AdditionalExt 
        { 
            get => _additionalExt;
        }

        internal List<string> _additionalExt;
        internal BindingList<Group> _groups;
        internal static Random R = new Random();

        public event ProgressChangedEventHandler ProgressChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        //Initialize
        public Playlist() 
        {
            Filename = string.Empty;
            HasChanges = false;
            IsM3U = false;

            _additionalExt = new List<string>();
            _groups = new BindingList<Group>
            {
                new Group(this)
            };
        }

        internal void Add(Stream stream)
        {
            Group g = FindGroup(stream.Group);

            if ( g != null)
            {
                g.Streams.Add(stream);
            } else
            {
                _groups.Add(new Group(stream.Group, this));
                Add(stream);
            }
        }

        //Group Operations
        #region "Groups"
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
                HasChanges = true;
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
            HasChanges = true;
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
        #endregion

        //IO Operations
        #region "Loading/Saving"
        public void Save(string filename)
        {
            FileStream fileStream = new FileStream(filename, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(fileStream, Encoding.UTF8);

            // write file header
            writer.Write("M3-Uditor");

            // write additional data
            if (_additionalExt.Count > 0)
            {
                foreach (var ext in _additionalExt)
                {
                    writer.Write("ADD-DATA");
                    writer.Write(ext);
                }
            }

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
                    string fileVersion = reader.ReadString();
                    long fileLength = fileStream.Length;
                    int step = 0;

                    if (fileVersion != "M3-Uditor")
                    {
                        MessageBox.Show("Wrong fileformat!", "M3-Uditor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    _groups.Clear();
                    while (reader.BaseStream.Position != reader.BaseStream.Length && !AbortLoading)
                    {
                        switch (reader.ReadString())
                        {
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
                                Add(stream);
                                break;
                            default:
                                break;
                        }
                        step = (int)((double)reader.BaseStream.Position / fileLength * 100);
                        OnProgressChanged(this, step);
                    }

                    if (AbortLoading)
                        _groups.Clear();

                    HasChanges = false;
                    Filename = fileStream.Name;
                    Console.WriteLine("Loaded {0} streams, {1} groups", CountStreams.ToString(), CountGroups.ToString());
                }
            }
        }
        public void Export(string filename)
        {
            using (StreamWriter streamWriter = new StreamWriter(filename, false))
            {
                // write header
                streamWriter.WriteLine("#EXTM3U");

                // write additional m3u data
                if ( _additionalExt.Count > 0 )
                {
                    foreach ( var ext in _additionalExt )
                    {
                        streamWriter.WriteLine(ext);
                    }
                }

                // write groups and streams
                foreach (Group group in _groups)
                {
                    if (group.Export)
                    {
                        foreach (Stream stream in group.Streams)
                        {
                            if (stream.Export)
                                streamWriter.WriteLine(stream.ToExtInf());
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

        public void MoveGroup(Group group, int v)
        {
            _groups.Remove(group);
            _groups.Insert(v, group);
            HasChanges = true;
        }

        private void OnPropertyChanged(string v)
        {
            var handler = PropertyChanged;
            if ( handler != null )
            {
                HasChanges = true;
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
