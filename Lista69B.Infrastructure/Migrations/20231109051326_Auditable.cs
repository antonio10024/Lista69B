using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lista69B.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Auditable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PublicacionPaginaSATPresuntos",
                table: "Lista69BDetalle",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Lista69",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificacion",
                table: "Lista69",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioCreo",
                table: "Lista69",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioModifico",
                table: "Lista69",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Lista69");

            migrationBuilder.DropColumn(
                name: "FechaModificacion",
                table: "Lista69");

            migrationBuilder.DropColumn(
                name: "UsuarioCreo",
                table: "Lista69");

            migrationBuilder.DropColumn(
                name: "UsuarioModifico",
                table: "Lista69");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublicacionPaginaSATPresuntos",
                table: "Lista69BDetalle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
