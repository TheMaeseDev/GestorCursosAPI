using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorCursosAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoriaModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Cursos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_CategoriaId",
                table: "Cursos",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Categoria_CategoriaId",
                table: "Cursos",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Categoria_CategoriaId",
                table: "Cursos");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_CategoriaId",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Cursos");
        }
    }
}
