using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YaMusic.PlayListView.Forms.Components
{
    internal class AlbumTabPageComponent : TabPage
    {
        public ListView TrackList => _trackList;
        private readonly AlbumTrackListComponent _trackList;

        public PictureBox Picture => _picture;
        private readonly AlbumPictureComponent _picture;

        public AlbumDescriptionComponent Description => _description;
        private readonly AlbumDescriptionComponent _description;

        public AlbumTabPageComponent() : base()
        {
            _trackList = new();
            _picture = new();
            _description = new();
            Controls.Add(_trackList);
            Controls.Add(_picture);
        }
    }
}
