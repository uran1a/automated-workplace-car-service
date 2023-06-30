using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomatedWorkplaceCarService.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_Cars_CarId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_Services_ServiceId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_Stages_StageId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_Users_ClientId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_Users_EmployeeId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Application_ApplicationId",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Application",
                table: "Application");

            migrationBuilder.RenameTable(
                name: "Application",
                newName: "Applications");

            migrationBuilder.RenameIndex(
                name: "IX_Application_StageId",
                table: "Applications",
                newName: "IX_Applications_StageId");

            migrationBuilder.RenameIndex(
                name: "IX_Application_ServiceId",
                table: "Applications",
                newName: "IX_Applications_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Application_EmployeeId",
                table: "Applications",
                newName: "IX_Applications_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Application_ClientId",
                table: "Applications",
                newName: "IX_Applications_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Application_CarId",
                table: "Applications",
                newName: "IX_Applications_CarId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartWork",
                table: "Applications",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndWork",
                table: "Applications",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Cars_CarId",
                table: "Applications",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Services_ServiceId",
                table: "Applications",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Stages_StageId",
                table: "Applications",
                column: "StageId",
                principalTable: "Stages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Users_ClientId",
                table: "Applications",
                column: "ClientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Users_EmployeeId",
                table: "Applications",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Applications_ApplicationId",
                table: "Images",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Cars_CarId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Services_ServiceId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Stages_StageId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Users_ClientId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Users_EmployeeId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Applications_ApplicationId",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.RenameTable(
                name: "Applications",
                newName: "Application");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_StageId",
                table: "Application",
                newName: "IX_Application_StageId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_ServiceId",
                table: "Application",
                newName: "IX_Application_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_EmployeeId",
                table: "Application",
                newName: "IX_Application_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_ClientId",
                table: "Application",
                newName: "IX_Application_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_CarId",
                table: "Application",
                newName: "IX_Application_CarId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartWork",
                table: "Application",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndWork",
                table: "Application",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Application",
                table: "Application",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Cars_CarId",
                table: "Application",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Application_Users_ClientId",
                table: "Application",
                column: "ClientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Users_EmployeeId",
                table: "Application",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Application_ApplicationId",
                table: "Images",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "Id");
        }
    }
}
