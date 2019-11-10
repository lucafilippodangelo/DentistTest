using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Practises_PractiseId",
                table: "Appointments");

            migrationBuilder.AlterColumn<Guid>(
                name: "PractiseId",
                table: "Appointments",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Practises_PractiseId",
                table: "Appointments",
                column: "PractiseId",
                principalTable: "Practises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Practises_PractiseId",
                table: "Appointments");

            migrationBuilder.AlterColumn<Guid>(
                name: "PractiseId",
                table: "Appointments",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Practises_PractiseId",
                table: "Appointments",
                column: "PractiseId",
                principalTable: "Practises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
