using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyOrder.Data.Migrations
{
    public partial class IdCategoryExtraRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryExtras",
                table: "CategoryExtras");

            migrationBuilder.DropIndex(
                name: "IX_CategoryExtras_IdCategory",
                table: "CategoryExtras");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CategoryExtras");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryExtras",
                table: "CategoryExtras",
                columns: new[] { "IdCategory", "IdExtra" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryExtras",
                table: "CategoryExtras");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "CategoryExtras",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryExtras",
                table: "CategoryExtras",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryExtras_IdCategory",
                table: "CategoryExtras",
                column: "IdCategory");
        }
    }
}
