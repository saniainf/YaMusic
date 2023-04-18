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
            AlbumTableLayoutComponent panel = new();

            panel.Controls.Add(_trackList, 0, 0);
            panel.SetRowSpan(_trackList, 2);
            panel.Controls.Add(_picture, 1, 0);
            panel.Controls.Add(_description, 1, 1);

            Controls.Add(panel);
        }
    }
}
