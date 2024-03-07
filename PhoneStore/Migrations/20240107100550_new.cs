using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneStore.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CityUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityUsers_CountryUsers_Country_Id",
                        column: x => x.Country_Id,
                        principalTable: "CountryUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityUsers_Country_Id",
                table: "CityUsers",
                column: "Country_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityUsers");

            migrationBuilder.DropTable(
                name: "CountryUsers");
        }
    }
}
