using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_CodeFirst.Persistence
{
    public partial class ModifyEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Departmend",
                table: "Employees",
                newName: "Department");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Department",
                table: "Employees",
                newName: "Departmend");
        }
    }
}
