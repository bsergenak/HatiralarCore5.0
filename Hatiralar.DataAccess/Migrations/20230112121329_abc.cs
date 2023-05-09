using Microsoft.EntityFrameworkCore.Migrations;

namespace Hatiralar.DataAccess.Migrations
{
    public partial class abc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notebooks_AspNetUsers_AppUserId",
                table: "Notebooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Notebooks_Cities_CityId",
                table: "Notebooks");

            migrationBuilder.DropIndex(
                name: "IX_Notebooks_AppUserId",
                table: "Notebooks");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Notebooks");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Notebooks",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Notebooks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Notebooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notebooks_UserId",
                table: "Notebooks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notebooks_AspNetUsers_UserId",
                table: "Notebooks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notebooks_Cities_CityId",
                table: "Notebooks",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notebooks_AspNetUsers_UserId",
                table: "Notebooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Notebooks_Cities_CityId",
                table: "Notebooks");

            migrationBuilder.DropIndex(
                name: "IX_Notebooks_UserId",
                table: "Notebooks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Notebooks");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Notebooks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Notebooks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Notebooks",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Notebooks_AppUserId",
                table: "Notebooks",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notebooks_AspNetUsers_AppUserId",
                table: "Notebooks",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notebooks_Cities_CityId",
                table: "Notebooks",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
