using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Persons_PatientId",
                table: "Appointments");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Practises",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "Appointments",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.UpdateData(
                table: "Practises",
                keyColumn: "Id",
                keyValue: new Guid("8912aa35-1433-48fe-ae72-de2aaa38e37e"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Practises",
                keyColumn: "Id",
                keyValue: new Guid("9012aa35-1433-48fe-ae72-de2aaa38e37e"),
                column: "IsActive",
                value: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Persons_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Persons_PatientId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Practises");

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "Appointments",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Persons_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
