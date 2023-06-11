using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomatedWorkplaceCarService.Services.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationBetweenApplicationsAndCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Application",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Application_CarId",
                table: "Application",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Car_CarId",
                table: "Application",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_Car_CarId",
                table: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Application_CarId",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Application");
        }
    }
}
