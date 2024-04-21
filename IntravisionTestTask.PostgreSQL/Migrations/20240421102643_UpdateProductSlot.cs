using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntravisionTestTask.PostgreSQL.Migrations
{
    public partial class UpdateProductSlot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSlots_ProductMachines_ProductMachineId",
                table: "ProductSlots");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductMachineId",
                table: "ProductSlots",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSlots_ProductMachines_ProductMachineId",
                table: "ProductSlots",
                column: "ProductMachineId",
                principalTable: "ProductMachines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSlots_ProductMachines_ProductMachineId",
                table: "ProductSlots");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductMachineId",
                table: "ProductSlots",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSlots_ProductMachines_ProductMachineId",
                table: "ProductSlots",
                column: "ProductMachineId",
                principalTable: "ProductMachines",
                principalColumn: "Id");
        }
    }
}
