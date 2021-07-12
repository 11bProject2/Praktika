using KatalogFilmi;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MovieContext:DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Ganre> Ganres { get; set; }
        public DbSet<MovieActor> MoviesActors { get; set; }
        public DbSet<MovieAuthor> MoviesAuthors { get; set; }
        public DbSet<Person> Persons { get; set; }

        public MovieContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Integrated Security=True;Database=Movies");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>().HasKey(x => new { x.MovieId, x.ActorId });
            modelBuilder.Entity<MovieAuthor>().HasKey(x => new { x.MovieId, x.AuthorId });
        }
    }
}
