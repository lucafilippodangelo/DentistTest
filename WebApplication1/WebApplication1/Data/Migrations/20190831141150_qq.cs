using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class qq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Practises",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Practises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Surname = table.Column<string>(maxLength: 150, nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Note = table.Column<string>(maxLength: 1000, nullable: true),
                    Email = table.Column<string>(maxLength: 150, nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    StaffRoleID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_StaffRoles_StaffRoleID",
                        column: x => x.StaffRoleID,
                        principalTable: "StaffRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    When = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    StatusID = table.Column<Guid>(nullable: false),
                    PatientId = table.Column<Guid>(nullable: true),
                    PractiseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Persons_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Practises_PractiseId",
                        column: x => x.PractiseId,
                        principalTable: "Practises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    When = table.Column<DateTime>(nullable: false),
                    Information = table.Column<string>(nullable: false),
                    AppointmentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentLogs_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentStaff",
                columns: table => new
                {
                    giudAptId = table.Column<Guid>(nullable: false),
                    giudPersonId = table.Column<Guid>(nullable: false),
                    AppointmentStaffGiudId = table.Column<Guid>(nullable: false),
                    appointmentId = table.Column<Guid>(nullable: true),
                    staffId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentStaff", x => new { x.giudAptId, x.giudPersonId });
                    table.UniqueConstraint("AK_AppointmentStaff_AppointmentStaffGiudId", x => x.AppointmentStaffGiudId);
                    table.ForeignKey(
                        name: "FK_AppointmentStaff_Appointments_appointmentId",
                        column: x => x.appointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppointmentStaff_Persons_staffId",
                        column: x => x.staffId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Practises",
                columns: new[] { "Id", "Address", "Name", "Notes" },
                values: new object[] { new Guid("8912aa35-1433-48fe-ae72-de2aaa38e37e"), null, "Practise One", "Seeded Practise Note One" });

            migrationBuilder.InsertData(
                table: "Practises",
                columns: new[] { "Id", "Address", "Name", "Notes" },
                values: new object[] { new Guid("9012aa35-1433-48fe-ae72-de2aaa38e37e"), null, "Practise Two", "Seeded Practise Note Two" });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Notes", "PatientId", "PractiseId", "StatusID", "When" },
                values: new object[] { new Guid("644f17b2-6e34-4cad-bab5-8bba425270a4"), "Seeded Appointment One", null, new Guid("8912aa35-1433-48fe-ae72-de2aaa38e37e"), new Guid("12d19fe2-ad58-409b-8ccb-0bf9f9eaa483"), new DateTime(2019, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Notes", "PatientId", "PractiseId", "StatusID", "When" },
                values: new object[] { new Guid("9022622f-7adf-44ed-9efa-d362d937b5b8"), "Seeded Appointment Two", null, new Guid("9012aa35-1433-48fe-ae72-de2aaa38e37e"), new Guid("12d19fe2-ad58-409b-8ccb-0bf9f9eaa483"), new DateTime(2019, 6, 1, 14, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "AppointmentLogs",
                columns: new[] { "Id", "AppointmentId", "Information", "When" },
                values: new object[,]
                {
                    { new Guid("1d2f7b60-6236-4598-a28b-a03d03eb1b94"), new Guid("644f17b2-6e34-4cad-bab5-8bba425270a4"), "Seeded Log One for Appointment One", new DateTime(2019, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified) },
                    { new Guid("253d32ba-ba51-4f51-b151-caa02eb54f23"), new Guid("644f17b2-6e34-4cad-bab5-8bba425270a4"), "Seeded Log Two for Appointment One", new DateTime(2019, 5, 2, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3b3d41f9-ed3b-45b6-89d5-a878b007b32a"), new Guid("644f17b2-6e34-4cad-bab5-8bba425270a4"), "Seeded Log Three for Appointment One", new DateTime(2019, 6, 3, 4, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4e80d553-b1fd-4aed-9020-2206e2aa23cf"), new Guid("9022622f-7adf-44ed-9efa-d362d937b5b8"), "Seeded Log One for Appointment Two", new DateTime(2019, 6, 4, 5, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentLogs_AppointmentId",
                table: "AppointmentLogs",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PractiseId",
                table: "Appointments",
                column: "PractiseId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentStaff_appointmentId",
                table: "AppointmentStaff",
                column: "appointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentStaff_staffId",
                table: "AppointmentStaff",
                column: "staffId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_StaffRoleID",
                table: "Persons",
                column: "StaffRoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentLogs");

            migrationBuilder.DropTable(
                name: "AppointmentStaff");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Practises");

            migrationBuilder.DropTable(
                name: "StaffRoles");
        }
    }
}
