using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Data.Migrations
{
    public partial class AddUserAlbumRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Albums_UserId",
                table: "Albums",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Users_UserId",
                table: "Albums",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Users_UserId",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_UserId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Albums");
        }
    }
}
