using Microsoft.EntityFrameworkCore.Migrations;

namespace LdDevWebApp.Data.Migrations
{
    public partial class schemaupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "mail",
                table: "Patients",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "mail",
                table: "Patients",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
