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
    public List<List<Track>> Volumes { get; set; } = new();

    [JsonPropertyName("coverUri")]
    public string CoverUri { get; set; } = string.Empty;
}

public class Track
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("durationMs")]
    public int DurationMs { get; set; }

    [JsonPropertyName("artists")]
    public List<Artist> Artists { get; set; } = new();

    [JsonPropertyName("albums")]
    public List<Album> Albums { get; set; } = new();

    [JsonPropertyName("lyricsAvailable")]
    public bool LyricsAvailable { get; set; }

    [JsonPropertyName("coverUri")]
    public string CoverUri { get; set; } = string.Empty;
}

public class Artist
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("cover")]
    public Cover Cover { get; set; } = new();
}

public class Cover
{
    [JsonPropertyName("uri")]
    public string Uri { get; set; } = string.Empty;
}


public class Album
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("year")]
    public int Year { get; set; }

    [JsonPropertyName("coverUri")]
    public string CoverUri { get; set; } = string.Empty;

    [JsonPropertyName("genre")]
    public string Genre { get; set; } = string.Empty;

    [JsonPropertyName("trackCount")]
    public int TrackCount { get; set; }
}