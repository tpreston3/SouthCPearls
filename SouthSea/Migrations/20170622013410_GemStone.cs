using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SouthSea.Migrations
{
    public partial class GemStone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GemStone",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    TypeStone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GemStone", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GemStone_Merchandise_ID",
                        column: x => x.ID,
                        principalTable: "Merchandise",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GemStone");
        }
    }
}
