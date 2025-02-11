﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheUltimateGamingPlatform.Database;

#nullable disable

namespace TheUltimateGamingPlatform.Database.Migrations
{
    [DbContext(typeof(TheUltimateGamingPlatformContext))]
    [Migration("20241103081546_AddSoundCard")]
    partial class AddSoundCard
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GameGenre", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.HasKey("GamesId", "GenresId");

                    b.HasIndex("GenresId");

                    b.ToTable("GameGenre");
                });

            modelBuilder.Entity("TheUltimateGamingPlatform.Model.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MinimumSystemRequirementId")
                        .HasColumnType("int");

                    b.Property<string>("PreviewImg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("RecommendedSystemRequirementId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MinimumSystemRequirementId");

                    b.HasIndex("RecommendedSystemRequirementId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("TheUltimateGamingPlatform.Model.GameContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("UrlContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("GameContents");
                });

            modelBuilder.Entity("TheUltimateGamingPlatform.Model.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("TheUltimateGamingPlatform.Model.SystemRequirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Additionally")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DirectX")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HardDrive")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Memory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Network")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Processor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoundCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoCard")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SystemRequirements");
                });

            modelBuilder.Entity("GameGenre", b =>
                {
                    b.HasOne("TheUltimateGamingPlatform.Model.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheUltimateGamingPlatform.Model.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TheUltimateGamingPlatform.Model.Game", b =>
                {
                    b.HasOne("TheUltimateGamingPlatform.Model.SystemRequirement", "MinimumSystemRequirement")
                        .WithMany()
                        .HasForeignKey("MinimumSystemRequirementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheUltimateGamingPlatform.Model.SystemRequirement", "RecommendedSystemRequirement")
                        .WithMany()
                        .HasForeignKey("RecommendedSystemRequirementId");

                    b.Navigation("MinimumSystemRequirement");

                    b.Navigation("RecommendedSystemRequirement");
                });

            modelBuilder.Entity("TheUltimateGamingPlatform.Model.GameContent", b =>
                {
                    b.HasOne("TheUltimateGamingPlatform.Model.Game", null)
                        .WithMany("GameContents")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("TheUltimateGamingPlatform.Model.Game", b =>
                {
                    b.Navigation("GameContents");
                });
#pragma warning restore 612, 618
        }
    }
}
