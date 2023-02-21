using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CAR",
                columns: table => new
                {
                    CAR_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CAR_CATEGORY_ID = table.Column<int>(type: "int", nullable: false),
                    PLATE_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CAR_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DELETED = table.Column<int>(type: "int", nullable: false),
                    VERSION = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAR", x => x.CAR_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CAR");
        }
    }
}
