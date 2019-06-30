using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LdDevWebApp.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Practises",
                keyColumn: "Id",
                keyValue: new Guid("8912aa35-1433-48fe-ae72-de2aaa38e37e"));

            migrationBuilder.DeleteData(
                table: "Practises",
                keyColumn: "Id",
                keyValue: new Guid("9012aa35-1433-48fe-ae72-de2aaa38e37e"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("644f17b2-6e34-4cad-bab5-8bba425270a4"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("9022622f-7adf-44ed-9efa-d362d937b5b8"));

            migrationBuilder.AddColumn<Guid>(
                name: "AppointmentStaffGiudId",
                table: "AppointmentStaff",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentStaff",
                table: "AppointmentStaff",
                column: "AppointmentStaffGiudId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentStaff",
                table: "AppointmentStaff");

            migrationBuilder.DropColumn(
                name: "AppointmentStaffGiudId",
                table: "AppointmentStaff");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentStaff",
                table: "AppointmentStaff",
                columns: new[] { "giudAptId", "giudPersonId" });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Notes", "PatientId", "PractiseId", "When" },
                values: new object[,]
                {
                    { new Guid("644f17b2-6e34-4cad-bab5-8bba425270a4"), "Seeded Appointment One", null, null, new DateTime(2019, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified) },
                    { new Guid("9022622f-7adf-44ed-9efa-d362d937b5b8"), "Seeded Appointment Two", null, null, new DateTime(2019, 6, 1, 14, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Practises",
                columns: new[] { "Id", "Address", "Name", "Notes" },
                values: new object[,]
                {
                    { new Guid("8912aa35-1433-48fe-ae72-de2aaa38e37e"), null, "Practise One", "Seeded Practise Note One" },
                    { new Guid("9012aa35-1433-48fe-ae72-de2aaa38e37e"), null, "Practise Two", "Seeded Practise Note Two" }
                });

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
    }
}
