using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pr_pin.Data.Migrations
{
    public partial class m5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "predavanja");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "predavanja",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
