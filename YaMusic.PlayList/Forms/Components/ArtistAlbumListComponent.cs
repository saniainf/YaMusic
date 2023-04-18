using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YaMusic.PlayListView.Forms.Components
{
    internal class ArtistAlbumListComponent : ListView
    {
        public ArtistAlbumListComponent() : base()
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
            Columns.Add("Год", -2, HorizontalAlignment.Left);
            Columns.Add("Жанр", -2, HorizontalAlignment.Left);
        }
    }
}
