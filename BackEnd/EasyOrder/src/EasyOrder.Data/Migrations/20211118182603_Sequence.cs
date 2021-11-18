using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyOrder.Data.Migrations
{
    public partial class Sequence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "NumberOrder",
                minValue: 1L);

            migrationBuilder.CreateSequence<int>(
                name: "ProductCode",
                minValue: 1L);

            migrationBuilder.AlterColumn<int>(
                name: "Code",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR ProductCode",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR NumberOrder",
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "NumberOrder");

            migrationBuilder.DropSequence(
                name: "ProductCode");

            migrationBuilder.AlterColumn<int>(
                name: "Code",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR ProductCode");

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR NumberOrder");
        }
    }
}
