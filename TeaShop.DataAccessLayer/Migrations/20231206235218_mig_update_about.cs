using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeaShop.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_update_about : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFooter",
                table: "Abouts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFooter",
                table: "Abouts");
        }
    }
}
