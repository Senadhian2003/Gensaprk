using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicAPIApp.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Name", "Qualification", "Specialization" },
                values: new object[] { 1, "Raymesterio", "MBBS", "Cardiologist" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Name", "Qualification", "Specialization" },
                values: new object[] { 2, "Peter Parker", "BDS", "Dentist" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
