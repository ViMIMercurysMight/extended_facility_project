using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Database
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
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facility_FacilityStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "FacilityStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(125)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(125)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Facility_StatusId",
                table: "Facility",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_FacilityId",
                table: "Patient",
                column: "FacilityId");



            migrationBuilder.InsertData(
             table: "FacilityStatus",
         columns: new[] { "Id", "Name" },
         values: new object[,]
         {
                { "1","Active" },
                { "2","Inactive" },
                { "3","OnHold" }
     });



            migrationBuilder.Sql(@"    CREATE PROCEDURE GetCountOfFacilities 
                                   @itemsCount INTEGER OUTPUT
                                       AS
                                           SELECT @itemsCount = COUNT(*) FROM Facility;
                                       RETURN 0;
                           "
  );



        
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Facility");

            migrationBuilder.DropTable(
                name: "FacilityStatus");

            migrationBuilder.Sql(
                @"DROP PROCEDURE GetCountOfFacilities;");

        }
    }
}
