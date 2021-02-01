using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarvelCardsWebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DB_CRDAT",
                schema: "dbo",
                table: "Hero",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DB_CRUSR",
                schema: "dbo",
                table: "Hero",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DB_TRDAT",
                schema: "dbo",
                table: "Hero",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DB_TRUSR",
                schema: "dbo",
                table: "Hero",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Hero",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DB_CRDAT", "DB_CRUSR" },
                values: new object[] { new DateTime(2020, 3, 31, 11, 2, 4, 776, DateTimeKind.Local).AddTicks(7058), "David" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Hero",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DB_CRDAT", "DB_CRUSR" },
                values: new object[] { new DateTime(2020, 3, 31, 11, 2, 4, 777, DateTimeKind.Local).AddTicks(6089), "David" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Hero",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DB_CRDAT", "DB_CRUSR" },
                values: new object[] { new DateTime(2020, 3, 31, 11, 2, 4, 777, DateTimeKind.Local).AddTicks(6171), "David" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Hero",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DB_CRDAT", "DB_CRUSR" },
                values: new object[] { new DateTime(2020, 3, 31, 11, 2, 4, 777, DateTimeKind.Local).AddTicks(6177), "David" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DB_CRDAT",
                schema: "dbo",
                table: "Hero");

            migrationBuilder.DropColumn(
                name: "DB_CRUSR",
                schema: "dbo",
                table: "Hero");

            migrationBuilder.DropColumn(
                name: "DB_TRDAT",
                schema: "dbo",
                table: "Hero");

            migrationBuilder.DropColumn(
                name: "DB_TRUSR",
                schema: "dbo",
                table: "Hero");
        }
    }
}
