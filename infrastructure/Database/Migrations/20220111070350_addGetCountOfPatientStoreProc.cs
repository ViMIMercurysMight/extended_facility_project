using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Database.Migrations
{
    public partial class addGetCountOfPatientStoreProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"    CREATE PROCEDURE GetCountOfPatient 
                                   @itemsCount INTEGER OUTPUT
                                       AS
                                           SELECT @itemsCount = COUNT(*) FROM Patient;
                                       RETURN 0;
                           "
);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
          @"DROP PROCEDURE GetCountOfPatient;");
        }
    }
}
