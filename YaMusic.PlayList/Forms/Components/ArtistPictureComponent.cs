using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YaMusic.PlayListView.Forms.Components
{
    internal class ArtistPictureComponent : PictureBox
    {
        public ArtistPictureComponent() : base()
        {
           Location = new Point(361, 6);
           Size = new Size(202, 200);
        }
    }
}