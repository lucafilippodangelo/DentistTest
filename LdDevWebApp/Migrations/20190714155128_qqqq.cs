using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LdDevWebApp.Migrations
{
    public partial class qqqq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AptStatus_StatusId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_StatusId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Appointments",
                newName: "StatusID");

            migrationBuilder.AlterColumn<Guid>(
                name: "StatusID",
                table: "Appointments",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("644f17b2-6e34-4cad-bab5-8bba425270a4"),
                column: "StatusID",
                value: new Guid("12d19fe2-ad58-409b-8ccb-0bf9f9eaa483"));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("9022622f-7adf-44ed-9efa-d362d937b5b8"),
                column: "StatusID",
                value: new Guid("12d19fe2-ad58-409b-8ccb-0bf9f9eaa483"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusID",
                table: "Appointments",
                newName: "StatusId");

            migrationBuilder.AlterColumn<Guid>(
                name: "StatusId",
                table: "Appointments",
                nullable: true,
                oldClrType: typeof(Guid));

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

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_StatusId",
                table: "Appointments",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AptStatus_StatusId",
                table: "Appointments",
                column: "StatusId",
                principalTable: "AptStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
