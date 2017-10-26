using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace lesson3.Models{
    public class MovieContext : DbContext
        {

            public DbSet<Actor> Actors { get; set; }
            public DbSet<Movie> Movies { get; set; }

            //Added constructor to provide the connection to the database as a service (look at: startup.cs)
            public MovieContext(DbContextOptions<MovieContext> options): base(options)
            {
            }

            //Uncomment or remove the OnConfiguring method. It is not need any more
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
            
                    // http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings
                    optionsBuilder.UseNpgsql(@"Host=localhost;Database=MovieDB;Username=postgres;Password=postgres");
                }
            }
        } 

    public class Movie {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Release { get; set; }
        public List<Actor> Actors { get; set; }
    }

    public class Actor {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string Gender { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

    }
}