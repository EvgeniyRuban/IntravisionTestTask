using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntravisionTestTask.PostgreSQL.Migrations
{
    public partial class UpdateProductType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ProductTypes_Title",
                table: "ProductTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_ProductTypes_Title",
                table: "ProductTypes",
                column: "Title");
        }
    }
}
