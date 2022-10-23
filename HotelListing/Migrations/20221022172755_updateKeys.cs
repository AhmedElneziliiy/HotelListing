using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelListing.Migrations
{
    public partial class updateKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40de2288-f47c-4551-ae2c-42bdb164891a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ccd52e93-55a9-4c42-9396-60b8694b2556");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ee4f2d97-e930-4d99-a014-61e986f3935a", "b4ee9245-010a-42c7-ad27-296de340ddb7", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "edc69968-5d80-4993-a713-6cdc31cd1139", "194abf66-44af-4161-be96-89f6d0977a61", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edc69968-5d80-4993-a713-6cdc31cd1139");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee4f2d97-e930-4d99-a014-61e986f3935a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "40de2288-f47c-4551-ae2c-42bdb164891a", "ff7d6012-357e-45cb-9267-3c3c7984fba2", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ccd52e93-55a9-4c42-9396-60b8694b2556", "c4c28b09-811f-4aff-a704-6b98c4f3bb90", "Administrator", "ADMINISTRATOR" });
        }
    }
}
