using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutomatedWorkplaceCarService.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddSpecializationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    ServiceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specializations_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Specializations_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_PostId",
                table: "Specializations",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_ServiceId",
                table: "Specializations",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Specializations");
        }
    }
}
