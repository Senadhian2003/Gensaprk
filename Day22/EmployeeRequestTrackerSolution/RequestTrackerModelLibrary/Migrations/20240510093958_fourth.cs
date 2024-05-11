using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestTrackerModelLibrary.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestSolution_Employees_SolvedBy",
                table: "RequestSolution");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestSolution_Requests_RequestId",
                table: "RequestSolution");

            migrationBuilder.CreateTable(
                name: "SolutionFeedback",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolutionId = table.Column<int>(type: "int", nullable: false),
                    FeedbackBy = table.Column<int>(type: "int", nullable: false),
                    FeedbackDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolutionFeedback", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_SolutionFeedback_Employees_FeedbackBy",
                        column: x => x.FeedbackBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SolutionFeedback_RequestSolution_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "RequestSolution",
                        principalColumn: "SolutionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolutionFeedback_FeedbackBy",
                table: "SolutionFeedback",
                column: "FeedbackBy");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionFeedback_SolutionId",
                table: "SolutionFeedback",
                column: "SolutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSolution_Employees_SolvedBy",
                table: "RequestSolution",
                column: "SolvedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSolution_Requests_RequestId",
                table: "RequestSolution",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestSolution_Employees_SolvedBy",
                table: "RequestSolution");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestSolution_Requests_RequestId",
                table: "RequestSolution");

            migrationBuilder.DropTable(
                name: "SolutionFeedback");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSolution_Employees_SolvedBy",
                table: "RequestSolution",
                column: "SolvedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSolution_Requests_RequestId",
                table: "RequestSolution",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
