using Microsoft.EntityFrameworkCore.Migrations;

namespace LdDevWebApp.Migrations
{
    public partial class practisechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Practises_PractisegiudId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Practises",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "LocationName",
                table: "Practises",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "giudId",
                table: "Practises",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PractisegiudId",
                table: "Appointments",
                newName: "PractiseId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_PractisegiudId",
                table: "Appointments",
                newName: "IX_Appointments_PractiseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Practises_PractiseId",
                table: "Appointments",
                column: "PractiseId",
                principalTable: "Practises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Practises_PractiseId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Practises",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Practises",
                newName: "LocationName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Practises",
                newName: "giudId");

            migrationBuilder.RenameColumn(
                name: "PractiseId",
                table: "Appointments",
                newName: "PractisegiudId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_PractiseId",
                table: "Appointments",
                newName: "IX_Appointments_PractisegiudId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Practises_PractisegiudId",
                table: "Appointments",
                column: "PractisegiudId",
                principalTable: "Practises",
                principalColumn: "giudId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
