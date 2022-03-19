using Microsoft.EntityFrameworkCore.Migrations;

namespace CookesMafia.Migrations
{
    public partial class updat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Money",
                table: "Persones",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Debit",
                table: "Persones",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Money",
                table: "Persones",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "Debit",
                table: "Persones",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
