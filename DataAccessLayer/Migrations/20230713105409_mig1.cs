using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ankets",
                columns: table => new
                {
                    AnketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    soru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cevap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cevap2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cevap3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cevap4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cevap5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cevap6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cevap7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cevap8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cevap9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cevap10 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ankets", x => x.AnketID);
                });

            migrationBuilder.CreateTable(
                name: "personals",
                columns: table => new
                {
                    KullaniciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TCNO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cinsiyet = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RePassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unvan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personals", x => x.KullaniciID);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    KullaniciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TCNO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cinsiyet = table.Column<bool>(type: "bit", nullable: false),
                    sınıf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RePassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OgrenciNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.KullaniciID);
                });

            migrationBuilder.CreateTable(
                name: "dosyas",
                columns: table => new
                {
                    DosyaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Akissemasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    degerledirmedok = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    yonerge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    basvuru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    devam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    degerlendirmeform = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    raporsablon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dosyas", x => x.DosyaID);
                    table.ForeignKey(
                        name: "FK_dosyas_students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "students",
                        principalColumn: "KullaniciID");
                });

            migrationBuilder.CreateTable(
                name: "stajBilgis",
                columns: table => new
                {
                    StajBilgiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdUnvan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alanı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YetkiliAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaksNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Başlamatrh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bitistrh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StajTürü = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stajsayi = table.Column<int>(type: "int", nullable: false),
                    ResmiTatil = table.Column<bool>(type: "bit", nullable: false),
                    CmtDahil = table.Column<bool>(type: "bit", nullable: false),
                    Egitim = table.Column<bool>(type: "bit", nullable: false),
                    KabulGün = table.Column<int>(type: "int", nullable: false),
                    Onay = table.Column<bool>(type: "bit", nullable: false),
                    Kabul = table.Column<bool>(type: "bit", nullable: false),
                    KatkıPayıOnay = table.Column<bool>(type: "bit", nullable: false),
                    RedSebep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stajBilgis", x => x.StajBilgiID);
                    table.ForeignKey(
                        name: "FK_stajBilgis_students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "students",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dosyas_StudentID",
                table: "dosyas",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_stajBilgis_StudentID",
                table: "stajBilgis",
                column: "StudentID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ankets");

            migrationBuilder.DropTable(
                name: "dosyas");

            migrationBuilder.DropTable(
                name: "personals");

            migrationBuilder.DropTable(
                name: "stajBilgis");

            migrationBuilder.DropTable(
                name: "students");
        }
    }
}
