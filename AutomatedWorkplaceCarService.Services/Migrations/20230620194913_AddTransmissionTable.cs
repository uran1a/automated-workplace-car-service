using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutomatedWorkplaceCarService.Services.Migrations
{
    /// <inheritdoc />
    public partial class AddTransmissionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Transmission",
                table: "Car",
                newName: "TransmissionId");

            migrationBuilder.CreateTable(
                name: "Transmission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmission", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_TransmissionId",
                table: "Car",
                column: "TransmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Transmission_TransmissionId",
                table: "Car",
                column: "TransmissionId",
                principalTable: "Transmission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Transmission_TransmissionId",
                table: "Car");

            migrationBuilder.DropTable(
                name: "Transmission");

            migrationBuilder.DropIndex(
                name: "IX_Car_TransmissionId",
                table: "Car");

            migrationBuilder.RenameColumn(
                name: "TransmissionId",
                table: "Car",
                newName: "Transmission");
        }
    }
}
