using DataLayer.DTO;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) :base(options)
        {

        }

        public DbSet<Track> Tracks { get; set; }
        public DbSet<Artist> Artists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedDatabase(modelBuilder);
        }

        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Track>().HasData(
                new Track
                {
                    ID = 1,
                    Name = "Master of Puppets",
                    ArtistID = 1
                },
                new Track
                {
                    ID = 2,
                    Name = "Satairway to Heaven",
                    ArtistID = 2
                },
                new Track
                {
                    ID = 3,
                    Name = "Back in Black",
                    ArtistID = 3
                },
                new Track
                {
                    ID = 4,
                    Name = "Walk",
                    ArtistID = 4
                },
                new Track
                {
                    ID = 5,
                    Name = "Ace of Spades",
                    ArtistID = 5
                }
            );
            modelBuilder.Entity<Artist>().HasData(
                new Artist
                {
                    ID = 1,
                    Name = "Metallica",
                },
                new Artist
                {
                    ID = 2,
                    Name = "Led Zeppelin",
                },
                new Artist
                {
                    ID = 3,
                    Name = "ACDC",
                },
                new Artist
                {
                    ID = 4,
                    Name = "Panthera",
                },
                new Artist
                {
                    ID = 5,
                    Name = "Motorhead",
                }
            );
        }
    }
}