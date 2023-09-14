using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductosAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    id_prod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_prod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion_prod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio_prod = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.id_prod);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producto");
        }
    }
}
