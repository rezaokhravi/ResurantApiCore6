using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core6.Migrations
{
    public partial class Init_Db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RESTURANTS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITLE = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PHONE = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    MOBILE = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    ADDRESS = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DESCRIPTIONS = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESTURANTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FOODS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RES_ID = table.Column<int>(type: "int", nullable: false),
                    TITLE = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DESCRIPTIONS = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ResturantID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FOODS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FOODS_RESTURANTS_ResturantID",
                        column: x => x.ResturantID,
                        principalTable: "RESTURANTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FOODS_ResturantID",
                table: "FOODS",
                column: "ResturantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FOODS");

            migrationBuilder.DropTable(
                name: "RESTURANTS");
        }
    }
}
