using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutomatedWorkplaceCarService.Services.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Surname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Patronymic = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Login = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    MobilePhone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Post = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
