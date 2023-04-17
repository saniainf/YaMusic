using System.Data.SqlClient;

namespace YaMusic.DBCreate
{
    internal class Program
    {
        // Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=YaMusic;Integrated Security=SSPI;" Microsoft.EntityFrameworkCore.SqlServer

        static readonly string path = "Server=(localdb)\\mssqllocaldb;Database=master;Integrated Security=SSPI";
        static readonly string dbname = "YaMusic";

        static void Main(string[] args)
        {
            using SqlConnection connection = new(path);
            connection.Open();

            Repository repo = new(connection);

            repo.DropDB(dbname);
            repo.CreateDB(dbname);

            repo.CreateTablePlayList(dbname);
            repo.SeedTablePlayList(dbname);

            repo.CreateTableTracks(dbname);
            repo.SeedTableTracks(dbname);

            repo.CreateTableArtists(dbname);
            repo.SeedTableArtists(dbname);

            repo.CreateTableAlbums(dbname);
            repo.SeedTableAlbums(dbname);

            repo.CreateTableGenres(dbname);
            repo.SeedTableGenres(dbname);

            repo.CreateTableTrackPlayList(dbname);
            repo.SeedTableTrackPlayList(dbname);

            repo.CreateTableTrackAlbum(dbname);
            repo.SeedTableTrackAlbum(dbname);            
            
            repo.CreateTableTrackArtist(dbname);
            repo.SeedTableTrackArtist(dbname);

            connection.Close();
        }
    }
}