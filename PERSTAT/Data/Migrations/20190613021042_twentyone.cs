using Microsoft.EntityFrameworkCore.Migrations;

namespace PERSTAT.Data.Migrations
{
    public partial class twentyone : Migration
    {
   
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationsLocationId",
                table: "Missions");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
