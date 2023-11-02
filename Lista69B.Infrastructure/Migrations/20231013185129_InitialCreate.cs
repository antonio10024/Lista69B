using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lista69B.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lista69",
                columns: table => new
                {
                    Lista69BId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lista69", x => x.Lista69BId);
                });

            migrationBuilder.CreateTable(
                name: "Lista69BDetalle",
                columns: table => new
                {
                    Lista69BDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<int>(type: "int", nullable: false),
                    RFC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombredelContribuyente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SituacionContribuyente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroYFechaDeOficioGlobalDePresuncionSAT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicacionPaginaSATPresuntos = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroYFechaDeOficioGlobalDePresuncionDOF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicacionDOFPresuntos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroYFechaDeOficioGlobalDeContribuyentesQueDesvirtuaronSAT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicacionPaginaSATDesvirtuados = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroyFechaDeOficioGlobalDeContribuyentesQueDesvirtuaronDOF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicacionDOFDesvirtuados = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroYFechaDeOficioGlobalDeDefinitivosSAT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicacionPaginaSATDefinitivos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroYFechaDeOficioGlobalDeDefinitivosDOF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicacionDOFDefinitivos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroYFechaDeOficioGlobalDeSentenciaFavorableSAT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicacionPaginaSATSentenciaFavorable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroYFechaDeOficioGlobalDeSentenciaFavorableDOF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicacionDOFSentenciaFavorable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lista69BId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lista69BDetalle", x => x.Lista69BDetalleId);
                    table.ForeignKey(
                        name: "FK_Lista69BDetalle_Lista69_Lista69BId",
                        column: x => x.Lista69BId,
                        principalTable: "Lista69",
                        principalColumn: "Lista69BId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lista69BDetalle_Lista69BId",
                table: "Lista69BDetalle",
                column: "Lista69BId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lista69BDetalle");

            migrationBuilder.DropTable(
                name: "Lista69");
        }
    }
}
