using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YaMusic.PlayListView.Forms.Components
{
    internal class PlayListTrackListComponent : ListView
    {
        public PlayListTrackListComponent() : base()
        {
            Dock = DockStyle.Fill;
            UseCompatibleStateImageBehavior = false;
            View = View.Details;
            LabelEdit = false;
            AllowColumnReorder = false;
            FullRowSelect = true;
            GridLines = true;
            Sorting = SortOrder.None;

            Columns.Add("#", -2, HorizontalAlignment.Left);
            Columns.Add("Title", -2, HorizontalAlignment.Left);
            Columns.Add("Artist", -2, HorizontalAlignment.Left);
            Columns.Add("Album", -2, HorizontalAlignment.Left);
        }
    }
}
