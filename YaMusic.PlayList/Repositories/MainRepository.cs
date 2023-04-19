using Microsoft.EntityFrameworkCore;
using YaMusic.PlayListView.Domain;
using YaMusic.PlayListView.Domain.Models;
using YaMusic.PlayListView.Models;

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

        public async Task InsertTracksAsync(IEnumerable<TrackDto> tracks)
        {
            using AppDbContext dbContext = new(_options);
            Dictionary<int, AlbumDto> newAlbums = new();
            Dictionary<int, ArtistDto> newArtists = new();
            Dictionary<int, TrackDto> newTracks = new();

            foreach (var track in tracks)
            {
                if (!dbContext.Tracks.Any(t => t.Id == track.Id))
                {
                    newTracks.Add(track.Id, new()
                    {
                        Id = track.Id,
                        Title = track.Title,
                        DurationMs = track.DurationMs,
                        CoverUri = track.CoverUri,
                        LyricsAvailable = track.LyricsAvailable
                    });
                    foreach (var album in track.Albums)
                    {
                        if (!newAlbums.ContainsKey(album.Id))
                            if (!dbContext.Albums.Any(a => a.Id == album.Id))
                                newAlbums.Add(album.Id, album);
                            else
                                newAlbums.Add(album.Id, dbContext.Albums.FirstOrDefault(a => a.Id == album.Id)!);
                    }
                    foreach (var artist in track.Artists)
                    {
                        if (!newArtists.ContainsKey(artist.Id))
                            if (!dbContext.Artists.Any(a => a.Id == artist.Id))
                                newArtists.Add(artist.Id, artist);
                            else
                                newArtists.Add(artist.Id, dbContext.Artists.FirstOrDefault(a => a.Id == artist.Id)!);
                    }
                }
            }
            foreach (var track in tracks)
            {
                if (!newTracks.ContainsKey(track.Id)) continue;
                foreach (var album in track.Albums)
                    newTracks[track.Id].Albums.Add(newAlbums[album.Id]);
                foreach (var artist in track.Artists)
                    newTracks[track.Id].Artists.Add(newArtists[artist.Id]);
            }

            await dbContext.Tracks.AddRangeAsync(newTracks.Values.ToArray());
            await dbContext.SaveChangesAsync();
        }
    }
}
