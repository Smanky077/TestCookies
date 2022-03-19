using Microsoft.EntityFrameworkCore.Migrations;

namespace CookesMafia.Migrations
{
    public partial class addFieldAllDebit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Alldebit",
                table: "Debites",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alldebit",
                table: "Debites");
        }
    }
}
