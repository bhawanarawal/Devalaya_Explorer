using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devalaya.Explorer.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTempleCreateModifyColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Temples",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Temples",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModiefiedBy",
                table: "Temples",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModiefiedDate",
                table: "Temples",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Temples");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Temples");

            migrationBuilder.DropColumn(
                name: "LastModiefiedBy",
                table: "Temples");

            migrationBuilder.DropColumn(
                name: "LastModiefiedDate",
                table: "Temples");
        }
    }
}
