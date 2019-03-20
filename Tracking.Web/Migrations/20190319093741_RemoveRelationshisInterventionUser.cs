using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracking.Web.Migrations
{
    public partial class RemoveRelationshisInterventionUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interventions_AspNetUsers_TrackingUserId1",
                table: "Interventions");

            migrationBuilder.DropIndex(
                name: "IX_Interventions_TrackingUserId1",
                table: "Interventions");

            migrationBuilder.DropColumn(
                name: "TrackingUserId1",
                table: "Interventions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrackingUserId1",
                table: "Interventions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interventions_TrackingUserId1",
                table: "Interventions",
                column: "TrackingUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Interventions_AspNetUsers_TrackingUserId1",
                table: "Interventions",
                column: "TrackingUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
