using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentApp.WebAPI.Migrations
{
    public partial class StoredProcedureGetStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var procedure = "CREATE PROCEDURE GetStudentsProcedure AS SELECT * FROM Students";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropProcSql = "DROP PROC GetStudentsProcedure";
            migrationBuilder.Sql(dropProcSql);
        }
    }
}
