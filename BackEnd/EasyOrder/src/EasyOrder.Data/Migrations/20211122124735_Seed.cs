using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyOrder.Data.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Active", "Name" },
                values: new object[,]
                {
                    { new Guid("36320cd1-6cce-42b0-8940-02c887431a57"), true, "Pasteis" },
                    { new Guid("dccbc2dd-1621-4654-b3f8-74fc917cbd41"), true, "Pizza" },
                    { new Guid("3c9e8004-f3f6-49d2-8568-deb44f3fb267"), true, "Burguers" }
                });

            migrationBuilder.InsertData(
                table: "Extras",
                columns: new[] { "Id", "Active", "Name" },
                values: new object[,]
                {
                    { new Guid("53634a9a-7ebd-48af-979f-b08bf7d0e217"), true, "Queijo" },
                    { new Guid("265f34a4-1535-449b-acdf-6730c4443e73"), true, "Bacon" },
                    { new Guid("7a77ed51-cdd6-4fcb-8f1d-85a1f92be96c"), true, "Orégano" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Discount", "Name", "Status", "Subtotal", "Table", "Total" },
                values: new object[,]
                {
                    { new Guid("b699095c-d87c-4ff2-bce5-f1f1c0bae9b6"), 0m, "Snow", 1, 0m, 1, 0m },
                    { new Guid("ce9a2ad2-f00f-4baa-8709-58f3ab1d71bb"), 0m, "Salem", 1, 0m, 2, 0m }
                });

            migrationBuilder.InsertData(
                table: "CategoryExtras",
                columns: new[] { "IdCategory", "IdExtra" },
                values: new object[,]
                {
                    { new Guid("36320cd1-6cce-42b0-8940-02c887431a57"), new Guid("53634a9a-7ebd-48af-979f-b08bf7d0e217") },
                    { new Guid("dccbc2dd-1621-4654-b3f8-74fc917cbd41"), new Guid("53634a9a-7ebd-48af-979f-b08bf7d0e217") },
                    { new Guid("36320cd1-6cce-42b0-8940-02c887431a57"), new Guid("265f34a4-1535-449b-acdf-6730c4443e73") },
                    { new Guid("3c9e8004-f3f6-49d2-8568-deb44f3fb267"), new Guid("265f34a4-1535-449b-acdf-6730c4443e73") },
                    { new Guid("dccbc2dd-1621-4654-b3f8-74fc917cbd41"), new Guid("7a77ed51-cdd6-4fcb-8f1d-85a1f92be96c") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "Description", "IdCategory", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("7c378c3b-b5f5-4ee3-8f1d-5ff73a89b7c1"), true, "Pastel de carne muito gostoso", new Guid("36320cd1-6cce-42b0-8940-02c887431a57"), "Pastel de carne", 10m },
                    { new Guid("3e8d9a71-0bbd-425f-bcc5-fb36048ef62c"), true, "Pastel de quejo muito gostoso", new Guid("36320cd1-6cce-42b0-8940-02c887431a57"), "Pastel de queijo", 15m },
                    { new Guid("eef85ecb-c7ff-46c6-89a8-345ab93669a6"), true, "Pizza muito gostoso", new Guid("dccbc2dd-1621-4654-b3f8-74fc917cbd41"), "Pizza", 45m }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "IdOrder", "IdProduct", "Observation", "Quantity", "Status" },
                values: new object[] { new Guid("ce9a2ad2-f00f-4baa-8709-58f3ab1d71bb"), new Guid("b699095c-d87c-4ff2-bce5-f1f1c0bae9b6"), new Guid("7c378c3b-b5f5-4ee3-8f1d-5ff73a89b7c1"), null, 2, 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "IdOrder", "IdProduct", "Observation", "Quantity", "Status" },
                values: new object[] { new Guid("2aea14eb-dd41-4ce6-ba90-ad3a82553e25"), new Guid("b699095c-d87c-4ff2-bce5-f1f1c0bae9b6"), new Guid("3e8d9a71-0bbd-425f-bcc5-fb36048ef62c"), null, 2, 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "IdOrder", "IdProduct", "Observation", "Quantity", "Status" },
                values: new object[] { new Guid("b9d81522-7e29-47b1-bc63-b80fa6241872"), new Guid("ce9a2ad2-f00f-4baa-8709-58f3ab1d71bb"), new Guid("eef85ecb-c7ff-46c6-89a8-345ab93669a6"), null, 2, 1 });

            migrationBuilder.InsertData(
                table: "ItemExtras",
                columns: new[] { "IdExtra", "IdItem" },
                values: new object[] { new Guid("53634a9a-7ebd-48af-979f-b08bf7d0e217"), new Guid("ce9a2ad2-f00f-4baa-8709-58f3ab1d71bb") });

            migrationBuilder.InsertData(
                table: "ItemExtras",
                columns: new[] { "IdExtra", "IdItem" },
                values: new object[] { new Guid("53634a9a-7ebd-48af-979f-b08bf7d0e217"), new Guid("2aea14eb-dd41-4ce6-ba90-ad3a82553e25") });

            migrationBuilder.InsertData(
                table: "ItemExtras",
                columns: new[] { "IdExtra", "IdItem" },
                values: new object[] { new Guid("7a77ed51-cdd6-4fcb-8f1d-85a1f92be96c"), new Guid("b9d81522-7e29-47b1-bc63-b80fa6241872") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryExtras",
                keyColumns: new[] { "IdCategory", "IdExtra" },
                keyValues: new object[] { new Guid("36320cd1-6cce-42b0-8940-02c887431a57"), new Guid("265f34a4-1535-449b-acdf-6730c4443e73") });

            migrationBuilder.DeleteData(
                table: "CategoryExtras",
                keyColumns: new[] { "IdCategory", "IdExtra" },
                keyValues: new object[] { new Guid("36320cd1-6cce-42b0-8940-02c887431a57"), new Guid("53634a9a-7ebd-48af-979f-b08bf7d0e217") });

            migrationBuilder.DeleteData(
                table: "CategoryExtras",
                keyColumns: new[] { "IdCategory", "IdExtra" },
                keyValues: new object[] { new Guid("3c9e8004-f3f6-49d2-8568-deb44f3fb267"), new Guid("265f34a4-1535-449b-acdf-6730c4443e73") });

            migrationBuilder.DeleteData(
                table: "CategoryExtras",
                keyColumns: new[] { "IdCategory", "IdExtra" },
                keyValues: new object[] { new Guid("dccbc2dd-1621-4654-b3f8-74fc917cbd41"), new Guid("53634a9a-7ebd-48af-979f-b08bf7d0e217") });

            migrationBuilder.DeleteData(
                table: "CategoryExtras",
                keyColumns: new[] { "IdCategory", "IdExtra" },
                keyValues: new object[] { new Guid("dccbc2dd-1621-4654-b3f8-74fc917cbd41"), new Guid("7a77ed51-cdd6-4fcb-8f1d-85a1f92be96c") });

            migrationBuilder.DeleteData(
                table: "ItemExtras",
                keyColumns: new[] { "IdExtra", "IdItem" },
                keyValues: new object[] { new Guid("53634a9a-7ebd-48af-979f-b08bf7d0e217"), new Guid("2aea14eb-dd41-4ce6-ba90-ad3a82553e25") });

            migrationBuilder.DeleteData(
                table: "ItemExtras",
                keyColumns: new[] { "IdExtra", "IdItem" },
                keyValues: new object[] { new Guid("7a77ed51-cdd6-4fcb-8f1d-85a1f92be96c"), new Guid("b9d81522-7e29-47b1-bc63-b80fa6241872") });

            migrationBuilder.DeleteData(
                table: "ItemExtras",
                keyColumns: new[] { "IdExtra", "IdItem" },
                keyValues: new object[] { new Guid("53634a9a-7ebd-48af-979f-b08bf7d0e217"), new Guid("ce9a2ad2-f00f-4baa-8709-58f3ab1d71bb") });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3c9e8004-f3f6-49d2-8568-deb44f3fb267"));

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: new Guid("265f34a4-1535-449b-acdf-6730c4443e73"));

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: new Guid("53634a9a-7ebd-48af-979f-b08bf7d0e217"));

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: new Guid("7a77ed51-cdd6-4fcb-8f1d-85a1f92be96c"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aea14eb-dd41-4ce6-ba90-ad3a82553e25"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("b9d81522-7e29-47b1-bc63-b80fa6241872"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ce9a2ad2-f00f-4baa-8709-58f3ab1d71bb"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("b699095c-d87c-4ff2-bce5-f1f1c0bae9b6"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("ce9a2ad2-f00f-4baa-8709-58f3ab1d71bb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3e8d9a71-0bbd-425f-bcc5-fb36048ef62c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7c378c3b-b5f5-4ee3-8f1d-5ff73a89b7c1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eef85ecb-c7ff-46c6-89a8-345ab93669a6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("36320cd1-6cce-42b0-8940-02c887431a57"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dccbc2dd-1621-4654-b3f8-74fc917cbd41"));
        }
    }
}
