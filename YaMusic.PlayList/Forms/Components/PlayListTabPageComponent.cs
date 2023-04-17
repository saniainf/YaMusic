using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YaMusic.PlayListView.Forms.Components
{
    internal class PlayListTabPageComponent : TabPage
    {
        public ListView TrackList => _trackList;
        private readonly PlayListTrackListComponent _trackList;

        public PlayListTabPageComponent() : base()
        {
            _trackList = new();
            Controls.Add(_trackList);
        }
    }
}
