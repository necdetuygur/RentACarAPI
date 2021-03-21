using Microsoft.EntityFrameworkCore.Migrations;

namespace RentACar.Data.Migrations
{
    public partial class AddArabaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    KoltukSayisi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Araba", x => x.ArabaID);
                });

            migrationBuilder.InsertData(
                table: "Araba",
                columns: new[] { "ArabaID", "EhliyetSinifi", "KoltukSayisi", "Marka", "Model", "Plaka", "UretimYili", "YakitTuru" },
                values: new object[] { 1, "B", 5, "Tofaş", "Doğan", "43HD101", 1995, "Benzin" });

            migrationBuilder.InsertData(
                table: "Araba",
                columns: new[] { "ArabaID", "EhliyetSinifi", "KoltukSayisi", "Marka", "Model", "Plaka", "UretimYili", "YakitTuru" },
                values: new object[] { 2, "B", 5, "Tofaş", "Şahin", "43HD102", 1995, "Benzin" });

            migrationBuilder.InsertData(
                table: "Araba",
                columns: new[] { "ArabaID", "EhliyetSinifi", "KoltukSayisi", "Marka", "Model", "Plaka", "UretimYili", "YakitTuru" },
                values: new object[] { 3, "B", 5, "Tofaş", "Kartal", "43HD103", 1995, "Benzin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Araba");
        }
    }
}
