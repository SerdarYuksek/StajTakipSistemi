using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_stajBilgis_StudentID",
                table: "stajBilgis");

            migrationBuilder.CreateIndex(
                name: "IX_stajBilgis_StudentID",
                table: "stajBilgis",
                column: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_stajBilgis_StudentID",
                table: "stajBilgis");

            migrationBuilder.CreateIndex(
                name: "IX_stajBilgis_StudentID",
                table: "stajBilgis",
                column: "StudentID",
                unique: true);
        }
    }
}
