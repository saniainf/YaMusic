using Microsoft.EntityFrameworkCore;
using YaMusic.PlayListView.Controllers;
using YaMusic.PlayListView.Domain;
using YaMusic.PlayListView.Forms;
using YaMusic.PlayListView.Properties;
using YaMusic.PlayListView.Repositories;

namespace YaMusic.PlayListView
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var dbContextBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var dbContextOptions = dbContextBuilder.UseSqlServer(Settings.Default.ConnectionStrings).Options;
            var repo = new MainRepository(dbContextOptions);
            var httpClient = new HttpClient();
            var controller = new MainController(repo, httpClient);

            ApplicationConfiguration.Initialize();
            Application.Run(new FormMain(controller));
        }
    }
}