using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShop.Data.Migrations
{
    public partial class FileSystemSpaceship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExistingFilePathsForSpaceship",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpaceshipId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExistingFilePathsForSpaceship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExistingFilePathsForSpaceship_Spaceship_SpaceshipId",
                        column: x => x.SpaceshipId,
                        principalTable: "Spaceship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExistingFilePathsForSpaceship_SpaceshipId",
                table: "ExistingFilePathsForSpaceship",
                column: "SpaceshipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExistingFilePathsForSpaceship");
        }
    }
}
