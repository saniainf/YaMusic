using System;
using System.Collections.Generic;

namespace YaMusic.PlayListView.Domain.Models
{
    public partial class PlayListDto
    {
        public PlayListDto()
        {
            Tracks = new HashSet<TrackDto>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<TrackDto> Tracks { get; set; }
    }
}
