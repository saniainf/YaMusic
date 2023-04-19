using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using YaMusic.PlayListView.Properties;
using YaMusic.PlayListView.Services.Models;

namespace YaMusic.PlayListView.Services
{
    internal class AppHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly string _albumUrl = Settings.Default.AlbumConnectionString;
        private readonly string _artistUrl = Settings.Default.ArtistConnectionString;
        private readonly string _trackUrl = Settings.Default.TrackConnectionString;

        // https://music.yandex.ru/handlers/album.jsx?album=3333300&lang=ru&external-domain=music.yandex.ru&overembed=false&ncrnd=0.16730049502357658

        public AppHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        internal async Task<AlbumModel> GetAlbumAsync(int albumId)
        {
            AlbumModel album = new();
            try
            {
                var response = await _httpClient.GetStringAsync(_albumUrl + albumId);
                album = JsonSerializer.Deserialize<AlbumModel>(response) ?? album;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return album;
        }
    }
}
