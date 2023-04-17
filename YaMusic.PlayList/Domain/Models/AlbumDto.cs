using System;
using System.Collections.Generic;

namespace YaMusic.PlayListView.Domain.Models
{
    public partial class AlbumDto
    {
        public AlbumDto()
        {
            Tracks = new HashSet<TrackDto>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int? Year { get; set; }
        public string? Genre { get; set; }
        public int? TrackCount { get; set; }
        public string? CoverUri { get; set; }

        public virtual ICollection<TrackDto> Tracks { get; set; }
    }
}
