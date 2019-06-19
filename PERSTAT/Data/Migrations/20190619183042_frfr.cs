using Microsoft.EntityFrameworkCore.Migrations;

namespace PERSTAT.Data.Migrations
{
    public partial class frfr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Incident_IncidentId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Locations_LocationId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Missions_MissionId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_People_PeopleId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Counties_States_StateId",
                table: "Counties");

            migrationBuilder.DropForeignKey(
                name: "FK_CountyMissions_Counties_CountyId",
                table: "CountyMissions");

            migrationBuilder.DropForeignKey(
                name: "FK_CountyMissions_Missions_MissionId",
                table: "CountyMissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Incident_IncidentType_IncidentTypeId",
                table: "Incident");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Counties_CountyId",
                table: "Locations");

           

            migrationBuilder.DropForeignKey(
                name: "FK_Organization_States_StateId",
                table: "Organization");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Organization_OrganizationId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Status_StatusId",
                table: "People");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Incident_IncidentId",
                table: "Assignment",
                column: "IncidentId",
                principalTable: "Incident",
                principalColumn: "IncidentId",
                onDelete: ReferentialAction.Restrict
                );

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Locations_LocationId",
                table: "Assignment",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict
                );

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Missions_MissionId",
                table: "Assignment",
                column: "MissionId",
                principalTable: "Missions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
                );

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_People_PeopleId",
                table: "Assignment",
                column: "PeopleId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
                );

            migrationBuilder.AddForeignKey(
                name: "FK_Counties_States_StateId",
                table: "Counties",
                column: "StateId",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict
                );

            migrationBuilder.AddForeignKey(
                name: "FK_CountyMissions_Counties_CountyId",
                table: "CountyMissions",
                column: "CountyId",
                principalTable: "Counties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
                );

            migrationBuilder.AddForeignKey(
                name: "FK_CountyMissions_Missions_MissionId",
                table: "CountyMissions",
                column: "MissionId",
                principalTable: "Missions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
                );

            migrationBuilder.AddForeignKey(
                name: "FK_Incident_IncidentType_IncidentTypeId",
                table: "Incident",
                column: "IncidentTypeId",
                principalTable: "IncidentType",
                principalColumn: "IncidentTypeId",
                onDelete: ReferentialAction.Restrict
                );

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Counties_CountyId",
                table: "Locations",
                column: "CountyId",
                principalTable: "Counties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
                );

           migrationBuilder.AddForeignKey(
                name: "FK_Organization_States_StateId",
                table: "Organization",
                column: "StateId",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict
                );

            migrationBuilder.AddForeignKey(
                name: "FK_People_Organization_OrganizationId",
                table: "People",
                column: "OrganizationId",
                principalTable: "Organization",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Restrict
                );

            migrationBuilder.AddForeignKey(
                name: "FK_People_Status_StatusId",
                table: "People",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Incident_IncidentId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Locations_LocationId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Missions_MissionId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_People_PeopleId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Counties_States_StateId",
                table: "Counties");

            migrationBuilder.DropForeignKey(
                name: "FK_CountyMissions_Counties_CountyId",
                table: "CountyMissions");

            migrationBuilder.DropForeignKey(
                name: "FK_CountyMissions_Missions_MissionId",
                table: "CountyMissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Incident_IncidentType_IncidentTypeId",
                table: "Incident");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Counties_CountyId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_States_StateId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organization_States_StateId",
                table: "Organization");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Organization_OrganizationId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Status_StatusId",
                table: "People");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Incident_IncidentId",
                table: "Assignment",
                column: "IncidentId",
                principalTable: "Incident",
                principalColumn: "IncidentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Locations_LocationId",
                table: "Assignment",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Missions_MissionId",
                table: "Assignment",
                column: "MissionId",
                principalTable: "Missions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_People_PeopleId",
                table: "Assignment",
                column: "PeopleId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Counties_States_StateId",
                table: "Counties",
                column: "StateId",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CountyMissions_Counties_CountyId",
                table: "CountyMissions",
                column: "CountyId",
                principalTable: "Counties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CountyMissions_Missions_MissionId",
                table: "CountyMissions",
                column: "MissionId",
                principalTable: "Missions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Incident_IncidentType_IncidentTypeId",
                table: "Incident",
                column: "IncidentTypeId",
                principalTable: "IncidentType",
                principalColumn: "IncidentTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Counties_CountyId",
                table: "Locations",
                column: "CountyId",
                principalTable: "Counties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_States_StateId",
                table: "Locations",
                column: "StateId",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Organization_States_StateId",
                table: "Organization",
                column: "StateId",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Organization_OrganizationId",
                table: "People",
                column: "OrganizationId",
                principalTable: "Organization",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Status_StatusId",
                table: "People",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
