using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LdDevWebApp.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Practises",
                columns: new[] { "Id", "Name", "Note" },
                values: new object[] { new Guid("8912aa35-1433-48fe-ae72-de2aaa38e37e"), "Practise One", "Practse One Note" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Practises",
                keyColumn: "Id",
                keyValue: new Guid("8912aa35-1433-48fe-ae72-de2aaa38e37e"));
        }
    }
}
