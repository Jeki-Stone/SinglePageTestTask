using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SinglePageTestTask.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateRegistration = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateLastActivity = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DateLastActivity", "DateRegistration" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 8, 10, 26, 32, 676, DateTimeKind.Local).AddTicks(2192), new DateTime(2021, 8, 8, 10, 26, 32, 675, DateTimeKind.Local).AddTicks(4489) },
                    { 2, new DateTime(2021, 8, 8, 10, 26, 32, 676, DateTimeKind.Local).AddTicks(2491), new DateTime(2021, 8, 8, 10, 26, 32, 676, DateTimeKind.Local).AddTicks(2487) },
                    { 3, new DateTime(2021, 8, 8, 10, 26, 32, 676, DateTimeKind.Local).AddTicks(2493), new DateTime(2021, 8, 8, 10, 26, 32, 676, DateTimeKind.Local).AddTicks(2492) },
                    { 4, new DateTime(2021, 8, 8, 10, 26, 32, 676, DateTimeKind.Local).AddTicks(2496), new DateTime(2021, 8, 8, 10, 26, 32, 676, DateTimeKind.Local).AddTicks(2495) },
                    { 5, new DateTime(2021, 8, 8, 10, 26, 32, 676, DateTimeKind.Local).AddTicks(2498), new DateTime(2021, 8, 8, 10, 26, 32, 676, DateTimeKind.Local).AddTicks(2497) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
