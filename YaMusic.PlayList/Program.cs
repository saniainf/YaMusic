using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using YaMusic.PlayListView.Controllers;
using YaMusic.PlayListView.Domain;
using YaMusic.PlayListView.Forms;
using YaMusic.PlayListView.Properties;
using YaMusic.PlayListView.Repositories;
using YaMusic.PlayListView.Services;

namespace YaMusic.PlayListView
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var dbContextBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var dbContextOptions = dbContextBuilder.UseSqlServer(Settings.Default.ConnectionStrings).Options;
            var httpClient = new HttpClient();
            var httpService = new AppHttpService(httpClient);
            var repo = new MainRepository(dbContextOptions);
            var controller = new MainController(repo, httpService);

            ApplicationConfiguration.Initialize();
            Application.Run(new FormMain(controller));
        }
    }
}