using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomatedWorkplaceCarService.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddStageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_Service_ServiceId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_Stage_StageId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Specializations_Service_ServiceId",
                table: "Specializations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stage",
                table: "Stage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.RenameTable(
                name: "Stage",
                newName: "Stages");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "Services");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stages",
                table: "Stages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Services_ServiceId",
                table: "Application",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Stages_StageId",
                table: "Application",
                column: "StageId",
                principalTable: "Stages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specializations_Services_ServiceId",
                table: "Specializations",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_Services_ServiceId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_Stages_StageId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Specializations_Services_ServiceId",
                table: "Specializations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stages",
                table: "Stages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.RenameTable(
                name: "Stages",
                newName: "Stage");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Service");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stage",
                table: "Stage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Service_ServiceId",
                table: "Application",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Stage_StageId",
                table: "Application",
                column: "StageId",
                principalTable: "Stage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specializations_Service_ServiceId",
                table: "Specializations",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
