﻿using Microsoft.EntityFrameworkCore;
using DataBaseDummyProject.Models;

namespace DataBaseDummyProject.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieDetail> MovieDetails { get; set; }
        public DbSet<Star> Stars { get; set; }
        public DbSet<WatchHistory> WatchHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\quick\source\repos\TabbedMovie\DataBaseDummyProject\Data\MovieDb.db3");
        }
    }
}
