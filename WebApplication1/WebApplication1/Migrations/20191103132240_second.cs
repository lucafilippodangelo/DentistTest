using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Persons",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("5b6c0ab6-c947-4279-9e35-53e2fa3cc1ff"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("99b48598-b815-4d08-aa20-9492f41738ea"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("1eb6bee1-e634-4b1e-9caf-5ce80b45604c"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("567f81a6-ff37-4329-ae7b-3364f781700f"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("ee243d91-ddf1-48f6-827d-0bfa6616bae1"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("f6ad3484-6916-4b5b-9a7e-5bbf69d9996a"),
                column: "IsActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Persons");
        }
    }
}
