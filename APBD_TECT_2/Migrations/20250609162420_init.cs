using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APBD_TECT_2.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Racers",
                columns: table => new
                {
                    RacerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racers", x => x.RacerId);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    RaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.RaceId);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    TrackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LengthinKm = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.TrackId);
                });

            migrationBuilder.CreateTable(
                name: "TrackRace",
                columns: table => new
                {
                    TrackRaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    Laps = table.Column<int>(type: "int", nullable: false),
                    BestTimeInSeconds = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackRace", x => x.TrackRaceId);
                    table.ForeignKey(
                        name: "FK_TrackRace_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "RaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrackRace_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceParticipation",
                columns: table => new
                {
                    RacerId = table.Column<int>(type: "int", nullable: false),
                    TrackRaceId = table.Column<int>(type: "int", nullable: false),
                    FinishTimeInSeconds = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceParticipation", x => new { x.TrackRaceId, x.RacerId });
                    table.ForeignKey(
                        name: "FK_RaceParticipation_Racers_RacerId",
                        column: x => x.RacerId,
                        principalTable: "Racers",
                        principalColumn: "RacerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceParticipation_TrackRace_TrackRaceId",
                        column: x => x.TrackRaceId,
                        principalTable: "TrackRace",
                        principalColumn: "TrackRaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Racers",
                columns: new[] { "RacerId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Dmitry", "Barmuta" },
                    { 2, "Michal", "Pazio" },
                    { 3, "Danyil", "Danilian" },
                    { 4, "Oleksandr", "Biktimirov" }
                });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "RaceId", "Date", "Name", "location" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 8, 18, 24, 19, 880, DateTimeKind.Local).AddTicks(8210), "Bulbozavr", "Misnk" },
                    { 2, new DateTime(2025, 5, 30, 18, 24, 19, 880, DateTimeKind.Local).AddTicks(8270), "Pikachi", "Gomel" }
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "TrackId", "LengthinKm", "Name" },
                values: new object[,]
                {
                    { 1, 100m, "Despacito" },
                    { 2, 100m, "Despacito" }
                });

            migrationBuilder.InsertData(
                table: "TrackRace",
                columns: new[] { "TrackRaceId", "BestTimeInSeconds", "Laps", "RaceId", "TrackId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1 },
                    { 2, 10, 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "RaceParticipation",
                columns: new[] { "RacerId", "TrackRaceId", "FinishTimeInSeconds", "Position" },
                values: new object[,]
                {
                    { 1, 1, 10, 1 },
                    { 2, 2, 20, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaceParticipation_RacerId",
                table: "RaceParticipation",
                column: "RacerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackRace_RaceId",
                table: "TrackRace",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackRace_TrackId",
                table: "TrackRace",
                column: "TrackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaceParticipation");

            migrationBuilder.DropTable(
                name: "Racers");

            migrationBuilder.DropTable(
                name: "TrackRace");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "Tracks");
        }
    }
}
