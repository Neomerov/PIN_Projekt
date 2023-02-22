using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pr_pin.Data.Migrations
{
    public partial class m8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_predavanja_speakers_SpeakerId",
                table: "predavanja");

            migrationBuilder.DropIndex(
                name: "IX_predavanja_SpeakerId",
                table: "predavanja");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "predavanja");

            migrationBuilder.DropColumn(
                name: "SpeakerId",
                table: "predavanja");

            migrationBuilder.CreateTable(
                name: "PredavanjaSpeaker",
                columns: table => new
                {
                    PredavanjaPredId = table.Column<int>(type: "int", nullable: false),
                    SpeakerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredavanjaSpeaker", x => new { x.PredavanjaPredId, x.SpeakerId });
                    table.ForeignKey(
                        name: "FK_PredavanjaSpeaker_predavanja_PredavanjaPredId",
                        column: x => x.PredavanjaPredId,
                        principalTable: "predavanja",
                        principalColumn: "PredId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PredavanjaSpeaker_speakers_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "speakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PredavanjaSpeaker_SpeakerId",
                table: "PredavanjaSpeaker",
                column: "SpeakerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PredavanjaSpeaker");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "predavanja",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpeakerId",
                table: "predavanja",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_predavanja_SpeakerId",
                table: "predavanja",
                column: "SpeakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_predavanja_speakers_SpeakerId",
                table: "predavanja",
                column: "SpeakerId",
                principalTable: "speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
