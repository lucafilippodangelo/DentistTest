using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LdDevWebApp.Migrations
{
    public partial class qq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("644f17b2-6e34-4cad-bab5-8bba425270a4"),
                column: "StatusId",
                value: new Guid("12d19fe2-ad58-409b-8ccb-0bf9f9eaa483"));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("9022622f-7adf-44ed-9efa-d362d937b5b8"),
                column: "StatusId",
                value: new Guid("12d19fe2-ad58-409b-8ccb-0bf9f9eaa483"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("644f17b2-6e34-4cad-bab5-8bba425270a4"),
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("9022622f-7adf-44ed-9efa-d362d937b5b8"),
                column: "StatusId",
                value: null);
        }
    }
}
