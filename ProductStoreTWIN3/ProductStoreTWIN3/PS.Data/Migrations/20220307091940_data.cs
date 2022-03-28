using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.Data.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "Products",
                newName: "Adress_City");

            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "Products",
                newName: "Adress_StreetAdress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress_City",
                table: "Products",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "Adress_StreetAdress",
                table: "Products",
                newName: "StreetAddress");
        }
    }
}
