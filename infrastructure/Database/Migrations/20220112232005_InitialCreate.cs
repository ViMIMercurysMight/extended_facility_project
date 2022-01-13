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
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false, defaultValue: 2)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facilities_FacilityStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "FacilityStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
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
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
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
                name: "IX_Facilities_StatusId",
                table: "Facilities",
                column: "StatusId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_FacilityId",
                table: "Patients",
                column: "FacilityId",
                unique: true,
                filter: "[FacilityId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "FacilityStatus");
        }
    }
}
