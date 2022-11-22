using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backendburgueria.Migrations
{
    /// <inheritdoc />
    public partial class insercaodoproductidnatabelaingrediente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ingredient_product_ProductId",
                table: "ingredient");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ingredient",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ingredient_product_ProductId",
                table: "ingredient",
                column: "ProductId",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ingredient_product_ProductId",
                table: "ingredient");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ingredient",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_ingredient_product_ProductId",
                table: "ingredient",
                column: "ProductId",
                principalTable: "product",
                principalColumn: "id");
        }
    }
}
