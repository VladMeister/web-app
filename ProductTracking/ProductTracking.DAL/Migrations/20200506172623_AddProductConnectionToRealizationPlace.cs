using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductTracking.DAL.Migrations
{
    public partial class AddProductConnectionToRealizationPlace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealizationPlaces_Companies_CompanyId",
                table: "RealizationPlaces");

            migrationBuilder.DropIndex(
                name: "IX_RealizationPlaces_CompanyId",
                table: "RealizationPlaces");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "RealizationPlaces");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RealizationPlaces",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "RealizationPlaceId",
                table: "Products",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_RealizationPlaces_Name",
                table: "RealizationPlaces",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_RealizationPlaceId",
                table: "Products",
                column: "RealizationPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Name",
                table: "Companies",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_RealizationPlaces_RealizationPlaceId",
                table: "Products",
                column: "RealizationPlaceId",
                principalTable: "RealizationPlaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_RealizationPlaces_RealizationPlaceId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_RealizationPlaces_Name",
                table: "RealizationPlaces");

            migrationBuilder.DropIndex(
                name: "IX_Products_RealizationPlaceId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Companies_Name",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "RealizationPlaceId",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RealizationPlaces",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "RealizationPlaces",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_RealizationPlaces_CompanyId",
                table: "RealizationPlaces",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_RealizationPlaces_Companies_CompanyId",
                table: "RealizationPlaces",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
