using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LisansProje.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Licences",
                columns: table => new
                {
                    LisansID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LisansBaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToplamYil = table.Column<int>(type: "int", nullable: false),
                    LisansKisiSayisi = table.Column<int>(type: "int", nullable: false),
                    KurumAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KurumIpAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YazilimAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YazilimProtokolNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LisansKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SifreliId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Durum = table.Column<byte>(type: "tinyint", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kaydeden_K_Id = table.Column<int>(type: "int", nullable: false),
                    DegisiklikTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degistiren_K_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licences", x => x.LisansID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Licences");
        }
    }
}
