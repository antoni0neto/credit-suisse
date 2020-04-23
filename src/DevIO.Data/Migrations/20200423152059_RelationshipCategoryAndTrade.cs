using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIO.Data.Migrations
{
    public partial class RelationshipCategoryAndTrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Trades",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trades_CategoryId",
                table: "Trades",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_Categories_CategoryId",
                table: "Trades",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trades_Categories_CategoryId",
                table: "Trades");

            migrationBuilder.DropIndex(
                name: "IX_Trades_CategoryId",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Trades");
        }
    }
}
