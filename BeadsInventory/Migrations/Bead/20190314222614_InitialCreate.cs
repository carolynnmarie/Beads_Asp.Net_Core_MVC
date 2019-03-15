using Microsoft.EntityFrameworkCore.Migrations;

namespace BeadsInventory.Migrations.Bead
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bead",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Material = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Size_MM = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price_Point = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bead", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bead");
        }
    }
}
