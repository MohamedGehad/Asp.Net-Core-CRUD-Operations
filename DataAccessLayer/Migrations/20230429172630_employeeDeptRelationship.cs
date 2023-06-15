using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class employeeDeptRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "departmentId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Deprtmetnid",
                table: "departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_departmentId",
                table: "Employees",
                column: "departmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_departments_departmentId",
                table: "Employees",
                column: "departmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_departments_departmentId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_departmentId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "departmentId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Deprtmetnid",
                table: "departments");
        }
    }
}
