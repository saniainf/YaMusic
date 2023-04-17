using System;
using System.Collections.Generic;

namespace YaMusic.PlayListView.Domain.Models
{
    public partial class TrackDto
    {
        public TrackDto()
        {
            Albums = new HashSet<AlbumDto>();
            Artists = new HashSet<ArtistDto>();
            PlayLists = new HashSet<PlayListDto>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int DurationMs { get; set; }
        public string? CoverUri { get; set; }
        public bool LyricsAvailable { get; set; }

        public virtual ICollection<AlbumDto> Albums { get; set; }
        public virtual ICollection<ArtistDto> Artists { get; set; }
        public virtual ICollection<PlayListDto> PlayLists { get; set; }
    }
}
