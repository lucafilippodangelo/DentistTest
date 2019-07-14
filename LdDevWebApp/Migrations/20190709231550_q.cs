using Microsoft.EntityFrameworkCore.Migrations;

namespace LdDevWebApp.Migrations
{
    public partial class q : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_StaffRoles_StaffRoleId",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "StaffRoleId",
                table: "Persons",
                newName: "StaffRoleID");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_StaffRoleId",
                table: "Persons",
                newName: "IX_Persons_StaffRoleID");

            migrationBuilder.AlterColumn<string>(
                name: "Information",
                table: "AppointmentLogs",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_StaffRoles_StaffRoleID",
                table: "Persons",
                column: "StaffRoleID",
                principalTable: "StaffRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_StaffRoles_StaffRoleID",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "StaffRoleID",
                table: "Persons",
                newName: "StaffRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_StaffRoleID",
                table: "Persons",
                newName: "IX_Persons_StaffRoleId");

            migrationBuilder.AlterColumn<string>(
                name: "Information",
                table: "AppointmentLogs",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_StaffRoles_StaffRoleId",
                table: "Persons",
                column: "StaffRoleId",
                principalTable: "StaffRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
