﻿// <auto-generated />
using System;
using MTR_RouteSuggestionAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MTRRouteSuggestionAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221222015018_routeSuggestion")]
    partial class routeSuggestion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MTR_RouteSuggestionAPI.Models.RouteSuggestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Distance")
                        .HasColumnType("float");

                    b.Property<string>("EndPoint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Fare")
                        .HasColumnType("float");

                    b.Property<int>("NoOfStationsInbetween")
                        .HasColumnType("int");

                    b.Property<string>("StartPoint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalNoOfStations")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RouteSuggestions");
                });

            modelBuilder.Entity("MTR_RouteSuggestionAPI.Models.Station", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RouteSuggestionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RouteSuggestionId");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("MTR_RouteSuggestionAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MTR_RouteSuggestionAPI.Models.Station", b =>
                {
                    b.HasOne("MTR_RouteSuggestionAPI.Models.RouteSuggestion", null)
                        .WithMany("Stations")
                        .HasForeignKey("RouteSuggestionId");
                });

            modelBuilder.Entity("MTR_RouteSuggestionAPI.Models.RouteSuggestion", b =>
                {
                    b.Navigation("Stations");
                });
#pragma warning restore 612, 618
        }
    }
}
