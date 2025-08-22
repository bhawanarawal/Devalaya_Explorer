using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devalaya.Explorer.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameFavourite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favoutites_Temples_TempleId",
                table: "Favoutites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favoutites",
                table: "Favoutites");

            migrationBuilder.RenameTable(
                name: "Favoutites",
                newName: "Favourites");

            migrationBuilder.RenameIndex(
                name: "IX_Favoutites_TempleId",
                table: "Favourites",
                newName: "IX_Favourites_TempleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favourites",
                table: "Favourites",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_Temples_TempleId",
                table: "Favourites",
                column: "TempleId",
                principalTable: "Temples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_Temples_TempleId",
                table: "Favourites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favourites",
                table: "Favourites");

            migrationBuilder.RenameTable(
                name: "Favourites",
                newName: "Favoutites");

            migrationBuilder.RenameIndex(
                name: "IX_Favourites_TempleId",
                table: "Favoutites",
                newName: "IX_Favoutites_TempleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favoutites",
                table: "Favoutites",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favoutites_Temples_TempleId",
                table: "Favoutites",
                column: "TempleId",
                principalTable: "Temples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
