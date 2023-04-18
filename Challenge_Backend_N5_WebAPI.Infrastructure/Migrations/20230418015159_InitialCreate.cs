using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge_Backend_N5_WebAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "TipoPermisos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPermisos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEmpleado = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ApellidoEmpleado = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FechaPermiso = table.Column<DateTime>(type: "datetime", nullable: false),
                    TipoPermiso = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permisos_TipoPermisos_TipoPermiso",
                        column: x => x.TipoPermiso,
                        principalSchema: "dbo",
                        principalTable: "TipoPermisos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permisos_TipoPermiso",
                schema: "dbo",
                table: "Permisos",
                column: "TipoPermiso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permisos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TipoPermisos",
                schema: "dbo");
        }
    }
}
