﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestAPI.Data;

#nullable disable

namespace TestAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestAPI.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<int?>("DepartmentNumber")
                        .HasColumnType("int");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments", (string)null);

                    b.HasData(
                        new
                        {
                            DepartmentId = 1,
                            DepartmentName = "Managing department"
                        },
                        new
                        {
                            DepartmentId = 2,
                            DepartmentName = "Financial department"
                        },
                        new
                        {
                            DepartmentId = 3,
                            DepartmentName = "IT department"
                        },
                        new
                        {
                            DepartmentId = 4,
                            DepartmentName = "HRs department"
                        });
                });

            modelBuilder.Entity("TestAPI.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeId");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<DateTime?>("HireDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentId = 1,
                            Email = "zaid@g.com",
                            FirstName = "zaid",
                            HireDate = new DateTime(2023, 11, 28, 21, 0, 2, 976, DateTimeKind.Local).AddTicks(3876),
                            IsDeleted = false,
                            LastName = "albaik",
                            PhoneNumber = "0790000000",
                            Salary = 1000f
                        },
                        new
                        {
                            Id = 2,
                            DepartmentId = 2,
                            Email = "ali@g.com",
                            FirstName = "ali",
                            HireDate = new DateTime(2023, 11, 28, 21, 0, 2, 976, DateTimeKind.Local).AddTicks(3920),
                            IsDeleted = false,
                            LastName = "albaik",
                            PhoneNumber = "0790000000",
                            Salary = 2000f
                        },
                        new
                        {
                            Id = 3,
                            DepartmentId = 3,
                            Email = "ahmad@g.com",
                            FirstName = "ahmad",
                            HireDate = new DateTime(2023, 11, 28, 21, 0, 2, 976, DateTimeKind.Local).AddTicks(3929),
                            IsDeleted = false,
                            LastName = "albaik",
                            PhoneNumber = "0790000000",
                            Salary = 3000f
                        },
                        new
                        {
                            Id = 4,
                            DepartmentId = 4,
                            Email = "mohammad@g.com",
                            FirstName = "mohammad",
                            HireDate = new DateTime(2023, 11, 28, 21, 0, 2, 976, DateTimeKind.Local).AddTicks(3937),
                            IsDeleted = false,
                            LastName = "albaik",
                            PhoneNumber = "0790000000",
                            Salary = 4000f
                        });
                });

            modelBuilder.Entity("TestAPI.Models.Employee", b =>
                {
                    b.HasOne("TestAPI.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("DepartmentId_FK");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("TestAPI.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}