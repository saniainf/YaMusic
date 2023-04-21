using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using YaMusic.PlayListView.Domain.Models;
using YaMusic.PlayListView.Forms.Components;
using YaMusic.PlayListView.Models;
using YaMusic.PlayListView.Repositories;
using YaMusic.PlayListView.Services;
using YaMusic.PlayListView.Services.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YaMusic.PlayListView.Controllers
{
    internal class MainController
    {
        private readonly MainRepository _repo;
        private readonly AppHttpService _httpService;

        public MainController(MainRepository repository, AppHttpService httpService)
        {
            _repo = repository;
            _httpService = httpService;
        }

        public async Task<PlayListTabPageComponent> GetPlayListTabAsync(int playListId)
        {
            var playList = await _repo.GetPlayListAsync(playListId);
            var tracks = await _repo.GetTracksByPlayListAsync(playListId);
            int i = 1;
            PlayListTabPageComponent newTab = new()
            {
                Text = playList.Title,
                Tag = playListId
            };
            foreach (var track in tracks)
            {
                ListViewItem item = new(new string[]
                {
                    i++.ToString(),
                    track.Title,
                    string.Join(", ", track.Artists.Select(t => t.Name)),
                    string.Join(", ", track.Albums.Select(a => a.Title)),
                });
                item.Tag = track.Id;
                newTab.TrackListItems.Add(item);
            }
            newTab.SetTrackList();

            return newTab;
        }

        public async Task<IEnumerable<ArtistTabPageComponent>> GetArtistsTabAsync(int trackId)
        {
            List<ArtistTabPageComponent> tabs = new();

            var artists = await _repo.GetArtistsByTrackAsync(trackId);

            foreach (var artist in artists)
            {
                ArtistTabPageComponent newTab = new()
                {
                    Text = artist.Name,
                    Tag = artist.Id
                };

                var albums = await _repo.GetAlbumsByArtistAsync(artist.Id);
                int i = 1;
                foreach (var album in albums)
                {
                    ListViewItem item = new(new string[]
                    {
                        i++.ToString(), album.Title,
                        album.Year.ToString(),
                        album.Genre
                    });
                    item.Tag = album.Id;
                    newTab.AlbumList.Items.Add(item);
                }

                tabs.Add(newTab);
            }

            return tabs;
        }

        public async Task<ArtistTabPageComponent> GetArtistTabByIdAsync(int artistId)
        {
            var artist = await _repo.GetArtistByIdAsync(artistId);

            ArtistTabPageComponent newTab = new()
            {
                Text = artist.Name,
                Tag = artist.Id
            };

            var albums = await _repo.GetAlbumsByArtistAsync(artist.Id);
            int i = 1;
            foreach (var album in albums)
            {
                ListViewItem item = new(new string[]
                {
                    i++.ToString(), album.Title,
                    album.Year.ToString(),
                    album.Genre
                });
                item.Tag = album.Id;
                newTab.AlbumList.Items.Add(item);
            }

            return newTab;
        }

        public async Task<IEnumerable<AlbumTabPageComponent>> GetAlbumsTabAsync(int trackId)
        {
            List<AlbumTabPageComponent> tabs = new();
            var albums = await _repo.GetAlbumsByTrackAsync(trackId);

            foreach (var album in albums)
            {
                AlbumTabPageComponent newTab = new()
                {
                    Text = album.Title,
                    Tag = album.Id
                };

                var tracks = await _repo.GetTracksByAlbumAsync(album.Id);
                int i = 1;
                foreach (var track in tracks)
                {
                    ListViewItem item = new(new string[]
                    {
                        i++.ToString(),
                        track.Title,
                        string.Join(", ", track.Artists.Select(t => t.Name)),
                        string.Join(", ", track.Albums.Select(a => a.Title)),
                    });
                    item.Tag = track.Id;
                    newTab.TrackList.Items.Add(item);
                }

                tabs.Add(newTab);
            }

            return tabs;
        }

        public async Task<AlbumTabPageComponent> GetAlbumTabByIdAsync(int albumId)
        {
            var album = await _repo.GetAlbumById(albumId);

            AlbumTabPageComponent newTab = new()
            {
                Text = album.Title,
                Tag = album.Id
            };

            var tracks = await _repo.GetTracksByAlbumAsync(album.Id);
            int i = 1;
            foreach (var track in tracks)
            {
                ListViewItem item = new(new string[]
                {
                        i++.ToString(),
                        track.Title,
                        string.Join(", ", track.Artists.Select(t => t.Name)),
                        string.Join(", ", track.Albums.Select(a => a.Title)),
                });
                item.Tag = track.Id;
                newTab.TrackList.Items.Add(item);
            }

            return newTab;
        }

        public async Task UpdateAlbumAsync(int albumId)
        {
            var album = await _httpService.GetAlbumByIdAsync(albumId);
            if (album is null || album.Volumes.Count == 0) return;
            foreach (var albumTracks in album.Volumes)
            {
                await _repo.InsertTracksAsync(albumTracks);
            }
        }

        public async Task UpdateArtistAsync(int artistId)
        {
            var artist = await _httpService.GetTracksByArtistAsync(artistId);
            if (artist is null || artist.Tracks.Count == 0) return;
            await _repo.InsertTracksAsync(artist.Tracks);
        }
    }
}
