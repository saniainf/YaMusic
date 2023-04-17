using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using YaMusic.DBCreate.Models;

namespace YaMusic.DBCreate
{
    internal class Repository
    {
        private readonly DBContext _db;
        private readonly PlayListModel _playList;

        internal Repository(SqlConnection connection)
        {
            _db = new(connection);
            _playList = PlayList.CreateFromFile();
        }

        internal void DropDB(string name)
        {
            var query = $"use master; drop database {name};";
            _db.ExecuteNonQueryCommand(query, "DropDB");
        }

        internal void CreateDB(string name)
        {
            var query = $"use master; create database {name};";
            _db.ExecuteNonQueryCommand(query, "CreateDB");
        }

        internal void CreateTablePlayList(string dbname)
        {
            var query = @$"
                use {dbname}; 
                create table [PlayLists]
                (
	                [Id] int not null identity(1,1),
	                [Title] nvarchar(100) not null,
                    constraint PK__PlayLists_Id primary key (Id) 
                );
            ";
            _db.ExecuteNonQueryCommand(query, "create table [PlayLists]");
        }

        internal void SeedTablePlayList(string dbname)
        {
            var query = @$"
                use {dbname}; 
                insert into [PlayLists] values (N'{_playList.Playlist.Title}');
            ";
            _db.ExecuteNonQueryCommand(query, "seed table [PlayLists]");
        }

        internal void CreateTableTracks(string dbname)
        {
            var query = @$"
                use {dbname}; 
                create table [Tracks]
                (
	                [Id] int not null,
	                [Title] nvarchar(100) not null,
	                [DurationMs] int not null,
	                [CoverUri] nvarchar(300),
	                [LyricsAvailable] bit not null,
                    constraint PK__Tracks_Id primary key (Id)
                );
            ";
            _db.ExecuteNonQueryCommand(query, "create table [Tracks]");
        }

