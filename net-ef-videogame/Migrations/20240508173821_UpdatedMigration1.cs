using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_ef_videogame.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "videogame",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Overview",
                table: "videogame",
                newName: "description");

            migrationBuilder.RenameIndex(
                name: "IX_videogame_Name",
                table: "videogame",
                newName: "IX_videogame_name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "softwarehouse",
                newName: "SoftwareHouseId");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "release_date",
                table: "videogame",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "videogame",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "videogame",
                newName: "Overview");

            migrationBuilder.RenameIndex(
                name: "IX_videogame_name",
                table: "videogame",
                newName: "IX_videogame_Name");

            migrationBuilder.RenameColumn(
                name: "SoftwareHouseId",
                table: "softwarehouse",
                newName: "id");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "release_date",
                table: "videogame",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "Date");
        }
    }
}
