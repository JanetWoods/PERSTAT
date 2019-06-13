using Microsoft.EntityFrameworkCore.Migrations;

namespace PERSTAT.Data.Migrations
{
    public partial class eleven : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Missions_People_PeopleId",
                table: "Missions");

            migrationBuilder.DropIndex(
                name: "IX_Missions_PeopleId",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "PeopleId",
                table: "Missions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PeopleId",
                table: "Missions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Missions_PeopleId",
                table: "Missions",
                column: "PeopleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_People_PeopleId",
                table: "Missions",
                column: "PeopleId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
