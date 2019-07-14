using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LdDevWebApp.Migrations
{
    public partial class k : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                table: "Appointments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AptStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AptStatus", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AptStatus_StatusId",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "AptStatus");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_StatusId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Appointments");
        }
    }
}
