using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Crawler.Models.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "crawlerlog",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    lastrun = table.Column<DateTime>(type: "timestamp(3) without time zone", nullable: false),
                    sourceurl = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_crawlerlog", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "crawlingsettings",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    value = table.Column<string>(maxLength: 100, nullable: false),
                    type = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_crawlingsettings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "crawlingstate",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    lastdate = table.Column<DateTime>(type: "timestamp(3) without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_crawlingstate", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "lotteryinfo",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    date = table.Column<DateTime>(type: "timestamp(3) without time zone", nullable: true),
                    province = table.Column<string>(maxLength: 512, nullable: true),
                    number = table.Column<string>(maxLength: 512, nullable: true),
                    matchtype = table.Column<short>(nullable: true),
                    createdAt = table.Column<DateTime>(type: "timestamp(3) without time zone", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "timestamp(3) without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lotteryinfo", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "crawlerlog");

            migrationBuilder.DropTable(
                name: "crawlingsettings");

            migrationBuilder.DropTable(
                name: "crawlingstate");

            migrationBuilder.DropTable(
                name: "lotteryinfo");
        }
    }
}
