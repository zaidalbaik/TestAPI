using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DepartmentName = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    DepartmentNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Salary = table.Column<float>(type: "real", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "DepartmentId_FK",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentName", "DepartmentNumber" },
                values: new object[,]
                {
                    { 1, "Managing department", null },
                    { 2, "Financial department", null },
                    { 3, "IT department", null },
                    { 4, "HRs department", null }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DateDeleted", "DepartmentId", "Email", "FirstName", "HireDate", "ImagePath", "IsDeleted", "LastName", "PhoneNumber", "Salary" },
                values: new object[,]
                {
                    { 1, null, 1, "zaid@g.com", "zaid", new DateTime(2023, 11, 28, 21, 0, 2, 976, DateTimeKind.Local).AddTicks(3876), null, false, "albaik", "0790000000", 1000f },
                    { 2, null, 2, "ali@g.com", "ali", new DateTime(2023, 11, 28, 21, 0, 2, 976, DateTimeKind.Local).AddTicks(3920), null, false, "albaik", "0790000000", 2000f },
                    { 3, null, 3, "ahmad@g.com", "ahmad", new DateTime(2023, 11, 28, 21, 0, 2, 976, DateTimeKind.Local).AddTicks(3929), null, false, "albaik", "0790000000", 3000f },
                    { 4, null, 4, "mohammad@g.com", "mohammad", new DateTime(2023, 11, 28, 21, 0, 2, 976, DateTimeKind.Local).AddTicks(3937), null, false, "albaik", "0790000000", 4000f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
