using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LdDevWebApp.Migrations
{
    public partial class fist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentDurations",
                columns: table => new
                {
                    giudId = table.Column<Guid>(nullable: false),
                    timeDuration = table.Column<DateTime>(nullable: false),
                    timeDurationDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentDurations", x => x.giudId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Practises",
                columns: table => new
                {
                    giudId = table.Column<Guid>(nullable: false),
                    LocationName = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Practises", x => x.giudId);
                });

            migrationBuilder.CreateTable(
                name: "StaffRoles",
                columns: table => new
                {
                    giudStaffRoleId = table.Column<Guid>(nullable: false),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffRoles", x => x.giudStaffRoleId);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentTypes",
                columns: table => new
                {
                    giudId = table.Column<Guid>(nullable: false),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentTypes", x => x.giudId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    giudPersonId = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    surname = table.Column<string>(maxLength: 50, nullable: false),
                    phone = table.Column<string>(nullable: true),
                    personNote = table.Column<string>(maxLength: 1000, nullable: true),
                    mail = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    patientNote = table.Column<string>(maxLength: 1000, nullable: true),
                    staffNote = table.Column<string>(maxLength: 1000, nullable: true),
                    staffRolegiudStaffRoleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.giudPersonId);
                    table.ForeignKey(
                        name: "FK_Persons_StaffRoles_staffRolegiudStaffRoleId",
                        column: x => x.staffRolegiudStaffRoleId,
                        principalTable: "StaffRoles",
                        principalColumn: "giudStaffRoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    giudAptId = table.Column<Guid>(nullable: false),
                    aptScheduledDateTime = table.Column<DateTime>(nullable: false),
                    aptNotes = table.Column<string>(nullable: true),
                    aptScheduledDurationgiudId = table.Column<Guid>(nullable: false),
                    aptTreatmentTypegiudId = table.Column<Guid>(nullable: true),
                    aptPatientgiudPersonId = table.Column<Guid>(nullable: true),
                    practisegiudId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.giudAptId);
                    table.ForeignKey(
                        name: "FK_Appointments_Persons_aptPatientgiudPersonId",
                        column: x => x.aptPatientgiudPersonId,
                        principalTable: "Persons",
                        principalColumn: "giudPersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_AppointmentDurations_aptScheduledDurationgiudId",
                        column: x => x.aptScheduledDurationgiudId,
                        principalTable: "AppointmentDurations",
                        principalColumn: "giudId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_TreatmentTypes_aptTreatmentTypegiudId",
                        column: x => x.aptTreatmentTypegiudId,
                        principalTable: "TreatmentTypes",
                        principalColumn: "giudId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Practises_practisegiudId",
                        column: x => x.practisegiudId,
                        principalTable: "Practises",
                        principalColumn: "giudId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentStaff",
                columns: table => new
                {
                    giudAptId = table.Column<Guid>(nullable: false),
                    giudPersonId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentStaff", x => new { x.giudAptId, x.giudPersonId });
                    table.ForeignKey(
                        name: "FK_AppointmentStaff_Appointments_giudAptId",
                        column: x => x.giudAptId,
                        principalTable: "Appointments",
                        principalColumn: "giudAptId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentStaff_Persons_giudPersonId",
                        column: x => x.giudPersonId,
                        principalTable: "Persons",
                        principalColumn: "giudPersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_aptPatientgiudPersonId",
                table: "Appointments",
                column: "aptPatientgiudPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_aptScheduledDurationgiudId",
                table: "Appointments",
                column: "aptScheduledDurationgiudId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_aptTreatmentTypegiudId",
                table: "Appointments",
                column: "aptTreatmentTypegiudId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_practisegiudId",
                table: "Appointments",
                column: "practisegiudId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentStaff_giudPersonId",
                table: "AppointmentStaff",
                column: "giudPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_staffRolegiudStaffRoleId",
                table: "Persons",
                column: "staffRolegiudStaffRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentStaff");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "AppointmentDurations");

            migrationBuilder.DropTable(
                name: "TreatmentTypes");

            migrationBuilder.DropTable(
                name: "Practises");

            migrationBuilder.DropTable(
                name: "StaffRoles");
        }
    }
}
