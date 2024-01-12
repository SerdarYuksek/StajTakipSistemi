using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StajId",
                table: "dosyas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_dosyas_StajId",
                table: "dosyas",
                column: "StajId");

            migrationBuilder.AddForeignKey(
                name: "FK_dosyas_stajBilgis_StajId",
                table: "dosyas",
                column: "StajId",
                principalTable: "stajBilgis",
                principalColumn: "StajBilgiID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dosyas_stajBilgis_StajId",
                table: "dosyas");

            migrationBuilder.DropIndex(
                name: "IX_dosyas_StajId",
                table: "dosyas");

            migrationBuilder.DropColumn(
                name: "StajId",
                table: "dosyas");
        }
    }
}
