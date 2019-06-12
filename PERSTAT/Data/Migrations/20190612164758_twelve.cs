using Microsoft.EntityFrameworkCore.Migrations;

namespace PERSTAT.Data.Migrations
{
    public partial class twelve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Missions_MissionsMissionId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_MissionsMissionId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "MissionsMissionId",
                table: "People");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MissionsMissionId",
                table: "People",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_MissionsMissionId",
                table: "People",
                column: "MissionsMissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Missions_MissionsMissionId",
                table: "People",
                column: "MissionsMissionId",
                principalTable: "Missions",
                principalColumn: "MissionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
