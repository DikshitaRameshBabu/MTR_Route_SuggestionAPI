using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MTRRouteSuggestionAPI.Migrations
{
    /// <inheritdoc />
    public partial class routeSuggestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RouteSuggestionId",
                table: "Stations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RouteSuggestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalNoOfStations = table.Column<int>(type: "int", nullable: false),
                    NoOfStationsInbetween = table.Column<int>(type: "int", nullable: false),
                    Fare = table.Column<double>(type: "float", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteSuggestions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stations_RouteSuggestionId",
                table: "Stations",
                column: "RouteSuggestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stations_RouteSuggestions_RouteSuggestionId",
                table: "Stations",
                column: "RouteSuggestionId",
                principalTable: "RouteSuggestions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stations_RouteSuggestions_RouteSuggestionId",
                table: "Stations");

            migrationBuilder.DropTable(
                name: "RouteSuggestions");

            migrationBuilder.DropIndex(
                name: "IX_Stations_RouteSuggestionId",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "RouteSuggestionId",
                table: "Stations");
        }
    }
}
