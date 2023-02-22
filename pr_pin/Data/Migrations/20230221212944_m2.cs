using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pr_pin.Data.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "speakers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tema = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_speakers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "predavanja",
                columns: table => new
                {
                    PredId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NaslovTeme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datumPredavanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpeakerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_predavanja", x => x.PredId);
                    table.ForeignKey(
                        name: "FK_predavanja_speakers_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "speakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_predavanja_SpeakerId",
                table: "predavanja",
                column: "SpeakerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "predavanja");

            migrationBuilder.DropTable(
                name: "speakers");
        }
    }
}
