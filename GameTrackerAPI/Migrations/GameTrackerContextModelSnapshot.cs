﻿// <auto-generated />
using System;
using GameTracker.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameTrackerAPI.Migrations
{
    [DbContext(typeof(GameTrackerContext))]
    partial class GameTrackerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GameTracker.API.Models.Game", b =>
                {
                    b.Property<Guid>("gameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("gameName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("originalCost")
                        .HasColumnType("float");

                    b.Property<DateTime>("purchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("gameId");

                    b.HasIndex("userId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GameTracker.API.Models.User", b =>
                {
                    b.Property<Guid>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GameTracker.API.Models.Game", b =>
                {
                    b.HasOne("GameTracker.API.Models.User", null)
                        .WithMany("games")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameTracker.API.Models.User", b =>
                {
                    b.Navigation("games");
                });
#pragma warning restore 612, 618
        }
    }
}
