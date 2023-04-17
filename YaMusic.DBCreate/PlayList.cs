using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using YaMusic.DBCreate.Models;

namespace YaMusic.DBCreate
{
    internal static class PlayList
    {
        internal static PlayListModel CreateFromFile()
        {
            using FileStream fileStream = new("playlist.json", FileMode.Open);
            PlayListModel playListFile = JsonSerializer.Deserialize<PlayListModel>(fileStream);
            return playListFile;
        }

        internal static PlayListModel CreateFromHttp()
        {
            return new PlayListModel();
        }
    }
}
