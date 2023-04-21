using Microsoft.EntityFrameworkCore;
using YaMusic.PlayListView.Domain;
using YaMusic.PlayListView.Domain.Models;
using YaMusic.PlayListView.Models;
using YaMusic.PlayListView.Services.Models;

namespace YaMusic.PlayListView.Repositories
{
    internal class MainRepository
    {
        private readonly DbContextOptions<AppDbContext> _options;

        public MainRepository(DbContextOptions<AppDbContext> options)
        {
            _options = options;
        }

        public async Task<PlayListViewModel> GetPlayListAsync(int playListId)
        {
            using AppDbContext dbContext = new(_options);

            var query = await Task.Run(() =>
            {
                return dbContext.PlayLists
                .Where(p => p.Id == playListId)
                .Select(p => new PlayListViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                });
            });

            return await query.FirstOrDefaultAsync() ?? new();
        }

        public async Task<IEnumerable<PlayListViewModel>> GetPlayListsAsync()
        {
            using AppDbContext dbContext = new(_options);

            var query = await Task.Run(() =>
            {
                return dbContext.PlayLists
                .Select(p => new PlayListViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                });
            });

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<AlbumViewModel>> GetAlbumsByArtistAsync(int artistId)
        {
            using AppDbContext dbContext = new(_options);

            var query = await Task.Run(() =>
            {
                return dbContext.Tracks
                .Include(t => t.Albums)
                .Include(t => t.Artists)
                .Where(t => t.Artists.Any(a => a.Id == artistId))
                .SelectMany(t => t.Albums)
                .Select(a => new AlbumViewModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Year = a.Year ?? 0,
                    Genre = a.Genre ?? string.Empty
                })
                .Distinct()
                .OrderBy(a => a.Year).ThenBy(a => a.Title);
            });

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<AlbumViewModel>> GetAlbumsByTrackAsync(int trackId)
        {
            using AppDbContext dbContext = new(_options);

            var query = await Task.Run(() =>
            {
                return dbContext.Tracks
                .Include(t => t.Albums)
                .Where(t => t.Id == trackId)
                .SelectMany(t => t.Albums)
                .Select(a => new AlbumViewModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Year = a.Year ?? 0,
                    Genre = a.Genre ?? string.Empty
                });
            });

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<ArtistViewModel>> GetArtistsByTrackAsync(int trackId)
        {
            using AppDbContext dbContext = new(_options);

            var query = await Task.Run(() =>
            {
                return dbContext.Tracks
                .Include(t => t.Artists)
                .Where(t => t.Id == trackId)
                .SelectMany(t => t.Artists)
                .Select(a => new ArtistViewModel()
                {
                    Id = a.Id,
                    Name = a.Name ?? string.Empty
                })
                .OrderBy(a => a.Name);
            });

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TrackViewModel>> GetTracksByPlayListAsync(int playListId)
        {
            using AppDbContext dbContext = new(_options);

            var query = await Task.Run(() =>
            {
                return dbContext.Tracks
                .Include(t => t.PlayLists)
                .Include(t => t.Artists)
                .Include(t => t.Albums)
                .Where(t => t.PlayLists.Any(p => p.Id == playListId))
                .Select(t => new TrackViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Artists = t.Artists.Select(a => new ArtistViewModel()
                    {
                        Id = a.Id,
                        Name = a.Name
                    }),
                    Albums = t.Albums.Select(a => new AlbumViewModel()
                    {
                        Id = a.Id,
                        Title = a.Title,
                        Genre = a.Genre ?? string.Empty,
                        Year = a.Year ?? 0
                    }),
                });
            });

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TrackViewModel>> GetTracksByAlbumAsync(int albumId)
        {
            using AppDbContext dbContext = new(_options);

            var query = await Task.Run(() =>
            {
                return dbContext.Tracks
                .Include(t => t.Artists)
                .Include(t => t.Albums)
                .Where(t => t.Albums.Any(a => a.Id == albumId))
                .Select(t => new TrackViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Artists = t.Artists.Select(a => new ArtistViewModel()
                    {
                        Id = a.Id,
                        Name = a.Name
                    }),
                    Albums = t.Albums.Select(a => new AlbumViewModel()
                    {
                        Id = a.Id,
                        Title = a.Title,
                        Genre = a.Genre ?? string.Empty,
                        Year = a.Year ?? 0
                    }),
                });
            });

            return await query.ToListAsync();
        }

        public async Task<AlbumViewModel> GetAlbumById(int albumId)
        {
            using AppDbContext dbContext = new(_options);

            var query = await Task.Run(() =>
            {
                return dbContext.Albums
                .Where(a => a.Id == albumId)
                .Select(a => new AlbumViewModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Genre = a.Genre ?? string.Empty,
                    Year = a.Year ?? 0
                });
            });

            return query.FirstOrDefault() ?? new();
        }

        public async Task InsertTracksAsync(IEnumerable<Track> tracks)
        {
            using AppDbContext dbContext = new(_options);
            List<TrackDto> newTracks = new();

            foreach (var track in tracks)
            {
                var trackId = int.TryParse(track.Id, out int result) ? result : throw new InvalidCastException();

                if (dbContext.Tracks.Any(t => t.Id == trackId)) continue;

                var newTrack = new TrackDto()
                {
                    Id = trackId,
                    Title = track.Title,
                    DurationMs = track.DurationMs,
                    CoverUri = track.CoverUri,
                    LyricsAvailable = track.LyricsAvailable
                };

                foreach (var album in track.Albums)
                {
                    var newAlbum = await dbContext.Albums.FindAsync(album.Id);
                    if (newAlbum == null)
                    {
                        newAlbum = new AlbumDto()
                        {
                            Id = album.Id,
                            Title = album.Title,
                            Year = album.Year,
                            Genre = album.Genre,
                            TrackCount = album.TrackCount,
                            CoverUri = album.CoverUri
                        };
                        dbContext.Albums.Add(newAlbum);
                    }
                    newTrack.Albums.Add(newAlbum);
                }

                foreach (var artist in track.Artists)
                {
                    var newArtist = await dbContext.Artists.FindAsync(artist.Id);
                    if (newArtist == null)
                    {
                        newArtist = new ArtistDto()
                        {
                            Id = artist.Id,
                            Name = artist.Name,
                            CoverUri = artist.Cover.Uri
                        };
                        dbContext.Artists.Add(newArtist);
                    }
                    newTrack.Artists.Add(newArtist);
                }
                newTracks.Add(newTrack);
            }

            await dbContext.Tracks.AddRangeAsync(newTracks.ToArray());
            await dbContext.SaveChangesAsync();
        }
    }
}
