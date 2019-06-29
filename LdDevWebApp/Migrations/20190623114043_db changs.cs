using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LdDevWebApp.Migrations
{
    public partial class dbchangs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Persons_aptPatientgiudPersonId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentDurations_aptScheduledDurationgiudId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_TreatmentTypes_aptTreatmentTypegiudId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Practises_practisegiudId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentStaff_Appointments_giudAptId",
                table: "AppointmentStaff");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentStaff_Persons_giudPersonId",
                table: "AppointmentStaff");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_StaffRoles_staffRolegiudStaffRoleId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "AppointmentDurations");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentStaff_giudPersonId",
                table: "AppointmentStaff");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_aptScheduledDurationgiudId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "patientNote",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "staffNote",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "aptScheduledDurationgiudId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "TreatmentTypes",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "giudId",
                table: "TreatmentTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "StaffRoles",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "giudStaffRoleId",
                table: "StaffRoles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "surname",
                table: "Persons",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Persons",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Persons",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "mail",
                table: "Persons",
                newName: "Mail");

            migrationBuilder.RenameColumn(
                name: "staffRolegiudStaffRoleId",
                table: "Persons",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "personNote",
                table: "Persons",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "giudPersonId",
                table: "Persons",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_staffRolegiudStaffRoleId",
                table: "Persons",
                newName: "IX_Persons_RoleId");

            migrationBuilder.RenameColumn(
                name: "practisegiudId",
                table: "Appointments",
                newName: "PractisegiudId");

            migrationBuilder.RenameColumn(
                name: "aptTreatmentTypegiudId",
                table: "Appointments",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "aptScheduledDateTime",
                table: "Appointments",
                newName: "When");

            migrationBuilder.RenameColumn(
                name: "aptPatientgiudPersonId",
                table: "Appointments",
                newName: "AppointmentTreatmentTypeId");

            migrationBuilder.RenameColumn(
                name: "aptNotes",
                table: "Appointments",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "giudAptId",
                table: "Appointments",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_practisegiudId",
                table: "Appointments",
                newName: "IX_Appointments_PractisegiudId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_aptTreatmentTypegiudId",
                table: "Appointments",
                newName: "IX_Appointments_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_aptPatientgiudPersonId",
                table: "Appointments",
                newName: "IX_Appointments_AppointmentTreatmentTypeId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Duration",
                table: "TreatmentTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TreatmentTypes",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Persons",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Persons",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<Guid>(
                name: "appointmentId",
                table: "AppointmentStaff",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "staffId",
                table: "AppointmentStaff",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentStaff_appointmentId",
                table: "AppointmentStaff",
                column: "appointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentStaff_staffId",
                table: "AppointmentStaff",
                column: "staffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_TreatmentTypes_AppointmentTreatmentTypeId",
                table: "Appointments",
                column: "AppointmentTreatmentTypeId",
                principalTable: "TreatmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Persons_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Practises_PractisegiudId",
                table: "Appointments",
                column: "PractisegiudId",
                principalTable: "Practises",
                principalColumn: "giudId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentStaff_Appointments_appointmentId",
                table: "AppointmentStaff",
                column: "appointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentStaff_Persons_staffId",
                table: "AppointmentStaff",
                column: "staffId",
                principalTable: "Persons",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_TreatmentTypes_AppointmentTreatmentTypeId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Persons_PatientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Practises_PractisegiudId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentStaff_Appointments_appointmentId",
                table: "AppointmentStaff");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentStaff_Persons_staffId",
                table: "AppointmentStaff");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_StaffRoles_RoleId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentStaff_appointmentId",
                table: "AppointmentStaff");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentStaff_staffId",
                table: "AppointmentStaff");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "TreatmentTypes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TreatmentTypes");

            migrationBuilder.DropColumn(
                name: "appointmentId",
                table: "AppointmentStaff");

            migrationBuilder.DropColumn(
                name: "staffId",
                table: "AppointmentStaff");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "TreatmentTypes",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TreatmentTypes",
                newName: "giudId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "StaffRoles",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StaffRoles",
                newName: "giudStaffRoleId");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Persons",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Persons",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Persons",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Mail",
                table: "Persons",
                newName: "mail");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Persons",
                newName: "staffRolegiudStaffRoleId");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Persons",
                newName: "personNote");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Persons",
                newName: "giudPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_RoleId",
                table: "Persons",
                newName: "IX_Persons_staffRolegiudStaffRoleId");

            migrationBuilder.RenameColumn(
                name: "PractisegiudId",
                table: "Appointments",
                newName: "practisegiudId");

            migrationBuilder.RenameColumn(
                name: "When",
                table: "Appointments",
                newName: "aptScheduledDateTime");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Appointments",
                newName: "aptTreatmentTypegiudId");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Appointments",
                newName: "aptNotes");

            migrationBuilder.RenameColumn(
                name: "AppointmentTreatmentTypeId",
                table: "Appointments",
                newName: "aptPatientgiudPersonId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Appointments",
                newName: "giudAptId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_PractisegiudId",
                table: "Appointments",
                newName: "IX_Appointments_practisegiudId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                newName: "IX_Appointments_aptTreatmentTypegiudId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_AppointmentTreatmentTypeId",
                table: "Appointments",
                newName: "IX_Appointments_aptPatientgiudPersonId");

            migrationBuilder.AlterColumn<string>(
                name: "surname",
                table: "Persons",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Persons",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AddColumn<string>(
                name: "patientNote",
                table: "Persons",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "staffNote",
                table: "Persons",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "aptScheduledDurationgiudId",
                table: "Appointments",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AppointmentDurations",
                columns: table => new
                {
                    giudId = table.Column<Guid>(nullable: false),
                    timeDuration = table.Column<DateTime>(nullable: false),
                    timeDurationDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentDurations", x => x.giudId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentStaff_giudPersonId",
                table: "AppointmentStaff",
                column: "giudPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_aptScheduledDurationgiudId",
                table: "Appointments",
                column: "aptScheduledDurationgiudId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Persons_aptPatientgiudPersonId",
                table: "Appointments",
                column: "aptPatientgiudPersonId",
                principalTable: "Persons",
                principalColumn: "giudPersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AppointmentDurations_aptScheduledDurationgiudId",
                table: "Appointments",
                column: "aptScheduledDurationgiudId",
                principalTable: "AppointmentDurations",
                principalColumn: "giudId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_TreatmentTypes_aptTreatmentTypegiudId",
                table: "Appointments",
                column: "aptTreatmentTypegiudId",
                principalTable: "TreatmentTypes",
                principalColumn: "giudId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Practises_practisegiudId",
                table: "Appointments",
                column: "practisegiudId",
                principalTable: "Practises",
                principalColumn: "giudId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentStaff_Appointments_giudAptId",
                table: "AppointmentStaff",
                column: "giudAptId",
                principalTable: "Appointments",
                principalColumn: "giudAptId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentStaff_Persons_giudPersonId",
                table: "AppointmentStaff",
                column: "giudPersonId",
                principalTable: "Persons",
                principalColumn: "giudPersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_StaffRoles_staffRolegiudStaffRoleId",
                table: "Persons",
                column: "staffRolegiudStaffRoleId",
                principalTable: "StaffRoles",
                principalColumn: "giudStaffRoleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
