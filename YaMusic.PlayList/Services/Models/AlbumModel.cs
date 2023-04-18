using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YaMusic.PlayListView.Services.Models;

public class AlbumModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("volumes")]
    public List<List<Track>> Volumes { get; set; }

    [JsonPropertyName("coverUri")]
    public string CoverUri { get; set; }
}

public class Track
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("durationMs")]
    public int DurationMs { get; set; }

    [JsonPropertyName("artists")]
    public List<Artist> Artists { get; set; }

    [JsonPropertyName("albums")]
    public List<Album> Albums { get; set; }

    [JsonPropertyName("lyricsAvailable")]
    public bool LyricsAvailable { get; set; }

    [JsonPropertyName("coverUri")]
    public string CoverUri { get; set; }
}

public class Artist
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("cover")]
    public Cover Cover { get; set; }
}

public class Cover
{
    [JsonPropertyName("uri")]
    public string Uri { get; set; }
}


public class Album
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("year")]
    public int Year { get; set; }

    [JsonPropertyName("coverUri")]
    public string CoverUri { get; set; }

    [JsonPropertyName("genre")]
    public string Genre { get; set; }

    [JsonPropertyName("trackCount")]
    public int TrackCount { get; set; }
}