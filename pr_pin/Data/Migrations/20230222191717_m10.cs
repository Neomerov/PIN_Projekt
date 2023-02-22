using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pr_pin.Data.Migrations
{
    public partial class m10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Spol",
                table: "speakers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Spol",
                table: "speakers");
        }
    }
}
