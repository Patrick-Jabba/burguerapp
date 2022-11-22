using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backendburgueria.Migrations
{
    /// <inheritdoc />
    public partial class Ingredient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ingredientid",
                table: "product");

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "ingredient",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ingredient_ProductId1",
                table: "ingredient",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ingredient_product_ProductId1",
                table: "ingredient",
                column: "ProductId1",
                principalTable: "product",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ingredient_product_ProductId1",
                table: "ingredient");

            migrationBuilder.DropIndex(
                name: "IX_ingredient_ProductId1",
                table: "ingredient");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ingredient");

            migrationBuilder.AddColumn<int>(
                name: "ingredientid",
                table: "product",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
