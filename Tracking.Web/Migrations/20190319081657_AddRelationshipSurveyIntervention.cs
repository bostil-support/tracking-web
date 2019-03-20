using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracking.Web.Migrations
{
    public partial class AddRelationshipSurveyIntervention : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InterventionId",
                table: "Surveys",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_InterventionId",
                table: "Surveys",
                column: "InterventionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_Interventions_InterventionId",
                table: "Surveys",
                column: "InterventionId",
                principalTable: "Interventions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_Interventions_InterventionId",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_InterventionId",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "InterventionId",
                table: "Surveys");
        }
    }
}
