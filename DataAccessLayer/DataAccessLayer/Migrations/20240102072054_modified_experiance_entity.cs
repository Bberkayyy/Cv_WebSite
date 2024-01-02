using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class modified_experiance_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Experiances",
                newName: "TaskName");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Experiances",
                newName: "CompanyName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskName",
                table: "Experiances",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Experiances",
                newName: "ImageUrl");
        }
    }
}
