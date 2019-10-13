using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Practises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffRoles", x => x.Id);
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
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Surname = table.Column<string>(maxLength: 150, nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Note = table.Column<string>(maxLength: 1000, nullable: true),
                    Email = table.Column<string>(maxLength: 150, nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    StaffRoleID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_StaffRoles_StaffRoleID",
                        column: x => x.StaffRoleID,
                        principalTable: "StaffRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    When = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    StatusID = table.Column<Guid>(nullable: false),
                    PatientID = table.Column<Guid>(nullable: false),
                    PractiseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Persons_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Practises_PractiseId",
                        column: x => x.PractiseId,
                        principalTable: "Practises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    When = table.Column<DateTime>(nullable: false),
                    Information = table.Column<string>(nullable: false),
                    AppointmentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentLogs_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentStaff",
                columns: table => new
                {
                    AppointmentId = table.Column<Guid>(nullable: false),
                    StaffId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentStaff", x => new { x.AppointmentId, x.StaffId });
                    table.ForeignKey(
                        name: "FK_AppointmentStaff_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentStaff_Persons_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Discriminator", "Email", "Name", "Note", "Phone", "Surname" },
                values: new object[,]
                {
                    { new Guid("5b6c0ab6-c947-4279-9e35-53e2fa3cc1ff"), "Patient", "sviluppo.dangelo@gmail.com", "Patient one NAME", null, null, "Patient one Surname" },
                    { new Guid("99b48598-b815-4d08-aa20-9492f41738ea"), "Patient", "info@lucadangelo.it", "Patient two NAME", null, null, "Patient two Surname" }
                });

            migrationBuilder.InsertData(
                table: "Practises",
                columns: new[] { "Id", "Address", "Name", "Notes" },
                values: new object[,]
                {
                    { new Guid("8912aa35-1433-48fe-ae72-de2aaa38e37e"), null, "Practise One", "Seeded Practise Note One" },
                    { new Guid("9012aa35-1433-48fe-ae72-de2aaa38e37e"), null, "Practise Two", "Seeded Practise Note Two" }
                });

            migrationBuilder.InsertData(
                table: "StaffRoles",
                columns: new[] { "Id", "Note", "Role" },
                values: new object[,]
                {
                    { new Guid("1a637f30-a003-48af-8f46-21328531e9c8"), "Seeded staffRole one NOTE", "Seeded staffRole one" },
                    { new Guid("a24a0521-52e2-438b-a1d5-1db1f75c836b"), "Seeded staffRole two NOTE", "Seeded staffRole two" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Notes", "PatientID", "PractiseId", "StatusID", "When" },
                values: new object[,]
                {
                    { new Guid("644f17b2-6e34-4cad-bab5-8bba425270a4"), "Seeded Appointment One", new Guid("5b6c0ab6-c947-4279-9e35-53e2fa3cc1ff"), new Guid("8912aa35-1433-48fe-ae72-de2aaa38e37e"), new Guid("12d19fe2-ad58-409b-8ccb-0bf9f9eaa483"), new DateTime(2019, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified) },
                    { new Guid("9022622f-7adf-44ed-9efa-d362d937b5b8"), "Seeded Appointment Two", new Guid("99b48598-b815-4d08-aa20-9492f41738ea"), new Guid("9012aa35-1433-48fe-ae72-de2aaa38e37e"), new Guid("12d19fe2-ad58-409b-8ccb-0bf9f9eaa483"), new DateTime(2019, 6, 1, 14, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Discriminator", "Email", "Name", "Note", "Phone", "Surname", "StaffRoleID" },
                values: new object[,]
                {
                    { new Guid("1eb6bee1-e634-4b1e-9caf-5ce80b45604c"), "Staff", "sviluppo.dangelo@gmail.com", "Seeded staff one NAME", null, null, "Seeded staff one Surname", new Guid("1a637f30-a003-48af-8f46-21328531e9c8") },
                    { new Guid("ee243d91-ddf1-48f6-827d-0bfa6616bae1"), "Staff", "info@lucadangelo.it", "Seeded staff two NAME", null, null, "Seeded staff two Surname", new Guid("a24a0521-52e2-438b-a1d5-1db1f75c836b") }
                });

            migrationBuilder.InsertData(
                table: "AppointmentLogs",
                columns: new[] { "Id", "AppointmentId", "Information", "When" },
                values: new object[,]
                {
                    { new Guid("1d2f7b60-6236-4598-a28b-a03d03eb1b94"), new Guid("644f17b2-6e34-4cad-bab5-8bba425270a4"), "Seeded Log One for Appointment One", new DateTime(2019, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified) },
                    { new Guid("253d32ba-ba51-4f51-b151-caa02eb54f23"), new Guid("644f17b2-6e34-4cad-bab5-8bba425270a4"), "Seeded Log Two for Appointment One", new DateTime(2019, 5, 2, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3b3d41f9-ed3b-45b6-89d5-a878b007b32a"), new Guid("644f17b2-6e34-4cad-bab5-8bba425270a4"), "Seeded Log Three for Appointment One", new DateTime(2019, 6, 3, 4, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4e80d553-b1fd-4aed-9020-2206e2aa23cf"), new Guid("9022622f-7adf-44ed-9efa-d362d937b5b8"), "Seeded Log One for Appointment Two", new DateTime(2019, 6, 4, 5, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentLogs_AppointmentId",
                table: "AppointmentLogs",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientID",
                table: "Appointments",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PractiseId",
                table: "Appointments",
                column: "PractiseId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentStaff_StaffId",
                table: "AppointmentStaff",
                column: "StaffId");

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
                name: "IX_Persons_StaffRoleID",
                table: "Persons",
                column: "StaffRoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentLogs");

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
                name: "Practises");

            migrationBuilder.DropTable(
                name: "StaffRoles");
        }
    }
}
