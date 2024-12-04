using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AS.Migrations
{
    /// <inheritdoc />
    public partial class MakeFornecedorIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Fornecedores_FornecedorId",
                table: "Pedidos");

            migrationBuilder.AlterColumn<int>(
                name: "FornecedorId",
                table: "Pedidos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Fornecedores_FornecedorId",
                table: "Pedidos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Fornecedores_FornecedorId",
                table: "Pedidos");

            migrationBuilder.AlterColumn<int>(
                name: "FornecedorId",
                table: "Pedidos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Fornecedores_FornecedorId",
                table: "Pedidos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
