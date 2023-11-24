using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lista69B.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WatchListSweep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WathcListSweep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExecutionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("WathcListSweepId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WathcListSweepDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WatchListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    List69BId = table.Column<int>(type: "int", nullable: false),
                    WatchListSweepId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("WathcListSweepDetailId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WathcListSweepDetail_WathcListSweep_WatchListSweepId",
                        column: x => x.WatchListSweepId,
                        principalTable: "WathcListSweep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WathcListSweepDetail_WatchListSweepId",
                table: "WathcListSweepDetail",
                column: "WatchListSweepId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WathcListSweepDetail");

            migrationBuilder.DropTable(
                name: "WathcListSweep");
        }
    }
}
