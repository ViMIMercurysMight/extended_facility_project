using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Database.Migrations
{
    public partial class UpdateRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patients_FacilityId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Facilities_StatusId",
                table: "Facilities");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_FacilityId",
                table: "Patients",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_StatusId",
                table: "Facilities",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patients_FacilityId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Facilities_StatusId",
                table: "Facilities");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_FacilityId",
                table: "Patients",
                column: "FacilityId",
                unique: true,
                filter: "[FacilityId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_StatusId",
                table: "Facilities",
                column: "StatusId",
                unique: true);
        }
    }
}
