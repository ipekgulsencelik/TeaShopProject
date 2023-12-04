using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeaShop.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_question : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsHome = table.Column<bool>(type: "bit", nullable: false),
                    QuestionStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
