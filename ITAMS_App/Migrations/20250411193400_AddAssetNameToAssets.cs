using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITAMS_App.Migrations
{
    /// <inheritdoc />
    public partial class AddAssetNameToAssets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Asset_Name",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Asset_Name",
                table: "Assets");
        }
    }
}
