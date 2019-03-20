using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracking.Web.Migrations
{
    public partial class AddRiskTypeToSurvey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RiskTypeId",
                table: "Surveys",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_RiskTypeId",
                table: "Surveys",
                column: "RiskTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_RiskTypes_RiskTypeId",
                table: "Surveys",
                column: "RiskTypeId",
                principalTable: "RiskTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_RiskTypes_RiskTypeId",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_RiskTypeId",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "RiskTypeId",
                table: "Surveys");
        }
    }
}
