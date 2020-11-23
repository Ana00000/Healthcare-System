﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication.Backend.Model;

namespace WebApplication.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20201123222800_DbBasexx")]
    partial class DbBasexx
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Model.Accounts.Patient", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Contact")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Gender")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Guest")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ParentName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = "0002",
                            Contact = "kontakt",
                            DateOfBirth = new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "email",
                            Gender = "Zensko",
                            Guest = true,
                            Name = "Jelena",
                            ParentName = "otac",
                            SerialNumber = "a25d6b2e-f857-4697-ab84-ebd9582bd7d2",
                            Surname = "Tanjic"
                        },
                        new
                        {
                            Id = "0003",
                            Contact = "kontaktMica",
                            DateOfBirth = new DateTime(2018, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "emailMica",
                            Gender = "Zensko",
                            Guest = true,
                            Name = "Sara",
                            ParentName = "mama",
                            SerialNumber = "da60cb04-fffa-4d5e-bed6-d5a262fa53cf",
                            Surname = "Milic"
                        });
                });

            modelBuilder.Entity("Model.Blog.Feedback", b =>
                {
                    b.Property<string>("SerialNumber")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<bool>("Approved")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PatientId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Text")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("SerialNumber");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("Model.Hospital.Equipment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("health_clinic_class_diagram.Backend.Model.Hospital.Building", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Color")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Floors")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Shape")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Buildings");
                });
#pragma warning restore 612, 618
        }
    }
}