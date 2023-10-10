using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeuDontEstLeHeros.Core.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjoutModelParagrapheQuestionReponse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reponse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Proposition = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reponse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paragraphe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Titre = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paragraphe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paragraphe_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionReponse",
                columns: table => new
                {
                    QuestionsId = table.Column<int>(type: "int", nullable: false),
                    ReponsesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionReponse", x => new { x.QuestionsId, x.ReponsesId });
                    table.ForeignKey(
                        name: "FK_QuestionReponse_Question_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionReponse_Reponse_ReponsesId",
                        column: x => x.ReponsesId,
                        principalTable: "Reponse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paragraphe_QuestionId",
                table: "Paragraphe",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionReponse_ReponsesId",
                table: "QuestionReponse",
                column: "ReponsesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paragraphe");

            migrationBuilder.DropTable(
                name: "QuestionReponse");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Reponse");
        }
    }
}
