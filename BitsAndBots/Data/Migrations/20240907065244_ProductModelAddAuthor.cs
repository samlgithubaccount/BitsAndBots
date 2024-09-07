using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitsAndBots.Migrations
{
    /// <inheritdoc />
    public partial class ProductModelAddAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_AuthorId",
                table: "Product",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AspNetUsers_AuthorId",
                table: "Product",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_AspNetUsers_AuthorId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_AuthorId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Product");
        }
    }
}
