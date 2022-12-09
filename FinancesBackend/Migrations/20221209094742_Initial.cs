using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinancesBackend.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                });
            
            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Category", "DateTime", "Name", "Value" },
                values: new object[,]
                {
                    { 1, 5, new DateTime(2022, 9, 9, 10, 47, 42, 160, DateTimeKind.Local).AddTicks(8051), "Office restock", 245.5 },
                    { 2, 4, new DateTime(2022, 11, 27, 10, 47, 42, 160, DateTimeKind.Local).AddTicks(8090), "Business trip", 320.75 },
                    { 3, 2, new DateTime(2022, 12, 8, 10, 47, 42, 160, DateTimeKind.Local).AddTicks(8093), "Business dinner", 100.0 },
                    { 4, 3, new DateTime(2022, 12, 9, 10, 47, 42, 160, DateTimeKind.Local).AddTicks(8095), "PC restock", 7500.75 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");
        }
    }
}
