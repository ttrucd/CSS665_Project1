using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITAMS_App.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Admin_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Permission = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Admin_Id);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Asset_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Asset_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Serial_Number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Purchase_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Asset_Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Employee_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Assigned_Asset_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Employee_Id);
                    table.ForeignKey(
                        name: "FK_Employees_Assets_Assigned_Asset_Id",
                        column: x => x.Assigned_Asset_Id,
                        principalTable: "Assets",
                        principalColumn: "Asset_Id");
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceRecords",
                columns: table => new
                {
                    Record_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Asset_Id = table.Column<int>(type: "int", nullable: false),
                    Issue_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Maintenance_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Technician_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRecords", x => x.Record_Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceRecords_Assets_Asset_Id",
                        column: x => x.Asset_Id,
                        principalTable: "Assets",
                        principalColumn: "Asset_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareLicense",
                columns: table => new
                {
                    License_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Software_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    License_Key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Expiration_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Assigned_Employee_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareLicense", x => x.License_Id);
                    table.ForeignKey(
                        name: "FK_SoftwareLicense_Employees_Assigned_Employee_Id",
                        column: x => x.Assigned_Employee_Id,
                        principalTable: "Employees",
                        principalColumn: "Employee_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrators_Email",
                table: "Administrators",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assets_Asset_Id",
                table: "Assets",
                column: "Asset_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_Serial_Number",
                table: "Assets",
                column: "Serial_Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Assigned_Asset_Id",
                table: "Employees",
                column: "Assigned_Asset_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                table: "Employees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecords_Asset_Id",
                table: "MaintenanceRecords",
                column: "Asset_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareLicense_Assigned_Employee_Id",
                table: "SoftwareLicense",
                column: "Assigned_Employee_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareLicense_License_Key",
                table: "SoftwareLicense",
                column: "License_Key",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "MaintenanceRecords");

            migrationBuilder.DropTable(
                name: "SoftwareLicense");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Assets");
        }
    }
}
