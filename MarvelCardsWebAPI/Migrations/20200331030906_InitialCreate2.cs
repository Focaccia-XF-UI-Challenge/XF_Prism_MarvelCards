using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarvelCardsWebAPI.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HeroName",
                schema: "dbo",
                table: "Hero",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HeroColor",
                schema: "dbo",
                table: "Hero",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DB_CRUSR",
                schema: "dbo",
                table: "Hero",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Hero",
                keyColumn: "Id",
                keyValue: 1,
                column: "DB_CRDAT",
                value: new DateTime(2020, 3, 31, 11, 9, 6, 590, DateTimeKind.Local).AddTicks(2106));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Hero",
                keyColumn: "Id",
                keyValue: 2,
                column: "DB_CRDAT",
                value: new DateTime(2020, 3, 31, 11, 9, 6, 590, DateTimeKind.Local).AddTicks(7176));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Hero",
                keyColumn: "Id",
                keyValue: 3,
                column: "DB_CRDAT",
                value: new DateTime(2020, 3, 31, 11, 9, 6, 590, DateTimeKind.Local).AddTicks(7230));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Hero",
                keyColumn: "Id",
                keyValue: 4,
                column: "DB_CRDAT",
                value: new DateTime(2020, 3, 31, 11, 9, 6, 590, DateTimeKind.Local).AddTicks(7233));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HeroName",
                schema: "dbo",
                table: "Hero",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "HeroColor",
                schema: "dbo",
                table: "Hero",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DB_CRUSR",
                schema: "dbo",
                table: "Hero",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Hero",
                keyColumn: "Id",
                keyValue: 1,
                column: "DB_CRDAT",
                value: new DateTime(2020, 3, 31, 11, 2, 4, 776, DateTimeKind.Local).AddTicks(7058));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Hero",
                keyColumn: "Id",
                keyValue: 2,
                column: "DB_CRDAT",
                value: new DateTime(2020, 3, 31, 11, 2, 4, 777, DateTimeKind.Local).AddTicks(6089));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Hero",
                keyColumn: "Id",
                keyValue: 3,
                column: "DB_CRDAT",
                value: new DateTime(2020, 3, 31, 11, 2, 4, 777, DateTimeKind.Local).AddTicks(6171));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Hero",
                keyColumn: "Id",
                keyValue: 4,
                column: "DB_CRDAT",
                value: new DateTime(2020, 3, 31, 11, 2, 4, 777, DateTimeKind.Local).AddTicks(6177));
        }
    }
}
