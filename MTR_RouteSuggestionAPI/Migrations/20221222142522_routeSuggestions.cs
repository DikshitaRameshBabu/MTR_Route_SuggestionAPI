using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MTRRouteSuggestionAPI.Migrations
{
    /// <inheritdoc />
    public partial class routeSuggestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stations_RouteSuggestions_RouteSuggestionId",
                table: "Stations");

            migrationBuilder.DropIndex(
                name: "IX_Stations_RouteSuggestionId",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "RouteSuggestionId",
                table: "Stations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RouteSuggestionId",
                table: "Stations",
                type: "uniqueidentifier",
                nullable: true);

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
    }
}
