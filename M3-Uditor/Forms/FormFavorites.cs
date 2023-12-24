using M3U8;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M3_Uditor.Forms
{
    public partial class FormFavorites : Form
    {
        Playlist _playlist;
        BindingList<Stream> _streams;
        public FormFavorites(Playlist playlist)
        {
            InitializeComponent();

            _streams = new BindingList<Stream>();
            _playlist = playlist;
        }

        private void FormFavorites_Load(object sender, EventArgs e)
        {
            foreach (int id in _playlist.Favorites)
            {
                _streams.Add(_playlist.FindStreamById(id));
            }

            extendedListBoxFavorites.DataSource = _streams;
        }

        private void extendedListBoxFavorites_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Stream stream = extendedListBoxFavorites.SelectedItem as Stream;
            using (FormStreamDetails formStreamDetails = new FormStreamDetails(stream))
            {
                formStreamDetails.ShowDialog();
            }
        }
    }
}
