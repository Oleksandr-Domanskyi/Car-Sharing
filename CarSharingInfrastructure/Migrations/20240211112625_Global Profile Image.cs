using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSharingInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GlobalProfileImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarProfileId",
                table: "Images");

            migrationBuilder.AddColumn<byte[]>(
                name: "GlobalProfileImage_DataFile",
                table: "CarProfileModels",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GlobalProfileImage_FileType",
                table: "CarProfileModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GlobalProfileImage_Name",
                table: "CarProfileModels",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GlobalProfileImage_DataFile",
                table: "CarProfileModels");

            migrationBuilder.DropColumn(
                name: "GlobalProfileImage_FileType",
                table: "CarProfileModels");

            migrationBuilder.DropColumn(
                name: "GlobalProfileImage_Name",
                table: "CarProfileModels");

            migrationBuilder.AddColumn<Guid>(
                name: "CarProfileId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
