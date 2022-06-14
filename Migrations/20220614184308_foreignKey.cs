using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core6.Migrations
{
    public partial class foreignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FOODS_RESTURANTS_ResturantID",
                table: "FOODS");

            migrationBuilder.DropIndex(
                name: "IX_FOODS_ResturantID",
                table: "FOODS");

            migrationBuilder.DropColumn(
                name: "ResturantID",
                table: "FOODS");

            migrationBuilder.AlterColumn<long>(
                name: "RES_ID",
                table: "FOODS",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_FOODS_RES_ID",
                table: "FOODS",
                column: "RES_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FOODS_RESTURANTS_RES_ID",
                table: "FOODS",
                column: "RES_ID",
                principalTable: "RESTURANTS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FOODS_RESTURANTS_RES_ID",
                table: "FOODS");

            migrationBuilder.DropIndex(
                name: "IX_FOODS_RES_ID",
                table: "FOODS");

            migrationBuilder.AlterColumn<int>(
                name: "RES_ID",
                table: "FOODS",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "ResturantID",
                table: "FOODS",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_FOODS_ResturantID",
                table: "FOODS",
                column: "ResturantID");

            migrationBuilder.AddForeignKey(
                name: "FK_FOODS_RESTURANTS_ResturantID",
                table: "FOODS",
                column: "ResturantID",
                principalTable: "RESTURANTS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
