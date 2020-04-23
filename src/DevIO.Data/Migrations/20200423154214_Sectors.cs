using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIO.Data.Migrations
{
    public partial class Sectors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SectorId",
                table: "Trades",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trades_SectorId",
                table: "Trades",
                column: "SectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_Sectors_SectorId",
                table: "Trades",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trades_Sectors_SectorId",
                table: "Trades");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.DropIndex(
                name: "IX_Trades_SectorId",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "SectorId",
                table: "Trades");
        }
    }
}
