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
                name: "LocatioId",
                table: "Missions");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Missions",
                newName: "LocationsLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Missions_LocationId",
                table: "Missions",
                newName: "IX_Missions_LocationsLocationId");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Assignment",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_Locations_LocationsLocationId",
                table: "Missions",
                column: "LocationsLocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Locations_LocationId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Missions_Locations_LocationsLocationId",
                table: "Missions");

            migrationBuilder.DropIndex(
                name: "IX_Assignment_LocationId",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Assignment");

            migrationBuilder.RenameColumn(
                name: "LocationsLocationId",
                table: "Missions",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Missions_LocationsLocationId",
                table: "Missions",
                newName: "IX_Missions_LocationId");

            migrationBuilder.AddColumn<int>(
                name: "LocatioId",
                table: "Missions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_Locations_LocationId",
                table: "Missions",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
