using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentACar.Data.Migrations
{
    public partial class Initial : Migration
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
                    GunlukUcret = table.Column<decimal>(type: "decimal", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Alici",
                columns: new[] { "AliciID", "Ad", "Adres", "CepTel", "KiralamaID", "Mail", "Soyad", "TCKimlikNo" },
                values: new object[,]
                {
                    { 1, "Melek", "Göztepe İzmir", "05385161703", null, "melekalperatmaca@gmail.com", "Alper Atmaca", "22222222220" },
                    { 2, "Necdet", "Yeşilyurt İzmir", "05462253671", null, "necdet.uygur@gmail.com", "Uygur", "11111111110" },
                    { 3, "Ömer", "Bornova İzmir", "05465675080", null, "omerdgdvrn21@gmail.com", "Dağdeviren", "44444444440" }
                });

            migrationBuilder.InsertData(
                table: "Firma",
                columns: new[] { "FirmaID", "Adres", "Mail", "Telefon", "Unvan", "VergiNo" },
                values: new object[,]
                {
                    { 1, "Göztepe", "atmacalper@atmacalper.com", "0535210", "AtmacAlpers", "A123" },
                    { 2, "Yeşilyurt", "uygurs@me.com", "0326569", "Uygurs", "Y125" },
                    { 3, "Bornova", "dagdeviren@dagdeviren.com", "0789542", "Dagdevirens", "D567" }
                });

            migrationBuilder.InsertData(
                table: "Kiralama",
                columns: new[] { "KiralamaID", "AliciID", "ArabaID", "BaslangicTarihi", "BitisTarihi", "TeslimTarihi" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, 2, 2, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, 3, 3, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Araba",
                columns: new[] { "ArabaID", "EhliyetSinifi", "FirmaID", "GunlukUcret", "KiralamaID", "KoltukSayisi", "Marka", "Model", "Plaka", "UretimYili", "YakitTuru" },
                values: new object[,]
                {
                    { 1, "B", 1, 50m, null, 5, "Tofaş", "Doğan", "43HD101", 1995, "Benzin" },
                    { 2, "B", 2, 150m, null, 5, "Wolksvagen", "Polo", "34FP8146", 2012, "Dizel" },
                    { 4, "B", 2, 200m, null, 5, "BMV", "1.16", "35FST17", 2016, "Dizel" },
                    { 3, "B", 3, 75m, null, 5, "Tofaş", "Şahin", "35EHT84", 2000, "Benzin" }
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
