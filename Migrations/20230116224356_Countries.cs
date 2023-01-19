using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ghitau_Emanuela_aplication.Migrations
{
    public partial class Countries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Perfume");

            migrationBuilder.AddColumn<int>(
                name: "CountryID",
                table: "Perfume",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShopID",
                table: "Perfume",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perfume_CountryID",
                table: "Perfume",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Perfume_ShopID",
                table: "Perfume",
                column: "ShopID");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfume_Country_CountryID",
                table: "Perfume",
                column: "CountryID",
                principalTable: "Country",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfume_Shop_ShopID",
                table: "Perfume",
                column: "ShopID",
                principalTable: "Shop",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfume_Country_CountryID",
                table: "Perfume");

            migrationBuilder.DropForeignKey(
                name: "FK_Perfume_Shop_ShopID",
                table: "Perfume");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Shop");

            migrationBuilder.DropIndex(
                name: "IX_Perfume_CountryID",
                table: "Perfume");

            migrationBuilder.DropIndex(
                name: "IX_Perfume_ShopID",
                table: "Perfume");

            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "Perfume");

            migrationBuilder.DropColumn(
                name: "ShopID",
                table: "Perfume");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Perfume",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
