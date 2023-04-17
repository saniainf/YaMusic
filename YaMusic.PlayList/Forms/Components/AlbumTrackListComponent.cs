using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YaMusic.PlayListView.Forms.Components
{
    internal class AlbumTrackListComponent : ListView
    {
        public AlbumTrackListComponent() : base()
        {
            Location = new Point(6, 6);
            Size = new Size(349, 200);
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
