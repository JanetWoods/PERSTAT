using Microsoft.EntityFrameworkCore.Migrations;

namespace PERSTAT.Data.Migrations
{
    public partial class twenty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MissionId",
                table: "Missions",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Missions",
                newName: "MissionId");
        }
    }
}
