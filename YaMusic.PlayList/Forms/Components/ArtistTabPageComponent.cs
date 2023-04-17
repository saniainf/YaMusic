using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YaMusic.PlayListView.Forms.Components
{
    internal class ArtistTabPageComponent : TabPage
    {
        public ListView AlbumList => _albumList;
        private readonly ArtistAlbumListComponent _albumList;

        public PictureBox Picture => _picture;
        private readonly ArtistPictureComponent _picture;

        public TextBox Description => _description;
        private readonly ArtistDescriptionComponent _description;

        public ArtistTabPageComponent() : base()
        {
            _albumList = new();
            _picture = new();
            _description = new();
            Controls.Add(_albumList);
            Controls.Add(_picture);
            Controls.Add(_description);
        }
    }
}
