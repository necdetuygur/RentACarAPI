using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentACar.Data.Migrations.RentACarDB
{
    public partial class Tablolar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Firma",
                columns: table => new
                {
                    FirmaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unvan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VergiNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firma", x => x.FirmaID);
                });

            migrationBuilder.CreateTable(
                name: "Kiralama",
                columns: table => new
                {
                    KiralamaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AliciID = table.Column<int>(type: "int", nullable: false),
                    ArabaID = table.Column<int>(type: "int", nullable: false),
                    BaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeslimTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kiralama", x => x.KiralamaID);
                });

            migrationBuilder.CreateTable(
                name: "Alici",
                columns: table => new
                {
                    AliciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TCKimlikNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CepTel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KiralamaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alici", x => x.AliciID);
                    table.ForeignKey(
                        name: "FK_Alici_Kiralama_KiralamaID",
                        column: x => x.KiralamaID,
                        principalTable: "Kiralama",
                        principalColumn: "KiralamaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Araba",
                columns: table => new
                {
                    ArabaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plaka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UretimYili = table.Column<int>(type: "int", nullable: false),
                    YakitTuru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EhliyetSinifi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KoltukSayisi = table.Column<int>(type: "int", nullable: false),
                    GunlukUcret = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    FirmaID = table.Column<int>(type: "int", nullable: false),
                    KiralamaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Araba", x => x.ArabaID);
                    table.ForeignKey(
                        name: "FK_Araba_Firma_FirmaID",
                        column: x => x.FirmaID,
                        principalTable: "Firma",
                        principalColumn: "FirmaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Araba_Kiralama_KiralamaID",
                        column: x => x.KiralamaID,
                        principalTable: "Kiralama",
                        principalColumn: "KiralamaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alici_KiralamaID",
                table: "Alici",
                column: "KiralamaID");

            migrationBuilder.CreateIndex(
                name: "IX_Araba_FirmaID",
                table: "Araba",
                column: "FirmaID");

            migrationBuilder.CreateIndex(
                name: "IX_Araba_KiralamaID",
                table: "Araba",
                column: "KiralamaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alici");

            migrationBuilder.DropTable(
                name: "Araba");

            migrationBuilder.DropTable(
                name: "Firma");

            migrationBuilder.DropTable(
                name: "Kiralama");
        }
    }
}
