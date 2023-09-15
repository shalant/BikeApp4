using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloggieToBike.Migrations
{
    /// <inheritdoc />
    public partial class addMoreFieldsToBikeRouteModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "NewBikeRoute",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Length",
                table: "NewBikeRoute",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Direction",
                table: "NewBikeRoute",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "NewBikeRoute",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "NewBikeRoute",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Elevation",
                table: "NewBikeRoute",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Featured",
                table: "NewBikeRoute",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FeaturedImageUrl",
                table: "NewBikeRoute",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedDate",
                table: "NewBikeRoute",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "NewBikeRoute",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StravaLink",
                table: "NewBikeRoute",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "NewBikeRoute");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "NewBikeRoute");

            migrationBuilder.DropColumn(
                name: "Elevation",
                table: "NewBikeRoute");

            migrationBuilder.DropColumn(
                name: "Featured",
                table: "NewBikeRoute");

            migrationBuilder.DropColumn(
                name: "FeaturedImageUrl",
                table: "NewBikeRoute");

            migrationBuilder.DropColumn(
                name: "PublishedDate",
                table: "NewBikeRoute");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "NewBikeRoute");

            migrationBuilder.DropColumn(
                name: "StravaLink",
                table: "NewBikeRoute");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "NewBikeRoute",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Length",
                table: "NewBikeRoute",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Direction",
                table: "NewBikeRoute",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
