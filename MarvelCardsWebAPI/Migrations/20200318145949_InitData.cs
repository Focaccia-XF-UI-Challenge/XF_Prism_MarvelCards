using Microsoft.EntityFrameworkCore.Migrations;

namespace MarvelCardsWebAPI.Migrations
{
    public partial class InitData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Hero",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeroName = table.Column<string>(nullable: true),
                    HeroNameLine1 = table.Column<string>(nullable: true),
                    HeroNameLine2 = table.Column<string>(nullable: true),
                    RealName = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    HeroColor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hero", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Hero",
                columns: new[] { "Id", "HeroColor", "HeroName", "HeroNameLine1", "HeroNameLine2", "Image", "RealName" },
                values: new object[] { 1, "#C51925", "spider man", null, null, "spiderman.png", "peter parker" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Hero",
                columns: new[] { "Id", "HeroColor", "HeroName", "HeroNameLine1", "HeroNameLine2", "Image", "RealName" },
                values: new object[] { 2, "#DF8E04", "iron man", null, null, "ironman.png", "tony stark" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Hero",
                columns: new[] { "Id", "HeroColor", "HeroName", "HeroNameLine1", "HeroNameLine2", "Image", "RealName" },
                values: new object[] { 3, "#5DDF04", "This is Test Data", null, null, "ironman.png", "tony stark" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hero",
                schema: "dbo");
        }
    }
}
