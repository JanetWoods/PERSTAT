using Microsoft.EntityFrameworkCore.Migrations;

namespace PERSTAT.Data.Migrations
{
    public partial class seven : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameMiddle",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameMiddle",
                table: "AspNetUsers");
        }
    }
}
