using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyOrder.Data.Migrations
{
    public partial class UpdatingRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriesExtras");

            migrationBuilder.CreateTable(
                name: "CategoryExtras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCategory = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdExtra = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryExtras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryExtras_Categories_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryExtras_Extras_IdExtra",
                        column: x => x.IdExtra,
                        principalTable: "Extras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryExtras_IdCategory",
                table: "CategoryExtras",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryExtras_IdExtra",
                table: "CategoryExtras",
                column: "IdExtra");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryExtras");

            migrationBuilder.CreateTable(
                name: "CategoriesExtras",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExtrasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesExtras", x => new { x.CategoriesId, x.ExtrasId });
                    table.ForeignKey(
                        name: "FK_CategoriesExtras_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoriesExtras_Extras_ExtrasId",
                        column: x => x.ExtrasId,
                        principalTable: "Extras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesExtras_ExtrasId",
                table: "CategoriesExtras",
                column: "ExtrasId");
        }
    }
}
