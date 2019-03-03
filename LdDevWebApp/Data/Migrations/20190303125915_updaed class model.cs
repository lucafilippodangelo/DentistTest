using Microsoft.EntityFrameworkCore.Migrations;

namespace LdDevWebApp.Data.Migrations
{
    public partial class updaedclassmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "surname",
                table: "Patients",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Patients",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "mail",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "notes",
                table: "Patients",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "Patients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mail",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "notes",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "surname",
                table: "Patients",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Patients",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
