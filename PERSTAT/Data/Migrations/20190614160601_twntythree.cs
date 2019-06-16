using Microsoft.EntityFrameworkCore.Migrations;

namespace PERSTAT.Data.Migrations
{
    public partial class twntythree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MissionsId",
                table: "People",
                nullable: true);

           
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Assignment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_MissionsId",
                table: "People",
                column: "MissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_StatusId",
                table: "Assignment",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Status_StatusId",
                table: "Assignment",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);

           migrationBuilder.AddForeignKey(
                name: "FK_People_Missions_MissionsId",
                table: "People",
                column: "MissionsId",
                principalTable: "Missions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Status_StatusId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Missions_Locations_LocationsLocationId",
                table: "Missions");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Missions_MissionsId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_MissionsId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_Missions_LocationsLocationId",
                table: "Missions");

            migrationBuilder.DropIndex(
                name: "IX_Assignment_StatusId",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "MissionsId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "LocationsLocationId",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Assignment");
        }
    }
}
