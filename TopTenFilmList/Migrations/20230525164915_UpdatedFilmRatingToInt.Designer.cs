﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TopTenFilmList.Models;

#nullable disable

namespace ToDoList.Migrations
{
    [DbContext(typeof(TopTenFilmListContext))]
    [Migration("20230525164915_UpdatedFilmRatingToInt")]
    partial class UpdatedFilmRatingToInt
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TopTenFilmList.Models.Actor", b =>
                {
                    b.Property<int>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ActorFName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ActorLName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ActorMainGenre")
                        .HasColumnType("longtext");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.HasKey("ActorId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("TopTenFilmList.Models.Film", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FilmAverageRating")
                        .HasColumnType("int");

                    b.Property<string>("FilmDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("FilmMPARating")
                        .HasColumnType("longtext");

                    b.Property<string>("FilmName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("StudioId")
                        .HasColumnType("int");

                    b.HasKey("FilmId");

                    b.HasIndex("StudioId");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("TopTenFilmList.Models.FilmActor", b =>
                {
                    b.Property<int>("FilmActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.HasKey("FilmActorId");

                    b.HasIndex("ActorId");

                    b.HasIndex("FilmId");

                    b.ToTable("FilmActors");
                });

            modelBuilder.Entity("TopTenFilmList.Models.Studio", b =>
                {
                    b.Property<int>("StudioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("StudioId");

                    b.ToTable("Studios");
                });

            modelBuilder.Entity("TopTenFilmList.Models.Film", b =>
                {
                    b.HasOne("TopTenFilmList.Models.Studio", null)
                        .WithMany("Films")
                        .HasForeignKey("StudioId");
                });

            modelBuilder.Entity("TopTenFilmList.Models.FilmActor", b =>
                {
                    b.HasOne("TopTenFilmList.Models.Actor", "Actor")
                        .WithMany("JoinEntities")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopTenFilmList.Models.Film", "Film")
                        .WithMany("JoinEntities")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("TopTenFilmList.Models.Actor", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("TopTenFilmList.Models.Film", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("TopTenFilmList.Models.Studio", b =>
                {
                    b.Navigation("Films");
                });
#pragma warning restore 612, 618
        }
    }
}
