using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeaShop.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_change_about : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Abouts",
                newName: "AboutTitle");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Abouts",
                newName: "AboutImageURL");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Abouts",
                newName: "AboutDescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AboutTitle",
                table: "Abouts",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "AboutImageURL",
                table: "Abouts",
                newName: "ImageURL");

            migrationBuilder.RenameColumn(
                name: "AboutDescription",
                table: "Abouts",
                newName: "Description");
        }
    }
}
