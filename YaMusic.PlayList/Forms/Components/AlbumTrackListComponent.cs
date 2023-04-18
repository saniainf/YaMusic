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
            Dock = DockStyle.Fill;
            View = View.Details;
            LabelEdit = false;
            AllowColumnReorder = false;
            FullRowSelect = true;
            GridLines = true;
            Sorting = SortOrder.None;
            UseCompatibleStateImageBehavior = false;

            Columns.Add("#", -2, HorizontalAlignment.Left);
            Columns.Add("Название", -2, HorizontalAlignment.Left);
            Columns.Add("Исполнитель", -2, HorizontalAlignment.Left);
            Columns.Add("Альбом", -2, HorizontalAlignment.Left);
        }
    }
}
