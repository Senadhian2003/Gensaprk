using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicAPIApp.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Experienct",
                table: "Doctors",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Experienct",
                table: "Doctors");
        }
    }
}
