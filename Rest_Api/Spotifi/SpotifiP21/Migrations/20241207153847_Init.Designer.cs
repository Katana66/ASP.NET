﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SpotifyP21.Data;

#nullable disable

namespace SpotifyP21.Migrations
{
    [DbContext(typeof(SpotifyContext))]
    [Migration("20241207153847_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AlbumGenre", b =>
                {
                    b.Property<int>("AlbumsId")
                        .HasColumnType("integer");

                    b.Property<int>("GenresId")
                        .HasColumnType("integer");

                    b.HasKey("AlbumsId", "GenresId");

                    b.HasIndex("GenresId");

                    b.ToTable("AlbumGenre");
                });

            modelBuilder.Entity("AlbumGroup", b =>
                {
                    b.Property<int>("AlbumsId")
                        .HasColumnType("integer");

                    b.Property<int>("GroupsId")
                        .HasColumnType("integer");

                    b.HasKey("AlbumsId", "GroupsId");

                    b.HasIndex("GroupsId");

                    b.ToTable("AlbumGroup");
                });

            modelBuilder.Entity("AlbumSong", b =>
                {
                    b.Property<int>("AlbumsId")
                        .HasColumnType("integer");

                    b.Property<int>("SongsId")
                        .HasColumnType("integer");

                    b.HasKey("AlbumsId", "SongsId");

                    b.HasIndex("SongsId");

                    b.ToTable("AlbumSong");
                });

            modelBuilder.Entity("GenreGroup", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("integer");

                    b.Property<int>("GroupsId")
                        .HasColumnType("integer");

                    b.HasKey("GenresId", "GroupsId");

                    b.HasIndex("GroupsId");

                    b.ToTable("GenreGroup");
                });

            modelBuilder.Entity("SpotifyP21.Entities.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("SpotifyP21.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("SpotifyP21.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("SpotifyP21.Entities.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("AlbumGenre", b =>
                {
                    b.HasOne("SpotifyP21.Entities.Album", null)
                        .WithMany()
                        .HasForeignKey("AlbumsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpotifyP21.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AlbumGroup", b =>
                {
                    b.HasOne("SpotifyP21.Entities.Album", null)
                        .WithMany()
                        .HasForeignKey("AlbumsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpotifyP21.Entities.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AlbumSong", b =>
                {
                    b.HasOne("SpotifyP21.Entities.Album", null)
                        .WithMany()
                        .HasForeignKey("AlbumsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpotifyP21.Entities.Song", null)
                        .WithMany()
                        .HasForeignKey("SongsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenreGroup", b =>
                {
                    b.HasOne("SpotifyP21.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpotifyP21.Entities.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
