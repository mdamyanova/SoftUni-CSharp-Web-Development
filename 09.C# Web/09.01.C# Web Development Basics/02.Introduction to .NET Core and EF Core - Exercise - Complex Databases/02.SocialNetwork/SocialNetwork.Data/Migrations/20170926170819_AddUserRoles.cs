using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Data.Migrations
{
    public partial class AddUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumPicture_Albums_AlbumId",
                table: "AlbumPicture");

            migrationBuilder.DropForeignKey(
                name: "FK_AlbumPicture_Pictures_PictureId",
                table: "AlbumPicture");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Users_UserId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_AlbumTag_Albums_AlbumId",
                table: "AlbumTag");

            migrationBuilder.DropForeignKey(
                name: "FK_AlbumTag_Tags_TagId",
                table: "AlbumTag");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnerAlbum_Albums_AlbumId",
                table: "OwnerAlbum");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnerAlbum_Users_UserId",
                table: "OwnerAlbum");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OwnerAlbum",
                table: "OwnerAlbum");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OwnerAlbum");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "OwnerAlbum",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OwnerAlbum",
                table: "OwnerAlbum",
                columns: new[] { "OwnerId", "AlbumId" });

            migrationBuilder.CreateTable(
                name: "ViewerAlbum",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "int", nullable: false),
                    ViewerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewerAlbum", x => new { x.AlbumId, x.ViewerId });
                    table.ForeignKey(
                        name: "FK_ViewerAlbum_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ViewerAlbum_Users_ViewerId",
                        column: x => x.ViewerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ViewerAlbum_ViewerId",
                table: "ViewerAlbum",
                column: "ViewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumPicture_Albums_AlbumId",
                table: "AlbumPicture",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumPicture_Pictures_PictureId",
                table: "AlbumPicture",
                column: "PictureId",
                principalTable: "Pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Users_UserId",
                table: "Albums",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumTag_Albums_AlbumId",
                table: "AlbumTag",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumTag_Tags_TagId",
                table: "AlbumTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerAlbum_Albums_AlbumId",
                table: "OwnerAlbum",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerAlbum_Users_OwnerId",
                table: "OwnerAlbum",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumPicture_Albums_AlbumId",
                table: "AlbumPicture");

            migrationBuilder.DropForeignKey(
                name: "FK_AlbumPicture_Pictures_PictureId",
                table: "AlbumPicture");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Users_UserId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_AlbumTag_Albums_AlbumId",
                table: "AlbumTag");

            migrationBuilder.DropForeignKey(
                name: "FK_AlbumTag_Tags_TagId",
                table: "AlbumTag");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnerAlbum_Albums_AlbumId",
                table: "OwnerAlbum");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnerAlbum_Users_OwnerId",
                table: "OwnerAlbum");

            migrationBuilder.DropTable(
                name: "ViewerAlbum");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OwnerAlbum",
                table: "OwnerAlbum");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "OwnerAlbum");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "OwnerAlbum",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OwnerAlbum",
                table: "OwnerAlbum",
                columns: new[] { "UserId", "AlbumId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumPicture_Albums_AlbumId",
                table: "AlbumPicture",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumPicture_Pictures_PictureId",
                table: "AlbumPicture",
                column: "PictureId",
                principalTable: "Pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Users_UserId",
                table: "Albums",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumTag_Albums_AlbumId",
                table: "AlbumTag",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumTag_Tags_TagId",
                table: "AlbumTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerAlbum_Albums_AlbumId",
                table: "OwnerAlbum",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerAlbum_Users_UserId",
                table: "OwnerAlbum",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
