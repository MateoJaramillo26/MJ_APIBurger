using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MJ_APIBurger.Migrations
{
    /// <inheritdoc />
    public partial class IgnoreExistingBurgerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Burger",
                columns: table => new
                {
                    MJBurgerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MJName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MJWithCheese = table.Column<bool>(type: "bit", nullable: false),
                    MJPrecio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burger", x => x.MJBurgerId);
                });

            migrationBuilder.CreateTable(
                name: "Promo",
                columns: table => new
                {
                    MJPromoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MJPromoDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MJFechaPromocion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MJBurgerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promo", x => x.MJPromoId);
                    table.ForeignKey(
                        name: "FK_Promo_Burger_MJBurgerId",
                        column: x => x.MJBurgerId,
                        principalTable: "Burger",
                        principalColumn: "MJBurgerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Promo_BurgerId",
                table: "Promo",
                column: "MJBurgerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promo");

            migrationBuilder.DropTable(
                name: "Burger");
        }
    }
}
