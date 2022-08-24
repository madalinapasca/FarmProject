using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmProject.Server.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Barn",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[,]
                {
                    { 1, "porumb", 4 },
                    { 2, "fan", 6 }
                });

            migrationBuilder.InsertData(
                table: "Fowls",
                columns: new[] { "Id", "Corn", "Hey", "Name", "Quantity" },
                values: new object[,]
                {
                    { 1, 2.0, null, "gaini", 10 },
                    { 2, null, null, "gaste", 0 },
                    { 3, 1.0, null, "rate", 3 },
                    { 4, null, null, "curci", 0 }
                });

            migrationBuilder.InsertData(
                table: "Quadrupeds",
                columns: new[] { "Id", "Corn", "Hey", "Name", "Quantity" },
                values: new object[,]
                {
                    { 1, 2.0, 0.0, "porci", 5 },
                    { 2, null, null, "oi", 0 },
                    { 3, null, 0.5, "bovine", 3 },
                    { 4, null, null, "cai", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Barn",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Barn",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Fowls",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fowls",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Fowls",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Fowls",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Quadrupeds",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Quadrupeds",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Quadrupeds",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Quadrupeds",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
