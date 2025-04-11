using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITAMS_App.Migrations
{
    /// <inheritdoc />
    public partial class FixAssetTypeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_AssetTypes_AssetType_Id",
                table: "Assets");

            migrationBuilder.RenameColumn(
                name: "AssetType_Id",
                table: "Assets",
                newName: "Asset_Type");

            migrationBuilder.RenameIndex(
                name: "IX_Assets_AssetType_Id",
                table: "Assets",
                newName: "IX_Assets_Asset_Type");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_AssetTypes_Asset_Type",
                table: "Assets",
                column: "Asset_Type",
                principalTable: "AssetTypes",
                principalColumn: "AssetType_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_AssetTypes_Asset_Type",
                table: "Assets");

            migrationBuilder.RenameColumn(
                name: "Asset_Type",
                table: "Assets",
                newName: "AssetType_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Assets_Asset_Type",
                table: "Assets",
                newName: "IX_Assets_AssetType_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_AssetTypes_AssetType_Id",
                table: "Assets",
                column: "AssetType_Id",
                principalTable: "AssetTypes",
                principalColumn: "AssetType_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
