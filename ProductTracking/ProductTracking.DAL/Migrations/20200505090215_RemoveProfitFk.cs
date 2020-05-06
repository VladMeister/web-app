using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductTracking.DAL.Migrations
{
    public partial class RemoveProfitFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfitKf",
                table: "Cities");

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "DeliveryWay", "Name" },
                values: new object[] { 1, 0, "Grodno" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "DeliveryWay", "Name" },
                values: new object[] { 2, 0, "Stockholm" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<float>(
                name: "ProfitKf",
                table: "Cities",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
