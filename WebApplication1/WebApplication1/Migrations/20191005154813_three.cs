using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StaffRoles",
                keyColumn: "Id",
                keyValue: new Guid("a24a0521-52e2-438b-a1d5-1db1f75c836b"),
                columns: new[] { "Note", "Role" },
                values: new object[] { "Seeded staffRole two NOTE", "Seeded staffRole two" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StaffRoles",
                keyColumn: "Id",
                keyValue: new Guid("a24a0521-52e2-438b-a1d5-1db1f75c836b"),
                columns: new[] { "Note", "Role" },
                values: new object[] { null, null });
        }
    }
}
