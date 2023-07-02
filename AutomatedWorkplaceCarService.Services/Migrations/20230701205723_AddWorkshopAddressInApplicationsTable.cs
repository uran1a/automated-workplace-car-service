using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomatedWorkplaceCarService.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkshopAddressInApplicationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WorkshopAddress",
                table: "Applications",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkshopAddress",
                table: "Applications");
        }
    }
}
