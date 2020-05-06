using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductTracking.DAL.Migrations
{
    public partial class AddTablesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "DeliveryWay",
                value: 2);

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "DeliveryWay", "Name" },
                values: new object[] { 3, 2, "New York" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Country", "Name", "Registered" },
                values: new object[,]
                {
                    { 1, "Grodno", "Belarus", "MilkWorld", true },
                    { 2, "Malmo", "Sweden", "StockFood", true },
                    { 3, "Tucson", "USA", "EaterCorp", true }
                });

            migrationBuilder.InsertData(
                table: "RealizationPlaces",
                columns: new[] { "Id", "CityId", "CompanyId", "Name", "WorkTime" },
                values: new object[,]
                {
                    { 1, 1, null, "Almi", 11 },
                    { 2, 1, null, "Euroopt", 10 },
                    { 4, 2, null, "Auchan", 9 },
                    { 5, 1, null, "Green", 10 }
                });

            migrationBuilder.InsertData(
                table: "RealizationPlaces",
                columns: new[] { "Id", "CityId", "CompanyId", "Name", "WorkTime" },
                values: new object[] { 3, 3, null, "Walmart", 8 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RealizationPlaces",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RealizationPlaces",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RealizationPlaces",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RealizationPlaces",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RealizationPlaces",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "DeliveryWay",
                value: 0);
        }
    }
}
