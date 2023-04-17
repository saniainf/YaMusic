using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YaMusic.PlayListView.Forms.Components;
using YaMusic.PlayListView.Repositories;

namespace YaMusic.PlayListView.Controllers
{
    internal class PlayListController
    {
        private readonly PlayListRepository _repo;

        public PlayListController(PlayListRepository repository)
        {
            _repo = repository;
        }

        public async Task<PlayListTabPageComponent> GetPlayListTabAsync(int playListId)
        {
            var playList = await _repo.GetPlayList(playListId);
            var tracks = await _repo.GetPlayListTracksAsync(playListId);
            int i = 1;
            PlayListTabPageComponent tab = new()
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
                tab.TrackList.Items.Add(item);
            }

            return tab;
        }

        public async Task<IEnumerable<ArtistTabPageComponent>> GetArtistsTabAsync(int trackId)
        {
            List<ArtistTabPageComponent> tabs = new();
            var artists = await _repo.GetArtistsByTrack(trackId);

            foreach (var artist in artists)
            {
                ArtistTabPageComponent newTab = new()
                {
                    Text = artist.Name,
                    Tag = artist.Id
                };

                var albums = await _repo.GetAlbumsByArtist(artist.Id);
                int i = 1;
                foreach (var album in albums)
                {
                    ListViewItem item = new(new string[] { i++.ToString(), album.Title, album.Year.ToString(), album.Genre });
                    item.Tag = album.Id;
                    newTab.AlbumList.Items.Add(item);
                }

                tabs.Add(newTab);
            }

            return tabs;
        }
    }
}
