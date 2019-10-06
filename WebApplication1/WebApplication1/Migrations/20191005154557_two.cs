using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StaffRoles",
                columns: new[] { "Id", "Note", "Role" },
                values: new object[] { new Guid("1a637f30-a003-48af-8f46-21328531e9c8"), "Seeded staffRole one NOTE", "Seeded staffRole one" });

            migrationBuilder.InsertData(
                table: "StaffRoles",
                columns: new[] { "Id", "Note", "Role" },
                values: new object[] { new Guid("a24a0521-52e2-438b-a1d5-1db1f75c836b"), null, null });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Discriminator", "Email", "Name", "Note", "Phone", "Surname", "StaffRoleID" },
                values: new object[] { new Guid("1eb6bee1-e634-4b1e-9caf-5ce80b45604c"), "Staff", "sviluppo.dangelo@gmail.com", "Seeded staff one NAME", null, null, "Seeded staff one Surname", new Guid("1a637f30-a003-48af-8f46-21328531e9c8") });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Discriminator", "Email", "Name", "Note", "Phone", "Surname", "StaffRoleID" },
                values: new object[] { new Guid("ee243d91-ddf1-48f6-827d-0bfa6616bae1"), "Staff", "info@lucadangelo.it", "Seeded staff two NAME", null, null, "Seeded staff two Surname", new Guid("a24a0521-52e2-438b-a1d5-1db1f75c836b") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("1eb6bee1-e634-4b1e-9caf-5ce80b45604c"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("ee243d91-ddf1-48f6-827d-0bfa6616bae1"));

            migrationBuilder.DeleteData(
                table: "StaffRoles",
                keyColumn: "Id",
                keyValue: new Guid("1a637f30-a003-48af-8f46-21328531e9c8"));

            migrationBuilder.DeleteData(
                table: "StaffRoles",
                keyColumn: "Id",
                keyValue: new Guid("a24a0521-52e2-438b-a1d5-1db1f75c836b"));
        }
    }
}
