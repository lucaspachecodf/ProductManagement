using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoGlass.ProductManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ManufacturingDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SupplierCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierCNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
