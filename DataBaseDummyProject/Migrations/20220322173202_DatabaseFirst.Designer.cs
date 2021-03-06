// <auto-generated />
using DataBaseDummyProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DataBaseDummyProject.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20220322173202_DatabaseFirst")]
    partial class DatabaseFirst
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("DataBaseDummyProject.Models.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<int?>("movies");

                    b.HasKey("Id");

                    b.HasIndex("movies");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("DataBaseDummyProject.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MoviesId");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("MoviesId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("DataBaseDummyProject.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Imdb_Id")
                        .HasMaxLength(18);

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("DataBaseDummyProject.Models.MovieDetail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description")
                        .HasMaxLength(600);

                    b.Property<string>("liked")
                        .HasMaxLength(60);

                    b.Property<int>("movieId");

                    b.Property<decimal>("popularity")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("rated")
                        .HasMaxLength(60);

                    b.Property<DateTime>("release_date");

                    b.Property<int>("runtime");

                    b.Property<DateTime>("watched");

                    b.HasKey("id");

                    b.HasIndex("movieId");

                    b.ToTable("MovieDetails");
                });

            modelBuilder.Entity("DataBaseDummyProject.Models.Star", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("moviesId");

                    b.Property<string>("name")
                        .HasMaxLength(100);

                    b.HasKey("id");

                    b.HasIndex("moviesId");

                    b.ToTable("Stars");
                });

            modelBuilder.Entity("DataBaseDummyProject.Models.WatchHistory", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("liked")
                        .HasMaxLength(100);

                    b.Property<int?>("moviesId");

                    b.Property<DateTime>("watched");

                    b.HasKey("id");

                    b.HasIndex("moviesId");

                    b.ToTable("WatchHistories");
                });

            modelBuilder.Entity("DataBaseDummyProject.Models.Director", b =>
                {
                    b.HasOne("DataBaseDummyProject.Models.Movie", "Movies")
                        .WithMany("Directors")
                        .HasForeignKey("movies");
                });

            modelBuilder.Entity("DataBaseDummyProject.Models.Genre", b =>
                {
                    b.HasOne("DataBaseDummyProject.Models.Movie", "Movies")
                        .WithMany("Genres")
                        .HasForeignKey("MoviesId");
                });

            modelBuilder.Entity("DataBaseDummyProject.Models.MovieDetail", b =>
                {
                    b.HasOne("DataBaseDummyProject.Models.Movie", "movies")
                        .WithMany("MovieDetails")
                        .HasForeignKey("movieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataBaseDummyProject.Models.Star", b =>
                {
                    b.HasOne("DataBaseDummyProject.Models.Movie", "movies")
                        .WithMany("Stars")
                        .HasForeignKey("moviesId");
                });

            modelBuilder.Entity("DataBaseDummyProject.Models.WatchHistory", b =>
                {
                    b.HasOne("DataBaseDummyProject.Models.Movie", "movies")
                        .WithMany("WatchHistories")
                        .HasForeignKey("moviesId");
                });
#pragma warning restore 612, 618
        }
    }
}
