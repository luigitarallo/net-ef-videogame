using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_ef_videogame.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "softwarehouse",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "softwarehouse",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "softwarehouse",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "SoftwareHouseId",
                table: "softwarehouse",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_softwarehouse_Name",
                table: "softwarehouse",
                newName: "IX_softwarehouse_name");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "release_date",
                table: "videogame",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "softwarehouse",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "softwarehouse",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "softwarehouse",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "softwarehouse",
                newName: "SoftwareHouseId");

            migrationBuilder.RenameIndex(
                name: "IX_softwarehouse_name",
                table: "softwarehouse",
                newName: "IX_softwarehouse_Name");

            migrationBuilder.AlterColumn<DateTime>(
                name: "release_date",
                table: "videogame",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
