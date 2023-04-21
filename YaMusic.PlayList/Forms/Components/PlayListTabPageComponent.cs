using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.ListViewItem;

namespace YaMusic.PlayListView.Forms.Components
{
    internal class PlayListTabPageComponent : TabPage
    {
        public ListView TrackList => _trackList;
        private readonly PlayListTrackListComponent _trackList;

        public List<ListViewItem> TrackListItems { get; set; }

        public PlayListTabPageComponent() : base()
        {
            _trackList = new();
            TrackListItems = new();
            Controls.Add(_trackList);
        }

        internal void SetTrackList()
        {
            _trackList.Items.Clear();
            _trackList.Items.AddRange(TrackListItems.ToArray());
        }

        internal void SetFilteredTrackList(string filter)
        {
            _trackList.Items.Clear();
            foreach (var item in TrackListItems)
            {
                var find = false;
                foreach (ListViewSubItem subItem in item.SubItems)
                {
                    if (subItem.Text.Contains(filter, StringComparison.OrdinalIgnoreCase))
                    {
                        find = true;
                        break;
                    }
                }
                if (find)
                {
                    _trackList.Items.Add(item);
                }
            }
        }
    }
}
