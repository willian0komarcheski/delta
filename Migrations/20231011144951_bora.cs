using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace loja1.Migrations
{
    /// <inheritdoc />
    public partial class bora : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "logins",
                columns: table => new
                {
                    loginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Usarname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logins", x => x.loginId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Preco = table.Column<double>(type: "double", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "carrinhos",
                columns: table => new
                {
                    carrinhoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    loginId = table.Column<int>(type: "int", nullable: false),
                    precototal = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carrinhos", x => x.carrinhoId);
                    table.ForeignKey(
                        name: "FK_carrinhos_logins_loginId",
                        column: x => x.loginId,
                        principalTable: "logins",
                        principalColumn: "loginId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produtocarrinho",
                columns: table => new
                {
                    ProdutosProdutoId = table.Column<int>(type: "int", nullable: false),
                    carrinhoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtocarrinho", x => new { x.ProdutosProdutoId, x.carrinhoId });
                    table.ForeignKey(
                        name: "FK_Produtocarrinho_Produtos_ProdutosProdutoId",
                        column: x => x.ProdutosProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtocarrinho_carrinhos_carrinhoId",
                        column: x => x.carrinhoId,
                        principalTable: "carrinhos",
                        principalColumn: "carrinhoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_carrinhos_loginId",
                table: "carrinhos",
                column: "loginId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtocarrinho_carrinhoId",
                table: "Produtocarrinho",
                column: "carrinhoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtocarrinho");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "carrinhos");

            migrationBuilder.DropTable(
                name: "logins");
        }
    }
}
