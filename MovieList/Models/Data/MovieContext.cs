using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System; //Adding the namespace

namespace MovieList.Models
{
    public class MovieContext : IdentityDbContext<IdentityUser>
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = "A", Name = "Action" },
                new Genre { GenreId = "C", Name = "Comedy" },
                new Genre { GenreId = "D", Name = "Drama" },
                new Genre { GenreId = "H", Name = "Horror" },
                new Genre { GenreId = "M", Name = "Musical" },
                new Genre { GenreId = "R", Name = "RomCom" },
                new Genre { GenreId = "S", Name = "SciFi" }
                );

            modelBuilder.Entity<Movie>().HasData(
               new Movie
               {
                   MovieId = 1,
                   Name = "Casablanca",
                   Year = 1942,
                   Rating = 5,
                   GenreId = "D",
                   ReleaseDate = new DateTime(1942, 11, 26), // Added ReleaseDate
                   Director = "Michael Curtiz", // Added Director
                   Duration = 102 // Added Duration
               },
                new Movie
                {
                    MovieId = 2,
                    Name = "Wonder Woman",
                    Year = 2017,
                    Rating = 3,
                    GenreId = "A",
                    ReleaseDate = new DateTime(2017, 6, 2), // Added ReleaseDate
                    Director = "Patty Jenkins", // Added Director
                    Duration = 141 // Added Duration
                },
                new Movie
                {
                    MovieId = 3,
                    Name = "Moonstruck",
                    Year = 1988,
                    Rating = 4,
                    GenreId = "R",
                    ReleaseDate = new DateTime(1988, 12, 16), // Added ReleaseDate
                    Director = "Norman Jewison", // Added Director
                    Duration = 102 // Added Duration
                }
                );
        }
    }
}
