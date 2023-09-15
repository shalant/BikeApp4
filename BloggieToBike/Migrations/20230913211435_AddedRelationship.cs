using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloggieToBike.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_NewBikeRoute_RouteId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "RouteId",
                table: "Events",
                newName: "NewBikeRouteId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_RouteId",
                table: "Events",
                newName: "IX_Events_NewBikeRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_NewBikeRoute_NewBikeRouteId",
                table: "Events",
                column: "NewBikeRouteId",
                principalTable: "NewBikeRoute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_NewBikeRoute_NewBikeRouteId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "NewBikeRouteId",
                table: "Events",
                newName: "RouteId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_NewBikeRouteId",
                table: "Events",
                newName: "IX_Events_RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_NewBikeRoute_RouteId",
                table: "Events",
                column: "RouteId",
                principalTable: "NewBikeRoute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
