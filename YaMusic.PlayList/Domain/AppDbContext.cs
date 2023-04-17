using Microsoft.EntityFrameworkCore;
using YaMusic.PlayListView.Domain.Models;

namespace YaMusic.PlayListView.Domain
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlbumDto> Albums { get; set; } = null!;
        public virtual DbSet<ArtistDto> Artists { get; set; } = null!;
        public virtual DbSet<GenreDto> Genres { get; set; } = null!;
        public virtual DbSet<PlayListDto> PlayLists { get; set; } = null!;
        public virtual DbSet<TrackDto> Tracks { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=YaMusic;Integrated Security=SSPI;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumDto>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CoverUri).HasMaxLength(300);

                entity.Property(e => e.Genre).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<ArtistDto>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CoverUri).HasMaxLength(300);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<GenreDto>(entity =>
            {
                entity.HasKey(e => new { e.Alias, e.Title })
                    .HasName("PK__Genres_Alias_Title");

                entity.Property(e => e.Alias).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<PlayListDto>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<TrackDto>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CoverUri).HasMaxLength(300);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasMany(d => d.Albums)
                    .WithMany(p => p.Tracks)
                    .UsingEntity<Dictionary<string, object>>(
                        "TrackAlbum",
                        l => l.HasOne<AlbumDto>().WithMany().HasForeignKey("AlbumId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__TrackAlbum_AlbumId__Albums_Id"),
                        r => r.HasOne<TrackDto>().WithMany().HasForeignKey("TrackId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__TrackAlbum_TrackId__Tracks_Id"),
                        j =>
                        {
                            j.HasKey("TrackId", "AlbumId").HasName("PK__TrackAlbum_TrackId_AlbumId");

                            j.ToTable("TrackAlbum");
                        });

                entity.HasMany(d => d.Artists)
                    .WithMany(p => p.Tracks)
                    .UsingEntity<Dictionary<string, object>>(
                        "TrackArtist",
                        l => l.HasOne<ArtistDto>().WithMany().HasForeignKey("ArtistId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__TrackArtist_ArtistId__Artists_Id"),
                        r => r.HasOne<TrackDto>().WithMany().HasForeignKey("TrackId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__TrackArtist_TrackId__Tracks_Id"),
                        j =>
                        {
                            j.HasKey("TrackId", "ArtistId").HasName("PK__TrackArtist_TrackId_ArtistId");

                            j.ToTable("TrackArtist");
                        });

                entity.HasMany(d => d.PlayLists)
                    .WithMany(p => p.Tracks)
                    .UsingEntity<Dictionary<string, object>>(
                        "TrackPlayList",
                        l => l.HasOne<PlayListDto>().WithMany().HasForeignKey("PlayListId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__TrackPlayList_PlayListId__PlayLists_Id"),
                        r => r.HasOne<TrackDto>().WithMany().HasForeignKey("TrackId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__TrackPlayList_TrackId__Tracks_Id"),
                        j =>
                        {
                            j.HasKey("TrackId", "PlayListId").HasName("PK__TrackPlayList_TrackId_PlayListId");

                            j.ToTable("TrackPlayList");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
