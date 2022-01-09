using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Database.Migrations
{
    public partial class updatedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facility_FacilityStatus_StatusId",
                table: "Facility");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Facility_FacilityId",
                table: "Patient");

            migrationBuilder.AlterColumn<int>(
                name: "FacilityId",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Facility",
                type: "int",
                nullable: false,
                defaultValue: 2,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Facility_FacilityStatus_StatusId",
                table: "Facility",
                column: "StatusId",
                principalTable: "FacilityStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Facility_FacilityId",
                table: "Patient",
                column: "FacilityId",
                principalTable: "Facility",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facility_FacilityStatus_StatusId",
                table: "Facility");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Facility_FacilityId",
                table: "Patient");

            migrationBuilder.AlterColumn<int>(
                name: "FacilityId",
                table: "Patient",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Facility",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 2);

            migrationBuilder.AddForeignKey(
                name: "FK_Facility_FacilityStatus_StatusId",
                table: "Facility",
                column: "StatusId",
                principalTable: "FacilityStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Facility_FacilityId",
                table: "Patient",
                column: "FacilityId",
                principalTable: "Facility",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
