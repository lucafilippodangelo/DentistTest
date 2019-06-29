using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LdDevWebApp.Migrations
{
    public partial class stafrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_TreatmentTypes_AppointmentTreatmentTypeId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_StaffRoles_RoleId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "TreatmentTypes");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_AppointmentTreatmentTypeId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "AppointmentTreatmentTypeId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "StaffRoles",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Persons",
                newName: "StaffRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_RoleId",
                table: "Persons",
                newName: "IX_Persons_StaffRoleId");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "StaffRoles",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_StaffRoles_StaffRoleId",
                table: "Persons",
                column: "StaffRoleId",
                principalTable: "StaffRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_StaffRoles_StaffRoleId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "StaffRoles");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "StaffRoles",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "StaffRoleId",
                table: "Persons",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_StaffRoleId",
                table: "Persons",
                newName: "IX_Persons_RoleId");

            migrationBuilder.AddColumn<Guid>(
                name: "AppointmentTreatmentTypeId",
                table: "Appointments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TreatmentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Duration = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentTreatmentTypeId",
                table: "Appointments",
                column: "AppointmentTreatmentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_TreatmentTypes_AppointmentTreatmentTypeId",
                table: "Appointments",
                column: "AppointmentTreatmentTypeId",
                principalTable: "TreatmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_StaffRoles_RoleId",
                table: "Persons",
                column: "RoleId",
                principalTable: "StaffRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