        internal void SeedTableTracks(string dbname)
        {
            StringBuilder query = new();
            query.Append($"use {dbname}; ");
            foreach (var track in _playList.Playlist.Tracks)
            {
                int bit = track.LyricsAvailable ? 1 : 0;
                var next = $"insert into [Tracks] values ({track.Id}, N'{track.Title.Replace('\'', '"')}', {track.DurationMs}, '{track.CoverUri?.Replace('\'', '"')}', {bit}); ";
                query.Append(next);
            }
            var str = query.ToString();
            _db.ExecuteNonQueryCommand(str, "seed table [Tracks]");
        }

        internal void CreateTableArtists(string dbname)
        {
            var query = @$"
                use {dbname}; 
                create table [Artists]
                (
	                [Id] int not null,
	                [Name] nvarchar(100) not null,
	                [CoverUri] nvarchar(300),
                    constraint PK__Artists_Id primary key (Id)
                );
            ";
            _db.ExecuteNonQueryCommand(query, "create table [Artists]");
        }

        internal void SeedTableArtists(string dbname)
        {
            // исполнители могут повторяться
            HashSet<int> artists = new();
            StringBuilder query = new();
            query.Append($"use {dbname}; ");
            foreach (var track in _playList.Playlist.Tracks)
            {
                foreach (var artist in track.Artists)
                {
                    if (!artists.Contains(artist.Id))
                    {
                        artists.Add(artist.Id);
                        var next = $"insert into [Artists] values ({artist.Id}, N'{artist.Name.Replace('\'', '"')}', '{artist.Cover?.Uri.Replace('\'', '"')}'); ";
                        query.Append(next);
                    }
                }
            }
            var str = query.ToString();
            _db.ExecuteNonQueryCommand(str, "seed table [Artists]");
        }

        internal void CreateTableAlbums(string dbname)
        {
            var query = @$"
                use {dbname}; 
                create table [Albums]
                (
	                [Id] int not null,
	                [Title] nvarchar(100) not null,
	                [Year] int,
                    [Genre] nvarchar(50),
                    [TrackCount] int,
                    [CoverUri] nvarchar(300),
                    constraint PK__Albums_Id primary key (Id)
                );
            ";
            _db.ExecuteNonQueryCommand(query, "create table [Albums]");
        }

        internal void SeedTableAlbums(string dbname)
        {
            // альбомы могут повторяться
            HashSet<int> albums = new();
            StringBuilder query = new();
            query.Append($"use {dbname}; ");
            foreach (var track in _playList.Playlist.Tracks)
            {
                foreach (var album in track.Albums)
                {
                    if (!albums.Contains(album.Id))
                    {
                        albums.Add(album.Id);
                        var next = $"insert into [Albums] values ({album.Id}, N'{album.Title.Replace('\'', '"')}', {album.Year}, N'{album.Genre?.Replace('\'', '"')}', {album.TrackCount}, '{album.CoverUri?.Replace('\'', '"')}'); ";
                        query.Append(next);
                    }
                }
            }
            var str = query.ToString();
            _db.ExecuteNonQueryCommand(str, "seed table [Albums]");
        }

        internal void CreateTableGenres(string dbname)
        {
            var query = @$"
                use {dbname}; 
                create table [Genres]
                (
	                [Alias] nvarchar(100) not null,
	                [Title] nvarchar(100) not null,
                    constraint PK__Genres_Alias_Title primary key ([Alias], [Title])
                );
            ";
            _db.ExecuteNonQueryCommand(query, "create table [Genres]");
        }

        internal void SeedTableGenres(string dbname)
        {
            StringBuilder query = new();
            query.Append($"use {dbname}; ");
            foreach (var genre in Album.Genres)
            {
                var next = $"insert into [Genres] values ('{genre.Key.Replace('\'', '"')}', N'{genre.Value.Replace('\'', '"')}'); ";
                query.Append(next);
            }
            var str = query.ToString();
            _db.ExecuteNonQueryCommand(str, "seed table [Genres]");
        }

        internal void CreateTableTrackPlayList(string dbname)
        {
            var query = @$"
                use {dbname}; 
                create table [TrackPlayList]
                (
	                [TrackId] int not null,
                    [PlayListId] int not null,
                    constraint FK__TrackPlayList_TrackId__Tracks_Id foreign key([TrackId]) references [Tracks](Id),  
                    constraint FK__TrackPlayList_PlayListId__PlayLists_Id foreign key([PlayListId]) references [PlayLists](Id),
                    constraint PK__TrackPlayList_TrackId_PlayListId primary key ([TrackId], [PlayListId])
                );
            ";
            _db.ExecuteNonQueryCommand(query, "create table [TrackPlayList]");
        }

        internal void SeedTableTrackPlayList(string dbname)
        {
            StringBuilder query = new();
            query.Append(@$"
                use {dbname}; 
                declare @play_list_id int = (select p.Id from [{dbname}].[dbo].[PlayLists] p where p.[Title] = N'Мне нравится');
            ");

            foreach (var track in _playList.Playlist.Tracks)
            {
                var next = $"insert into [TrackPlayList] values ({track.Id}, @play_list_id); ";
                query.Append(next);
            }
            var str = query.ToString();
            _db.ExecuteNonQueryCommand(str, "seed table [TrackPlayList]");
        }

        internal void CreateTableTrackAlbum(string dbname)
        {
            var query = @$"
                use {dbname}; 
                create table [TrackAlbum]
                (
	                [TrackId] int not null,
                    [AlbumId] int not null,
                    constraint FK__TrackAlbum_TrackId__Tracks_Id foreign key([TrackId]) references [Tracks](Id),  
                    constraint FK__TrackAlbum_AlbumId__Albums_Id foreign key([AlbumId]) references [Albums](Id),
                    constraint PK__TrackAlbum_TrackId_AlbumId primary key ([TrackId], [AlbumId])
                );
            ";
            _db.ExecuteNonQueryCommand(query, "create table [TrackAlbum]");
        }

        internal void SeedTableTrackAlbum(string dbname)
        {
            StringBuilder query = new();
            query.Append(@$"use {dbname}; ");

            foreach (var track in _playList.Playlist.Tracks)
            {
                foreach (var album in track.Albums)
                {
                    var next = $"insert into [TrackAlbum] values ({track.Id}, {album.Id}); ";
                    query.Append(next);
                }
            }
            var str = query.ToString();
            _db.ExecuteNonQueryCommand(str, "seed table [TrackAlbum]");
        }

        internal void CreateTableTrackArtist(string dbname)
        {
            var query = @$"
                use {dbname}; 
                create table [TrackArtist]
                (
	                [TrackId] int not null,
                    [ArtistId] int not null,
                    constraint FK__TrackArtist_TrackId__Tracks_Id foreign key([TrackId]) references [Tracks](Id),  
                    constraint FK__TrackArtist_ArtistId__Artists_Id foreign key([ArtistId]) references [Artists](Id),
                    constraint PK__TrackArtist_TrackId_ArtistId primary key ([TrackId], [ArtistId])
                );
            ";
            _db.ExecuteNonQueryCommand(query, "create table [TrackArtist]");
        }

        internal void SeedTableTrackArtist(string dbname)
        {
            StringBuilder query = new();
            query.Append(@$"use {dbname}; ");

            foreach (var track in _playList.Playlist.Tracks)
            {
                foreach (var artist in track.Artists)
                {
                    var next = $"insert into [TrackArtist] values ({track.Id}, {artist.Id}); ";
                    query.Append(next);
                }
            }
            var str = query.ToString();
            _db.ExecuteNonQueryCommand(str, "seed table [TrackArtist]");
        }
    }
}
