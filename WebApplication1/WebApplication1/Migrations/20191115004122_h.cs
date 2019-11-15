using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class h : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentTreatment_Treatment_TreatmentId",
                table: "AppointmentTreatment");

            migrationBuilder.DropTable(
                name: "Treatment");

            migrationBuilder.RenameColumn(
                name: "TreatmentId",
                table: "AppointmentTreatment",
                newName: "ThreatmentId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentTreatment_TreatmentId",
                table: "AppointmentTreatment",
                newName: "IX_AppointmentTreatment_ThreatmentId");

            migrationBuilder.CreateTable(
                name: "Threatment",
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
                    table.PrimaryKey("PK_Threatment", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Threatment",
                columns: new[] { "Id", "Description", "Duration", "IsActive", "Name" },
                values: new object[] { new Guid("75ea697a-9532-4592-b9e1-f6f010df2b3d"), "Seeded Treatment ONE description", 30, true, "Seeded Treatment ONE" });

            migrationBuilder.InsertData(
                table: "Threatment",
                columns: new[] { "Id", "Description", "Duration", "IsActive", "Name" },
                values: new object[] { new Guid("d769ef89-a0cd-4a0a-8e55-f8f1af709b57"), "Seeded Treatment TWO description", 30, true, "Seeded Treatment TWO" });

            migrationBuilder.InsertData(
                table: "Threatment",
                columns: new[] { "Id", "Description", "Duration", "IsActive", "Name" },
                values: new object[] { new Guid("d55797b7-de47-40f3-9b58-7a6b15aba521"), "Seeded Treatment THREE description", 30, true, "Seeded Treatment THREE" });

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentTreatment_Threatment_ThreatmentId",
                table: "AppointmentTreatment",
                column: "ThreatmentId",
                principalTable: "Threatment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentTreatment_Threatment_ThreatmentId",
                table: "AppointmentTreatment");

            migrationBuilder.DropTable(
                name: "Threatment");

            migrationBuilder.RenameColumn(
                name: "ThreatmentId",
                table: "AppointmentTreatment",
                newName: "TreatmentId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentTreatment_ThreatmentId",
                table: "AppointmentTreatment",
                newName: "IX_AppointmentTreatment_TreatmentId");

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.Id);
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

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentTreatment_Treatment_TreatmentId",
                table: "AppointmentTreatment",
                column: "TreatmentId",
                principalTable: "Treatment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
