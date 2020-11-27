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
    [Migration("20201127182853_migration1")]
    partial class migration1
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

                    b.Property<string>("AddressSerialNumber")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Citizenship")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Contact")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("EmploymentStatus")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FamilyDiseases")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Gender")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Guest")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("HealthInsuranceNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Image")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("MaritalStatus")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("MunicipalityOfBirth")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("MunicipalityOfResidence")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nationality")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ParentName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PersonalDiseases")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PlaceOfBirth")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PlaceOfResidence")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Profession")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("StateOfBirth")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("StateOfResidence")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("AddressSerialNumber");

                    b.ToTable("Patients");
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

            modelBuilder.Entity("Model.Util.Address", b =>
                {
                    b.Property<string>("SerialNumber")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Street")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("SerialNumber");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Model.Accounts.Patient", b =>
                {
                    b.HasOne("Model.Util.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressSerialNumber");
                });
#pragma warning restore 612, 618
        }
    }
}