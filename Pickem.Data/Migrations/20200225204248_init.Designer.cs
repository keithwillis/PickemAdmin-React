﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Pickem.Data;

namespace Pickem.Data.Migrations
{
    [DbContext(typeof(PickemContext))]
    [Migration("20200225204248_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Pickem.Domain.Conference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("SportLeagueId")
                        .HasColumnType("integer");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("SportLeagueId");

                    b.ToTable("Conferences");
                });

            modelBuilder.Entity("Pickem.Domain.Division", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ConferenceId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("ConferenceId");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("Pickem.Domain.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("GameGroupId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("GameTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("HomeId")
                        .HasColumnType("integer");

                    b.Property<int>("HomeScore")
                        .HasColumnType("integer");

                    b.Property<int?>("ScheduleId")
                        .HasColumnType("integer");

                    b.Property<int?>("VisitorId")
                        .HasColumnType("integer");

                    b.Property<int>("VisitorScore")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GameGroupId");

                    b.HasIndex("HomeId");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("VisitorId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Pickem.Domain.GameGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("GameGroups");
                });

            modelBuilder.Entity("Pickem.Domain.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("JoinCode")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("Pickem.Domain.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("SportLeagueId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SportLeagueId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Pickem.Domain.SportLeague", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<bool>("isEnabled")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("SportLeagues");
                });

            modelBuilder.Entity("Pickem.Domain.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("DivisionId")
                        .HasColumnType("integer");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Pickem.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Pickem.Domain.UserLeague", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("LeagueId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.HasKey("UserId", "LeagueId");

                    b.HasIndex("LeagueId");

                    b.ToTable("UserLeagues");
                });

            modelBuilder.Entity("Pickem.Domain.UserLeagueSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ScheduleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.ToTable("UserLeagueSchedules");
                });

            modelBuilder.Entity("Pickem.Domain.UserLeagueScheduleUserPicks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("UserLeagueScheduleUserPicks");
                });

            modelBuilder.Entity("Pickem.Domain.Conference", b =>
                {
                    b.HasOne("Pickem.Domain.SportLeague", null)
                        .WithMany("Conferences")
                        .HasForeignKey("SportLeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pickem.Domain.Division", b =>
                {
                    b.HasOne("Pickem.Domain.Conference", null)
                        .WithMany("Divisions")
                        .HasForeignKey("ConferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pickem.Domain.Game", b =>
                {
                    b.HasOne("Pickem.Domain.GameGroup", "GameGroup")
                        .WithMany()
                        .HasForeignKey("GameGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pickem.Domain.Team", "Home")
                        .WithMany()
                        .HasForeignKey("HomeId");

                    b.HasOne("Pickem.Domain.Schedule", null)
                        .WithMany("Games")
                        .HasForeignKey("ScheduleId");

                    b.HasOne("Pickem.Domain.Team", "Visitor")
                        .WithMany()
                        .HasForeignKey("VisitorId");
                });

            modelBuilder.Entity("Pickem.Domain.League", b =>
                {
                    b.HasOne("Pickem.Domain.User", null)
                        .WithMany("Leagues")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Pickem.Domain.Schedule", b =>
                {
                    b.HasOne("Pickem.Domain.SportLeague", "SportLeague")
                        .WithMany()
                        .HasForeignKey("SportLeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pickem.Domain.Team", b =>
                {
                    b.HasOne("Pickem.Domain.Division", null)
                        .WithMany("Teams")
                        .HasForeignKey("DivisionId");
                });

            modelBuilder.Entity("Pickem.Domain.UserLeague", b =>
                {
                    b.HasOne("Pickem.Domain.League", "League")
                        .WithMany("UserLeague")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pickem.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pickem.Domain.UserLeagueSchedule", b =>
                {
                    b.HasOne("Pickem.Domain.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
