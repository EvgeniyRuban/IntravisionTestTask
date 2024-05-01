using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntravisionTestTask.PostgreSQL.Migrations
{
    public partial class UpdateProduct2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductMachines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMachines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                    table.UniqueConstraint("AK_ProductTypes_Title", x => x.Title);
                });

            migrationBuilder.CreateTable(
                name: "ProductSlots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductMachineId = table.Column<Guid>(type: "uuid", nullable: true),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSlots_ProductMachines_ProductMachineId",
                        column: x => x.ProductMachineId,
                        principalTable: "ProductMachines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductTypeId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductSlotId = table.Column<Guid>(type: "uuid", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.UniqueConstraint("AK_Products_Title", x => x.Title);
                    table.ForeignKey(
                        name: "FK_Products_ProductSlots_ProductSlotId",
                        column: x => x.ProductSlotId,
                        principalTable: "ProductSlots",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductSlotId",
                table: "Products",
                column: "ProductSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSlots_ProductMachineId",
                table: "ProductSlots",
                column: "ProductMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_Title",
                table: "ProductTypes",
                column: "Title",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductSlots");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "ProductMachines");
        }
    }
}
