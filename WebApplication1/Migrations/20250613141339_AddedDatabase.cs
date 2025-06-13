using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Nursery",
                columns: table => new
                {
                    NurseryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EstablishedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nursery", x => x.NurseryId);
                });

            migrationBuilder.CreateTable(
                name: "Tree_Species",
                columns: table => new
                {
                    SpeciesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LatinName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GrowthTimeInYears = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tree_Species", x => x.SpeciesId);
                });

            migrationBuilder.CreateTable(
                name: "Seedling_Batch",
                columns: table => new
                {
                    BatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NurseryId = table.Column<int>(type: "int", nullable: false),
                    SpeciesId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SownDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReadyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seedling_Batch", x => x.BatchId);
                    table.ForeignKey(
                        name: "FK_Seedling_Batch_Nursery_NurseryId",
                        column: x => x.NurseryId,
                        principalTable: "Nursery",
                        principalColumn: "NurseryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seedling_Batch_Tree_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Tree_Species",
                        principalColumn: "SpeciesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Responsible",
                columns: table => new
                {
                    BatchID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsible", x => new { x.BatchID, x.EmployeeID });
                    table.ForeignKey(
                        name: "FK_Responsible_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Responsible_Seedling_Batch_BatchID",
                        column: x => x.BatchID,
                        principalTable: "Seedling_Batch",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Responsible_EmployeeID",
                table: "Responsible",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Seedling_Batch_NurseryId",
                table: "Seedling_Batch",
                column: "NurseryId");

            migrationBuilder.CreateIndex(
                name: "IX_Seedling_Batch_SpeciesId",
                table: "Seedling_Batch",
                column: "SpeciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responsible");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Seedling_Batch");

            migrationBuilder.DropTable(
                name: "Nursery");

            migrationBuilder.DropTable(
                name: "Tree_Species");
        }
    }
}
