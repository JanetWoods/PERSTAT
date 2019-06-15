using Microsoft.EntityFrameworkCore.Migrations;

namespace PERSTAT.Data.Migrations
{
    public partial class thth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
  
        
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Missions_Locations_LocationsLocationId",
                table: "Missions");

            migrationBuilder.DropIndex(
                name: "IX_Missions_LocationsLocationId",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "LocationsLocationId",
                table: "Missions");
        }
    }
}
