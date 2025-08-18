using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devalaya.Explorer.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImagePathOnTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Temples",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Temples",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Temples");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Temples");
        }
    }
}
