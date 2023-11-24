using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lista69B.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ListaSeguimientov1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListaSeguimiento",
                columns: table => new
                {
                    ListaSeguimientoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFC = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCreo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModifico = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaSeguimiento", x => x.ListaSeguimientoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListaSeguimiento");
        }
    }
}
