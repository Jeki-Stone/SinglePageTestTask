﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SinglePageTestTask.Data;

namespace SinglePageTestTask.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("SinglePageTestTask.Data.UserLogin", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateLastActivity")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            DateLastActivity = new DateTime(2021, 8, 8, 10, 26, 32, 676, DateTimeKind.Local).AddTicks(2192),
                            DateRegistration = new DateTime(2021, 8, 8, 10, 26, 32, 675, DateTimeKind.Local).AddTicks(4489)
                        },
                        new
                        {
                            UserId = 2,
                            DateLastActivity = new DateTime(2021, 8, 8, 10, 26, 32, 676, DateTimeKind.Local).AddTicks(2491),
                            DateRegistration = new DateTime(2021, 8, 8, 10, 26, 32, 676, DateTimeKind.Local).AddTicks(2487)
                        },
                        new
                        {
                            UserId = 3,
                            DateLastActivity = new DateTime(2021, 8, 8, 10, 26, 32, 676, DateTimeKind.Local).AddTicks(2493),
                            DateRegistration = new DateTime(2021, 8, 8, 10, 26, 32, 676, DateTimeKind.Local).AddTicks(2492)
                        },
                        new
                        {
                            UserId = 4,
                            DateLastActivity = new DateTime(2021, 8, 8, 10, 26, 32, 676, DateTimeKind.Local).AddTicks(2496),
                            DateRegistration = new DateTime(2021, 8, 8, 10, 26, 32, 676, DateTimeKind.Local).AddTicks(2495)
                        },
                        new
                        {
                            UserId = 5,
                            DateLastActivity = new DateTime(2021, 8, 8, 10, 26, 32, 676, DateTimeKind.Local).AddTicks(2498),
                            DateRegistration = new DateTime(2021, 8, 8, 10, 26, 32, 676, DateTimeKind.Local).AddTicks(2497)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
