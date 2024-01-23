using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSharingInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class picture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeFile",
                table: "Images",
                newName: "FileType");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Images",
                newName: "DataFile");

            migrationBuilder.AddColumn<Guid>(
                name: "CarProfileId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarProfileId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "FileType",
                table: "Images",
                newName: "TypeFile");

            migrationBuilder.RenameColumn(
                name: "DataFile",
                table: "Images",
                newName: "Data");
        }
    }
}
