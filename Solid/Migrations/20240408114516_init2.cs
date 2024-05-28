using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solid.Data.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRole_employees_EmployeeId",
                table: "EmployeeRole");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRole_roles_RoleId",
                table: "EmployeeRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeRole",
                table: "EmployeeRole");

            migrationBuilder.RenameTable(
                name: "EmployeeRole",
                newName: "EmployeeRoles");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeRole_RoleId",
                table: "EmployeeRoles",
                newName: "IX_employeeRoles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employeeRoles",
                table: "EmployeeRoles",
                columns: new[] { "EmployeeId", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_employeeRoles_employees_EmployeeId",
                table: "EmployeeRoles",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employeeRoles_roles_RoleId",
                table: "EmployeeRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employeeRoles_employees_EmployeeId",
                table: "EmployeeRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_employeeRoles_roles_RoleId",
                table: "EmployeeRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employeeRoles",
                table: "EmployeeRoles");

            migrationBuilder.RenameTable(
                name: "EmployeeRoles",
                newName: "EmployeeRole");

            migrationBuilder.RenameIndex(
                name: "IX_employeeRoles_RoleId",
                table: "EmployeeRole",
                newName: "IX_EmployeeRole_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeRole",
                table: "EmployeeRole",
                columns: new[] { "EmployeeId", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRole_employees_EmployeeId",
                table: "EmployeeRole",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRole_roles_RoleId",
                table: "EmployeeRole",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
