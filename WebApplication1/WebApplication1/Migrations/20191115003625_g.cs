using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class g : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentTreatment",
                columns: table => new
                {
                    AppointmentId = table.Column<Guid>(nullable: false),
                    TreatmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentTreatment", x => new { x.AppointmentId, x.TreatmentId });
                    table.ForeignKey(
                        name: "FK_AppointmentTreatment_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentTreatment_Treatment_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Treatment",
                columns: new[] { "Id", "Description", "Duration", "IsActive", "Name" },
                values: new object[] { new Guid("75ea697a-9532-4592-b9e1-f6f010df2b3d"), "Seeded Treatment ONE description", 30, true, "Seeded Treatment ONE" });

            migrationBuilder.InsertData(
                table: "Treatment",
                columns: new[] { "Id", "Description", "Duration", "IsActive", "Name" },
                values: new object[] { new Guid("d769ef89-a0cd-4a0a-8e55-f8f1af709b57"), "Seeded Treatment TWO description", 30, true, "Seeded Treatment TWO" });

            migrationBuilder.InsertData(
                table: "Treatment",
                columns: new[] { "Id", "Description", "Duration", "IsActive", "Name" },
                values: new object[] { new Guid("d55797b7-de47-40f3-9b58-7a6b15aba521"), "Seeded Treatment THREE description", 30, true, "Seeded Treatment THREE" });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentTreatment_TreatmentId",
                table: "AppointmentTreatment",
                column: "TreatmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentTreatment");

            migrationBuilder.DropTable(
                name: "Treatment");
        }
    }
}
