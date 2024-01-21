using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSharingInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class somechangesofdomainmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Characteristics",
                table: "CarProfileModels",
                newName: "Characteristics_Tapicerka");

            migrationBuilder.AddColumn<string>(
                name: "Characteristics_Color",
                table: "CarProfileModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Characteristics_Felgi",
                table: "CarProfileModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Characteristics_Silnik",
                table: "CarProfileModels",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Characteristics_Color",
                table: "CarProfileModels");

            migrationBuilder.DropColumn(
                name: "Characteristics_Felgi",
                table: "CarProfileModels");

            migrationBuilder.DropColumn(
                name: "Characteristics_Silnik",
                table: "CarProfileModels");

            migrationBuilder.RenameColumn(
                name: "Characteristics_Tapicerka",
                table: "CarProfileModels",
                newName: "Characteristics");
        }
    }
}
