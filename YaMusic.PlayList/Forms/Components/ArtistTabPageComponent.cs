using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YaMusic.PlayListView.Forms.Components
{
    internal class ArtistTabPageComponent : TabPage
    {
        public ListView AlbumList => _albumList;
        private readonly ArtistAlbumListComponent _albumList;

        public PictureBox Picture => _picture;
        private readonly ArtistPictureComponent _picture;

        public ArtistDescriptionComponent Description => _description;
        private readonly ArtistDescriptionComponent _description;

        public ArtistTabPageComponent() : base()
        {
            _albumList = new();
            _picture = new();
            _description = new();
            ArtistTableLayoutComponent panel = new();

            panel.Controls.Add(_albumList, 0, 0);
            panel.SetRowSpan(_albumList, 2);
            panel.Controls.Add(_picture, 1, 0);
            panel.Controls.Add(_description, 1, 1);

            Controls.Add(panel);
        }
    }
}
