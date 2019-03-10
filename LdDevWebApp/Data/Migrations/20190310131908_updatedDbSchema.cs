using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LdDevWebApp.Data.Migrations
{
    public partial class updatedDbSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.RenameTable(
                name: "Patients",
                newName: "Persons");

            migrationBuilder.RenameColumn(
                name: "giudId",
                table: "Persons",
                newName: "giudPersonId");

            migrationBuilder.AddColumn<Guid>(
                name: "giudAptId",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Persons",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "staffNote",
                table: "Persons",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "giudPersonId");

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

            migrationBuilder.CreateTable(
                name: "StaffRoles",
                columns: table => new
                {
                    giudId = table.Column<Guid>(nullable: false),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffRoles", x => x.giudId);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    giudAptId = table.Column<Guid>(nullable: false),
                    aptScheduledDateTime = table.Column<DateTime>(nullable: false),
                    aptNotes = table.Column<string>(nullable: true),
                    aptScheduledDurationgiudId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.giudAptId);
                    table.ForeignKey(
                        name: "FK_Appointments_AppointmentDurations_aptScheduledDurationgiudId",
                        column: x => x.aptScheduledDurationgiudId,
                        principalTable: "AppointmentDurations",
                        principalColumn: "giudId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentStaff_NtoN",
                columns: table => new
                {
                    AppointmentStaff_NtoN_giudId = table.Column<Guid>(nullable: false),
                    giudAptId = table.Column<Guid>(nullable: false),
                    giudStaffId = table.Column<Guid>(nullable: false),
                    staffgiudPersonId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentStaff_NtoN", x => x.AppointmentStaff_NtoN_giudId);
                    table.ForeignKey(
                        name: "FK_AppointmentStaff_NtoN_Appointments_giudAptId",
                        column: x => x.giudAptId,
                        principalTable: "Appointments",
                        principalColumn: "giudAptId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentStaff_NtoN_Persons_staffgiudPersonId",
                        column: x => x.staffgiudPersonId,
                        principalTable: "Persons",
                        principalColumn: "giudPersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Practises",
                columns: table => new
                {
                    giudId = table.Column<Guid>(nullable: false),
                    LocationName = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    giudAptId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Practises", x => x.giudId);
                    table.ForeignKey(
                        name: "FK_Practises_Appointments_giudAptId",
                        column: x => x.giudAptId,
                        principalTable: "Appointments",
                        principalColumn: "giudAptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentTypes",
                columns: table => new
                {
                    giudId = table.Column<Guid>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    giudAptId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentTypes", x => x.giudId);
                    table.ForeignKey(
                        name: "FK_TreatmentTypes_Appointments_giudAptId",
                        column: x => x.giudAptId,
                        principalTable: "Appointments",
                        principalColumn: "giudAptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_giudAptId",
                table: "Persons",
                column: "giudAptId",
                unique: true,
                filter: "[giudAptId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_aptScheduledDurationgiudId",
                table: "Appointments",
                column: "aptScheduledDurationgiudId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentStaff_NtoN_giudAptId",
                table: "AppointmentStaff_NtoN",
                column: "giudAptId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentStaff_NtoN_staffgiudPersonId",
                table: "AppointmentStaff_NtoN",
                column: "staffgiudPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Practises_giudAptId",
                table: "Practises",
                column: "giudAptId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentTypes_giudAptId",
                table: "TreatmentTypes",
                column: "giudAptId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Appointments_giudAptId",
                table: "Persons",
                column: "giudAptId",
                principalTable: "Appointments",
                principalColumn: "giudAptId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Appointments_giudAptId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "AppointmentStaff_NtoN");

            migrationBuilder.DropTable(
                name: "Practises");

            migrationBuilder.DropTable(
                name: "StaffRoles");

            migrationBuilder.DropTable(
                name: "TreatmentTypes");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AppointmentDurations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_giudAptId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "giudAptId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "staffNote",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Patients");

            migrationBuilder.RenameColumn(
                name: "giudPersonId",
                table: "Patients",
                newName: "giudId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "giudId");
        }
    }
}
