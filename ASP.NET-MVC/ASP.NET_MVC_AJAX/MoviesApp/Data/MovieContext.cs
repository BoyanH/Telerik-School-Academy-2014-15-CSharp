using MoviesApp.Migrations;
using MoviesApp.Models;
using System.Data.Entity;

namespace MoviesApp.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext()
            : base("MovieConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MovieContext, Configuration>());
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
    }
}