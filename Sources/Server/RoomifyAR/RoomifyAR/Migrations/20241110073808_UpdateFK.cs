using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoomifyAR.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductMedias_ProductId",
                table: "ProductMedias",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMedias_Products_ProductId",
                table: "ProductMedias",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductMedias_Products_ProductId",
                table: "ProductMedias");

            migrationBuilder.DropIndex(
                name: "IX_ProductMedias_ProductId",
                table: "ProductMedias");
        }
    }
}
