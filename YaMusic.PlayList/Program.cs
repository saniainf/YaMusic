using Microsoft.EntityFrameworkCore;
using YaMusic.PlayListView.Controllers;
using YaMusic.PlayListView.Domain;
using YaMusic.PlayListView.Forms;
using YaMusic.PlayListView.Repositories;

namespace YaMusic.PlayListView
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var dbContextBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var dbContextOptions = dbContextBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=YaMusic;Integrated Security=SSPI;").Options;

            var _repo = new PlayListRepository(dbContextOptions);
            var _controller = new PlayListController(_repo);

            ApplicationConfiguration.Initialize();
            Application.Run(new FormMain(_controller));
        }
    }
}