using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FacilityStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facility",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false, defaultValue: 2)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility", x => x.Id);
                    table.UniqueConstraint("AK_Facility_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Facility_FacilityStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "FacilityStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    FacilityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Facility_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "FacilityStatus",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "InActive" });

            migrationBuilder.InsertData(
                table: "FacilityStatus",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Active" });

            migrationBuilder.InsertData(
                table: "FacilityStatus",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "OnHold" });

            migrationBuilder.CreateIndex(
                name: "IX_Facility_StatusId",
                table: "Facility",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_FacilityId",
                table: "Patient",
                column: "FacilityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Facility");

            migrationBuilder.DropTable(
                name: "FacilityStatus");
        }
    }
}
