using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntravisionTestTask.PostgreSQL.Migrations
{
    public partial class UpdateProduct3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Products_Title",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Products_Title",
                table: "Products",
                column: "Title");
        }
    }
}
