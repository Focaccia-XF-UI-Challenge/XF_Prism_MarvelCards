using Microsoft.EntityFrameworkCore.Migrations;

namespace MarvelCardsWebAPI.Migrations
{
    public partial class InitData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Hero",
                columns: new[] { "Id", "HeroColor", "HeroName", "HeroNameLine1", "HeroNameLine2", "Image", "RealName" },
                values: new object[] { 4, "#040DDF", "This is Test Data2", null, null, "ironman.png", "tony stark" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Hero",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
