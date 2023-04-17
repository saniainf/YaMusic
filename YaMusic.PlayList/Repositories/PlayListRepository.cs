using Microsoft.EntityFrameworkCore;
using YaMusic.PlayListView.Domain;
using YaMusic.PlayListView.Domain.Models;
using YaMusic.PlayListView.Models;

namespace YaMusic.PlayListView.Repositories
{
    internal class PlayListRepository
    {
        private readonly DbContextOptions<AppDbContext> _options;

        public PlayListRepository(DbContextOptions<AppDbContext> options)
        {
            _options = options;
        }

        public async Task<PlayListViewModel> GetPlayList(int playListId)
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

        public async Task<IEnumerable<PlayListViewModel>> GetPlayLists()
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

        public async Task<IEnumerable<AlbumViewModel>> GetAlbumsByArtist(int artistId)
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

        public async Task<IEnumerable<AlbumViewModel>> GetAlbumsByTrack(int trackId)
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

        public async Task<IEnumerable<ArtistViewModel>> GetArtistsByTrack(int trackId)
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

        public async Task<IEnumerable<TrackViewModel>> GetPlayListTracksAsync(int id)
        {
            using AppDbContext dbContext = new(_options);

            var query = await Task.Run(() =>
            {
                return dbContext.Tracks
                .Include(t => t.PlayLists)
                .Include(t => t.Artists)
                .Include(t => t.Albums)
                .Where(t => t.PlayLists.Any(p => p.Id == id))
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

        //public async Task<TrackDto> GetTrack(int id)
        //{
        //    using AppDbContext dbContext = new(_options);

        //    var query = await Task.Run(() =>
        //    {
        //        return dbContext.Tracks
        //        .Include(t => t.Artists)
        //        .Include(t => t.Albums)
        //        .Include(t => t.PlayLists)
        //        .Where(t => t.Id == id);
        //    });

        //    return await query.FirstOrDefaultAsync() ?? new();
        //}
    }
}
