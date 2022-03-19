using Microsoft.EntityFrameworkCore.Migrations;

namespace CookesMafia.Migrations
{
    public partial class addtablDebit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Debit",
                table: "Persones");

            migrationBuilder.CreateTable(
                name: "Debites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(nullable: false),
                    BorrowerId = table.Column<int>(nullable: false),
                    DebSum = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Debites_Persones_BorrowerId",
                        column: x => x.BorrowerId,
                        principalTable: "Persones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Debites_Persones_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Debites_BorrowerId",
                table: "Debites",
                column: "BorrowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Debites_PersonId",
                table: "Debites",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Debites");

            migrationBuilder.AddColumn<double>(
                name: "Debit",
                table: "Persones",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
