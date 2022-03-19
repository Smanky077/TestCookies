using Microsoft.EntityFrameworkCore.Migrations;

namespace CookesMafia.Migrations
{
    public partial class addFieldAllDebit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alldebit",
                table: "Debites");

            migrationBuilder.AddColumn<double>(
                name: "Alldebit",
                table: "Persones",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alldebit",
                table: "Persones");

            migrationBuilder.AddColumn<double>(
                name: "Alldebit",
                table: "Debites",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
