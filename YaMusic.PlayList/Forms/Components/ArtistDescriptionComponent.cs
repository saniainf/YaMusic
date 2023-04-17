using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace YaMusic.PlayListView.Forms.Components
{
    internal class ArtistDescriptionComponent : TextBox
    {
        public ArtistDescriptionComponent() : base()
        {
            Location = new Point(6, 212);
            Multiline = true;
            ReadOnly = true;
            ScrollBars = ScrollBars.Vertical;
            Size = new Size(557, 73);
            Text = "textBox1.Text";
        }
    }
}
