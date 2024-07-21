using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VmSqlDemoApp.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImageDescription", "Name" },
                values: new object[] { 1, "xyz", "Controller" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImageDescription", "Name" },
                values: new object[] { 2, "zyx", "Headset" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
