using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITAMS_App.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAssignedEmployeeFromSoftwareLicense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoftwareLicense_Employees_Assigned_Employee_Id",
                table: "SoftwareLicense");

            migrationBuilder.DropIndex(
                name: "IX_SoftwareLicense_Assigned_Employee_Id",
                table: "SoftwareLicense");

            migrationBuilder.DropColumn(
                name: "Assigned_Employee_Id",
                table: "SoftwareLicense");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Assigned_Employee_Id",
                table: "SoftwareLicense",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareLicense_Assigned_Employee_Id",
                table: "SoftwareLicense",
                column: "Assigned_Employee_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SoftwareLicense_Employees_Assigned_Employee_Id",
                table: "SoftwareLicense",
                column: "Assigned_Employee_Id",
                principalTable: "Employees",
                principalColumn: "Employee_Id");
        }
    }
}
