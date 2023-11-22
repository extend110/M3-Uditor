using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using M3Controls;

namespace M3U8
{
    public class Group : ListBoxItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        Playlist _parent;
        bool _export;
        string _name;
        BindingList<Stream> _streams = new BindingList<Stream>();

        public Group(Playlist parent)
        {
            Name = "Default";
            Export = true;
            _parent = parent;
        }
        public Group(string name, Playlist parent)
        {
            Name = name;
            Export = true;
            _parent = parent;
        }
        public Group(string name, BindingList<Stream> streams, Playlist parent)
        {
            Name = name;
            _streams = streams;
            Export = true;
            _parent = parent;
        }

        public Stream FindStreamById(string id)
        {
            foreach (Stream stream in _streams)
            {
                if (stream.Id.ToString() == id)
                    return stream;
            }
            return null;
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

        private void OnPropertyChanged( string propertyName )
        {
            var handler = PropertyChanged;
            if ( handler != null )
            {
                _parent.HasChanges = true;
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
