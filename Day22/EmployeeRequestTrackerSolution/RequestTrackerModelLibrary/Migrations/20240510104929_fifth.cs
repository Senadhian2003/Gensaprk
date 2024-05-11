using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestTrackerModelLibrary.Migrations
{
    public partial class fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestSolution_Employees_SolvedBy",
                table: "RequestSolution");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestSolution_Requests_RequestId",
                table: "RequestSolution");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionFeedback_Employees_FeedbackBy",
                table: "SolutionFeedback");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionFeedback_RequestSolution_SolutionId",
                table: "SolutionFeedback");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolutionFeedback",
                table: "SolutionFeedback");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestSolution",
                table: "RequestSolution");

            migrationBuilder.RenameTable(
                name: "SolutionFeedback",
                newName: "Feedbacks");

            migrationBuilder.RenameTable(
                name: "RequestSolution",
                newName: "RequestSolutions");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionFeedback_SolutionId",
                table: "Feedbacks",
                newName: "IX_Feedbacks_SolutionId");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionFeedback_FeedbackBy",
                table: "Feedbacks",
                newName: "IX_Feedbacks_FeedbackBy");

            migrationBuilder.RenameIndex(
                name: "IX_RequestSolution_SolvedBy",
                table: "RequestSolutions",
                newName: "IX_RequestSolutions_SolvedBy");

            migrationBuilder.RenameIndex(
                name: "IX_RequestSolution_RequestId",
                table: "RequestSolutions",
                newName: "IX_RequestSolutions_RequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks",
                column: "FeedbackId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestSolutions",
                table: "RequestSolutions",
                column: "SolutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Employees_FeedbackBy",
                table: "Feedbacks",
                column: "FeedbackBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_RequestSolutions_SolutionId",
                table: "Feedbacks",
                column: "SolutionId",
                principalTable: "RequestSolutions",
                principalColumn: "SolutionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSolutions_Employees_SolvedBy",
                table: "RequestSolutions",
                column: "SolvedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSolutions_Requests_RequestId",
                table: "RequestSolutions",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Employees_FeedbackBy",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_RequestSolutions_SolutionId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestSolutions_Employees_SolvedBy",
                table: "RequestSolutions");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestSolutions_Requests_RequestId",
                table: "RequestSolutions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestSolutions",
                table: "RequestSolutions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks");

            migrationBuilder.RenameTable(
                name: "RequestSolutions",
                newName: "RequestSolution");

            migrationBuilder.RenameTable(
                name: "Feedbacks",
                newName: "SolutionFeedback");

            migrationBuilder.RenameIndex(
                name: "IX_RequestSolutions_SolvedBy",
                table: "RequestSolution",
                newName: "IX_RequestSolution_SolvedBy");

            migrationBuilder.RenameIndex(
                name: "IX_RequestSolutions_RequestId",
                table: "RequestSolution",
                newName: "IX_RequestSolution_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_SolutionId",
                table: "SolutionFeedback",
                newName: "IX_SolutionFeedback_SolutionId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_FeedbackBy",
                table: "SolutionFeedback",
                newName: "IX_SolutionFeedback_FeedbackBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestSolution",
                table: "RequestSolution",
                column: "SolutionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolutionFeedback",
                table: "SolutionFeedback",
                column: "FeedbackId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionFeedback_Employees_FeedbackBy",
                table: "SolutionFeedback",
                column: "FeedbackBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionFeedback_RequestSolution_SolutionId",
                table: "SolutionFeedback",
                column: "SolutionId",
                principalTable: "RequestSolution",
                principalColumn: "SolutionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
