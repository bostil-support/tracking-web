using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracking.Web.Data.Migrations
{
    public partial class UpdateIntervention : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CensusUserId",
                table: "Interventions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interventions_CensusUserId",
                table: "Interventions",
                column: "CensusUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interventions_AspNetUsers_CensusUserId",
                table: "Interventions",
                column: "CensusUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interventions_AspNetUsers_CensusUserId",
                table: "Interventions");

            migrationBuilder.DropIndex(
                name: "IX_Interventions_CensusUserId",
                table: "Interventions");

            migrationBuilder.DropColumn(
                name: "CensusUserId",
                table: "Interventions");
        }
    }
}
