using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lista69B.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixSearch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "List69BId",
                table: "WathcListSweepDetail",
                newName: "Register69BId");

            migrationBuilder.AddColumn<Guid>(
                name: "Lista69BId",
                table: "WathcListSweepDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lista69BId",
                table: "WathcListSweepDetail");

            migrationBuilder.RenameColumn(
                name: "Register69BId",
                table: "WathcListSweepDetail",
                newName: "List69BId");
        }
    }
}
