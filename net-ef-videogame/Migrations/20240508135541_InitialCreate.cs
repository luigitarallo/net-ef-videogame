using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_ef_videogame.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "softwarehouse",
                columns: table => new
                {
                    SoftwareHouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_softwarehouse", x => x.SoftwareHouseId);
                });

            migrationBuilder.CreateTable(
                name: "videogame",
                columns: table => new
                {
                    VideogameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    release_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoftwareHouseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_videogame", x => x.VideogameId);
                    table.ForeignKey(
                        name: "FK_videogame_softwarehouse_SoftwareHouseId",
                        column: x => x.SoftwareHouseId,
                        principalTable: "softwarehouse",
                        principalColumn: "SoftwareHouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_softwarehouse_Name",
                table: "softwarehouse",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_videogame_Name",
                table: "videogame",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_videogame_SoftwareHouseId",
                table: "videogame",
                column: "SoftwareHouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "videogame");

            migrationBuilder.DropTable(
                name: "softwarehouse");
        }
    }
}
