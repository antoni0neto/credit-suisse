using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIO.Data.Migrations
{
    public partial class AddSectorOfCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SectorId",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SectorId",
                table: "Categories",
                column: "SectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Sectors_SectorId",
                table: "Categories",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Sectors_SectorId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_SectorId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SectorId",
                table: "Categories");
        }
    }
}
