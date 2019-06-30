using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LdDevWebApp.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentStaff",
                table: "AppointmentStaff");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AppointmentStaff_AppointmentStaffGiudId",
                table: "AppointmentStaff",
                column: "AppointmentStaffGiudId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentStaff",
                table: "AppointmentStaff",
                columns: new[] { "giudAptId", "giudPersonId" });

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
                columns: new[] { "Id", "Notes", "PatientId", "PractiseId", "When" },
                values: new object[] { new Guid("644f17b2-6e34-4cad-bab5-8bba425270a4"), "Seeded Appointment One", null, new Guid("8912aa35-1433-48fe-ae72-de2aaa38e37e"), new DateTime(2019, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Notes", "PatientId", "PractiseId", "When" },
                values: new object[] { new Guid("9022622f-7adf-44ed-9efa-d362d937b5b8"), "Seeded Appointment Two", null, new Guid("9012aa35-1433-48fe-ae72-de2aaa38e37e"), new DateTime(2019, 6, 1, 14, 30, 0, 0, DateTimeKind.Unspecified) });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_AppointmentStaff_AppointmentStaffGiudId",
                table: "AppointmentStaff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentStaff",
                table: "AppointmentStaff");

            migrationBuilder.DeleteData(
                table: "AppointmentLogs",
                keyColumn: "Id",
                keyValue: new Guid("1d2f7b60-6236-4598-a28b-a03d03eb1b94"));

            migrationBuilder.DeleteData(
                table: "AppointmentLogs",
                keyColumn: "Id",
                keyValue: new Guid("253d32ba-ba51-4f51-b151-caa02eb54f23"));

            migrationBuilder.DeleteData(
                table: "AppointmentLogs",
                keyColumn: "Id",
                keyValue: new Guid("3b3d41f9-ed3b-45b6-89d5-a878b007b32a"));

            migrationBuilder.DeleteData(
                table: "AppointmentLogs",
                keyColumn: "Id",
                keyValue: new Guid("4e80d553-b1fd-4aed-9020-2206e2aa23cf"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("644f17b2-6e34-4cad-bab5-8bba425270a4"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("9022622f-7adf-44ed-9efa-d362d937b5b8"));

            migrationBuilder.DeleteData(
                table: "Practises",
                keyColumn: "Id",
                keyValue: new Guid("8912aa35-1433-48fe-ae72-de2aaa38e37e"));

            migrationBuilder.DeleteData(
                table: "Practises",
                keyColumn: "Id",
                keyValue: new Guid("9012aa35-1433-48fe-ae72-de2aaa38e37e"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentStaff",
                table: "AppointmentStaff",
                column: "AppointmentStaffGiudId");
        }
    }
}
