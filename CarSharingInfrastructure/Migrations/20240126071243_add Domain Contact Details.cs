using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSharingInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addDomainContactDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Characteristics_Tapicerka",
                table: "CarProfileModels",
                newName: "Characteristics_Upholstery");

            migrationBuilder.RenameColumn(
                name: "Characteristics_Silnik",
                table: "CarProfileModels",
                newName: "Characteristics_Rims");

            migrationBuilder.RenameColumn(
                name: "Characteristics_Felgi",
                table: "CarProfileModels",
                newName: "Characteristics_Engine");

            migrationBuilder.AddColumn<string>(
                name: "CarContactDetails_City",
                table: "CarProfileModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarContactDetails_ContactNumber",
                table: "CarProfileModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarContactDetails_Coutry",
                table: "CarProfileModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarContactDetails_ValueMoney",
                table: "CarProfileModels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarContactDetails_City",
                table: "CarProfileModels");

            migrationBuilder.DropColumn(
                name: "CarContactDetails_ContactNumber",
                table: "CarProfileModels");

            migrationBuilder.DropColumn(
                name: "CarContactDetails_Coutry",
                table: "CarProfileModels");

            migrationBuilder.DropColumn(
                name: "CarContactDetails_ValueMoney",
                table: "CarProfileModels");

            migrationBuilder.RenameColumn(
                name: "Characteristics_Upholstery",
                table: "CarProfileModels",
                newName: "Characteristics_Tapicerka");

            migrationBuilder.RenameColumn(
                name: "Characteristics_Rims",
                table: "CarProfileModels",
                newName: "Characteristics_Silnik");

            migrationBuilder.RenameColumn(
                name: "Characteristics_Engine",
                table: "CarProfileModels",
                newName: "Characteristics_Felgi");
        }
    }
}
