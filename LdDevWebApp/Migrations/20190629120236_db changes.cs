using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LdDevWebApp.Migrations
{
    public partial class dbchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Practises",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Practises",
                columns: new[] { "Id", "Address", "Name", "Note" },
                values: new object[] { new Guid("9012aa35-1433-48fe-ae72-de2aaa38e37e"), null, "Practise Two", "Practse Two Note" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Practises",
                keyColumn: "Id",
                keyValue: new Guid("9012aa35-1433-48fe-ae72-de2aaa38e37e"));

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Practises");
        }
    }
}
