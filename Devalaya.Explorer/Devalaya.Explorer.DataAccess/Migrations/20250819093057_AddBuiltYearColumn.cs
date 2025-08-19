using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devalaya.Explorer.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBuiltYearColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BuiltYear",
                table: "Temples",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuiltYear",
                table: "Temples");
        }
    }
}
