using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Group5_DBApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProdId = table.Column<decimal>(type: "TEXT", nullable: false),
                    ProdName = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProdId);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProdId", "Price", "ProdName" },
                values: new object[,]
                {
                    { 1m, 59.99m, "Wilson Evolution Indoor Basketball" },
                    { 2m, 29.99m, "Spalding NBA Street Outdoor Basketball" },
                    { 3m, 89.99m, "Nike Elite Championship Basketball" },
                    { 4m, 39.99m, "Under Armour 495 Indoor/Outdoor Basketball" },
                    { 5m, 44.99m, "Molten BGG Composite Basketball" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
