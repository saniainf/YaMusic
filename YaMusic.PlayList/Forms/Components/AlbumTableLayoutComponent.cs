using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YaMusic.PlayListView.Forms.Components
{
    internal class AlbumTableLayoutComponent : TableLayoutPanel
    {
        public AlbumTableLayoutComponent() : base()
        {
            Dock = DockStyle.Fill;
            ColumnCount = 2;
            RowCount = 2;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
        }
    }
}
