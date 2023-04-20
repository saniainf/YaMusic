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

        private readonly Random _random;

        // https://music.yandex.ru/handlers/artist.jsx?artist=291&what=tracks&sort=&dir=&period=month&lang=ru&external-domain=music.yandex.ru&overembed=false&ncrnd=0.377978113391237
        // https://music.yandex.ru/handlers/album.jsx?album=14574&lang=ru&external-domain=music.yandex.ru&overembed=false&ncrnd=0.8780324078257287

        public AppHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _random = new();
        }

        internal async Task<AlbumModel> GetAlbumAsync(int albumId)
        {
            AlbumModel album = new();
            try
            {
                //using FileStream response = new("album.json", FileMode.Open);
                var ncrnd = _random.NextDouble();
                var response = await _httpClient.GetStringAsync($"{_albumUrl}{albumId}&lang=ru&external-domain=music.yandex.ru&overembed=false&ncrnd={ncrnd}");
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
