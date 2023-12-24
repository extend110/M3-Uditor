using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using M3Controls;

namespace M3U8
{
    public class Group : ListBoxItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Index 
        { 
            get
            {
                return Parent.Groups.IndexOf(this);
            } 
        }
        public int CountStreams
        {
            get
            {
                Description = "Streams: " + _streams.Count;
                return _streams.Count;
            }
        }
        public BindingList<Stream> Streams
        { 
            get
            { 
                return _streams; 
            }
            set
            {
                _streams = value;
                OnPropertyChanged(nameof(Streams));
            }
        }
        public string Name 
        { 
            get { return _name; }
            set
            {
                if ( _name != value )
                {
                    _name = value;
                    Title = value;
                    foreach ( Stream stream in Streams )
                    {
                        stream.Group = value;
                    }
                    OnPropertyChanged( "Name" );
                }
            }
        }
        public bool Export
        {
            get { return _export; }
            set 
            { 
                _export = value;
                OnPropertyChanged("Export"); 
            }
        }
        public Playlist Parent;

        private bool _export;
        private string _name;
        private BindingList<Stream> _streams = new BindingList<Stream>();

        public Group(Playlist parent)
        {
            Name = "Default";
            Export = true;
            Parent = parent;
        }
        public Group(string name, Playlist parent)
        {
            Name = name;
            Export = true;
            Parent = parent;
        }
        public Group(string name, BindingList<Stream> streams, Playlist parent)
        {
            Name = name;
            _streams = streams;
            Export = true;
            Parent = parent;
        }

        public void RemoveStream(Stream stream)
        {
            _streams.Remove(stream);
            OnPropertyChanged("Streams");
        }
        public void ReorderStream(Stream stream, int index)
        {
            if (index == -1) return;
            _streams.Remove(stream);
            _streams.Insert(index, stream);
            OnPropertyChanged("Streams");
        }
        public void AddStream(Stream stream)
        {
            stream.Parent = Parent;
            stream.Group = this.Name;
            _streams.Add(stream);
            OnPropertyChanged("Streams");
        }
        public int MoveStream(Stream stream, int direction)
        {
            int streamIndex = -1;
            for (int i = 0; i < _streams.Count; i++)
            {
                if ( stream.Id == _streams[i].Id )
                {
                    streamIndex = i;
                    break;
                }
            }

            int newIndex = streamIndex + direction;
            if ( newIndex < 0 || newIndex >= _streams.Count)
            {
                return streamIndex;
            }

            _streams.RemoveAt(streamIndex);
            _streams.Insert(newIndex, stream);

            OnPropertyChanged("Streams");
            return newIndex;
        }
        public Stream FindStreamById(int id)
        {
            return _streams.Where(s => s.Id == id).FirstOrDefault();
        }

        private void OnPropertyChanged( string propertyName )
        {
            var handler = PropertyChanged;
            if ( handler != null )
            {
                handler( this, new PropertyChangedEventArgs( propertyName ) );
            }
        }

        internal void SaveBinary(BinaryWriter writer)
        {
            writer.Write("GROUPELEMENT");
            writer.Write(_name);
            writer.Write(_export);
        }

        public override string ToString()
        {
            return _name + " (" + CountStreams.ToString() + ")";
        }
    }
}
