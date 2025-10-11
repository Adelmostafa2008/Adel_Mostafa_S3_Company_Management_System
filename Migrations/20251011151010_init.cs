using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Company_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjectName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Budget = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employee_department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "department",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contract",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ContractNumber = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contract_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employeeProject",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeProject", x => new { x.EmployeeId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_employeeProject_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employeeProject_project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "department",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Giza", "Backend" },
                    { 2, "Cairo", "Frontend" },
                    { 3, "Alexandria", "HR" }
                });

            migrationBuilder.InsertData(
                table: "project",
                columns: new[] { "Id", "Budget", "EndTime", "ProjectName", "StartDate" },
                values: new object[,]
                {
                    { 1, 5000m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ManagementSystem", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 15000m, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ECommercePlatform", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 8000m, null, "MobileApp", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "employee",
                columns: new[] { "Id", "DepartmentId", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, 1, "adel@gmail.com", "Adel", "01282768929" },
                    { 2, 2, "sara@gmail.com", "Sara", "01125678945" },
                    { 3, 1, "omar@gmail.com", "Omar", "01054789632" },
                    { 4, 3, "nour@gmail.com", "Nour", "01587456321" }
                });

            migrationBuilder.InsertData(
                table: "contract",
                columns: new[] { "Id", "ContractNumber", "EmployeeId", "EndDate", "Salary", "StartDate" },
                values: new object[,]
                {
                    { 1, "1001", 1, new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15000m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "1002", 2, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12000m, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "1003", 3, new DateTime(2026, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 18000m, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "1004", 4, new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10000m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "employeeProject",
                columns: new[] { "EmployeeId", "ProjectId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 1 },
                    { 3, 3 },
                    { 4, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_contract_ContractNumber",
                table: "contract",
                column: "ContractNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_contract_EmployeeId",
                table: "contract",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_department_Name",
                table: "department",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_employee_DepartmentId",
                table: "employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_employeeProject_ProjectId",
                table: "employeeProject",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contract");

            migrationBuilder.DropTable(
                name: "employeeProject");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "project");

            migrationBuilder.DropTable(
                name: "department");
        }
    }
}
