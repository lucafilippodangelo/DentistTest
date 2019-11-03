﻿// <auto-generated />
using System;
using DentistCore2._2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LdDevWebApp.Models.Entities.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Notes");

                    b.Property<Guid>("PatientID");

                    b.Property<Guid?>("PractiseId");

                    b.Property<Guid>("StatusID");

                    b.Property<DateTime>("When");

                    b.HasKey("Id");

                    b.HasIndex("PatientID");

                    b.HasIndex("PractiseId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("644f17b2-6e34-4cad-bab5-8bba425270a4"),
                            Notes = "Seeded Appointment One",
                            PatientID = new Guid("5b6c0ab6-c947-4279-9e35-53e2fa3cc1ff"),
                            PractiseId = new Guid("8912aa35-1433-48fe-ae72-de2aaa38e37e"),
                            StatusID = new Guid("12d19fe2-ad58-409b-8ccb-0bf9f9eaa483"),
                            When = new DateTime(2019, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("9022622f-7adf-44ed-9efa-d362d937b5b8"),
                            Notes = "Seeded Appointment Two",
                            PatientID = new Guid("99b48598-b815-4d08-aa20-9492f41738ea"),
                            PractiseId = new Guid("9012aa35-1433-48fe-ae72-de2aaa38e37e"),
                            StatusID = new Guid("12d19fe2-ad58-409b-8ccb-0bf9f9eaa483"),
                            When = new DateTime(2019, 6, 1, 14, 30, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("LdDevWebApp.Models.Entities.AppointmentLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AppointmentId");

                    b.Property<string>("Information")
                        .IsRequired();

                    b.Property<DateTime>("When");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.ToTable("AppointmentLogs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1d2f7b60-6236-4598-a28b-a03d03eb1b94"),
                            AppointmentId = new Guid("644f17b2-6e34-4cad-bab5-8bba425270a4"),
                            Information = "Seeded Log One for Appointment One",
                            When = new DateTime(2019, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("253d32ba-ba51-4f51-b151-caa02eb54f23"),
                            AppointmentId = new Guid("644f17b2-6e34-4cad-bab5-8bba425270a4"),
                            Information = "Seeded Log Two for Appointment One",
                            When = new DateTime(2019, 5, 2, 14, 30, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("3b3d41f9-ed3b-45b6-89d5-a878b007b32a"),
                            AppointmentId = new Guid("644f17b2-6e34-4cad-bab5-8bba425270a4"),
                            Information = "Seeded Log Three for Appointment One",
                            When = new DateTime(2019, 6, 3, 4, 30, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("4e80d553-b1fd-4aed-9020-2206e2aa23cf"),
                            AppointmentId = new Guid("9022622f-7adf-44ed-9efa-d362d937b5b8"),
                            Information = "Seeded Log One for Appointment Two",
                            When = new DateTime(2019, 6, 4, 5, 30, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("LdDevWebApp.Models.Entities.AppointmentStaff", b =>
                {
                    b.Property<Guid>("AppointmentId");

                    b.Property<Guid>("StaffId");

                    b.HasKey("AppointmentId", "StaffId");

                    b.HasIndex("StaffId");

                    b.ToTable("AppointmentStaff");
                });

            modelBuilder.Entity("LdDevWebApp.Models.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Note")
                        .HasMaxLength(1000);

                    b.Property<string>("Phone");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("LdDevWebApp.Models.Entities.Practise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.HasKey("Id");

                    b.ToTable("Practises");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8912aa35-1433-48fe-ae72-de2aaa38e37e"),
                            Name = "Practise One",
                            Notes = "Seeded Practise Note One"
                        },
                        new
                        {
                            Id = new Guid("9012aa35-1433-48fe-ae72-de2aaa38e37e"),
                            Name = "Practise Two",
                            Notes = "Seeded Practise Note Two"
                        });
                });

            modelBuilder.Entity("LdDevWebApp.Models.Entities.StaffRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Note");

                    b.Property<string>("Role");

                    b.HasKey("Id");

                    b.ToTable("StaffRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1a637f30-a003-48af-8f46-21328531e9c8"),
                            Note = "Seeded staffRole one NOTE",
                            Role = "Seeded staffRole one"
                        },
                        new
                        {
                            Id = new Guid("a24a0521-52e2-438b-a1d5-1db1f75c836b"),
                            Note = "Seeded staffRole two NOTE",
                            Role = "Seeded staffRole two"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("LdDevWebApp.Models.Entities.Patient", b =>
                {
                    b.HasBaseType("LdDevWebApp.Models.Entities.Person");

                    b.HasDiscriminator().HasValue("Patient");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5b6c0ab6-c947-4279-9e35-53e2fa3cc1ff"),
                            Email = "sviluppo.dangelo@gmail.com",
                            IsActive = true,
                            Name = "Patient one NAME",
                            Surname = "Patient one Surname"
                        },
                        new
                        {
                            Id = new Guid("99b48598-b815-4d08-aa20-9492f41738ea"),
                            Email = "info@lucadangelo.it",
                            IsActive = true,
                            Name = "Patient two NAME",
                            Surname = "Patient two Surname"
                        });
                });

            modelBuilder.Entity("LdDevWebApp.Models.Entities.Staff", b =>
                {
                    b.HasBaseType("LdDevWebApp.Models.Entities.Person");

                    b.Property<Guid>("StaffRoleID");

                    b.HasIndex("StaffRoleID");

                    b.HasDiscriminator().HasValue("Staff");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1eb6bee1-e634-4b1e-9caf-5ce80b45604c"),
                            Email = "sviluppo.dangelo@gmail.com",
                            IsActive = true,
                            Name = "Seeded staff one name",
                            Surname = "Seeded staff one Surname",
                            StaffRoleID = new Guid("1a637f30-a003-48af-8f46-21328531e9c8")
                        },
                        new
                        {
                            Id = new Guid("ee243d91-ddf1-48f6-827d-0bfa6616bae1"),
                            Email = "info@lucadangelo.it",
                            IsActive = true,
                            Name = "Seeded staff two name",
                            Surname = "Seeded staff two Surname",
                            StaffRoleID = new Guid("a24a0521-52e2-438b-a1d5-1db1f75c836b")
                        },
                        new
                        {
                            Id = new Guid("f6ad3484-6916-4b5b-9a7e-5bbf69d9996a"),
                            Email = "info@lucadangelo.it",
                            IsActive = true,
                            Name = "Seeded staff three name",
                            Surname = "Seeded staff three Surname",
                            StaffRoleID = new Guid("a24a0521-52e2-438b-a1d5-1db1f75c836b")
                        },
                        new
                        {
                            Id = new Guid("567f81a6-ff37-4329-ae7b-3364f781700f"),
                            Email = "info@lucadangelo.it",
                            IsActive = true,
                            Name = "Seeded staff four name",
                            Surname = "Seeded staff four Surname",
                            StaffRoleID = new Guid("a24a0521-52e2-438b-a1d5-1db1f75c836b")
                        });
                });

            modelBuilder.Entity("LdDevWebApp.Models.Entities.Appointment", b =>
                {
                    b.HasOne("LdDevWebApp.Models.Entities.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LdDevWebApp.Models.Entities.Practise", "Practise")
                        .WithMany("Appointments")
                        .HasForeignKey("PractiseId");
                });

            modelBuilder.Entity("LdDevWebApp.Models.Entities.AppointmentLog", b =>
                {
                    b.HasOne("LdDevWebApp.Models.Entities.Appointment", "Appointment")
                        .WithMany("AppointmentLogs")
                        .HasForeignKey("AppointmentId");
                });

            modelBuilder.Entity("LdDevWebApp.Models.Entities.AppointmentStaff", b =>
                {
                    b.HasOne("LdDevWebApp.Models.Entities.Appointment", "Appointment")
                        .WithMany("AppointmentStaff")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LdDevWebApp.Models.Entities.Staff", "Staff")
                        .WithMany("AppointmentStaff")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LdDevWebApp.Models.Entities.Staff", b =>
                {
                    b.HasOne("LdDevWebApp.Models.Entities.StaffRole", "StaffRole")
                        .WithMany("StaffRoleOfStaff")
                        .HasForeignKey("StaffRoleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
