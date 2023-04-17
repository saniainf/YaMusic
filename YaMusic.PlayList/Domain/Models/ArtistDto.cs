using System;
using System.Collections.Generic;

namespace YaMusic.PlayListView.Domain.Models
{
    public partial class ArtistDto
    {
        public ArtistDto()
        {
            Tracks = new HashSet<TrackDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? CoverUri { get; set; }

        public virtual ICollection<TrackDto> Tracks { get; set; }
    }
}
