using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YaMusic.PlayListView.Models
{
    internal class TrackViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public IEnumerable<ArtistViewModel> Artists { get; set; } = null!;
        public IEnumerable<AlbumViewModel> Albums { get; set; } = null!;
    }
}
