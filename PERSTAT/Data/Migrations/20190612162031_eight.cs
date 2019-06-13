using Microsoft.EntityFrameworkCore.Migrations;

namespace PERSTAT.Data.Migrations
{
    public partial class eight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Missions_Locations_LocationId",
                table: "Missions");



            migrationBuilder.DropColumn(
                name: "Locations.LocationId",
                table: "Missions");

            migrationBuilder.DropColumn(
               name: "LocationsLocationId",
               table: "Missions");


            migrationBuilder.CreateIndex(
                name: "IX_Assignment_LocationId",
                table: "Assignment",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Locations_LocationId",
                table: "Assignment",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Locations_LocationId",
                table: "Assignment");

           }
    }
}
