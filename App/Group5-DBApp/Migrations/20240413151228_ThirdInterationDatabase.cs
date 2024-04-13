using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Group5_DBApp.Migrations
{
    /// <inheritdoc />
    public partial class ThirdInterationDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CardNumber = table.Column<string>(type: "TEXT", nullable: true),
                    ExpireDate = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.CardId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    order_id = table.Column<decimal>(type: "TEXT", nullable: false),
                    user_id = table.Column<decimal>(type: "TEXT", nullable: false),
                    prod_id = table.Column<decimal>(type: "TEXT", nullable: false),
                    quantity = table.Column<decimal>(type: "TEXT", nullable: false),
                    credit_card = table.Column<decimal>(type: "TEXT", nullable: false),
                    status = table.Column<string>(type: "TEXT", nullable: true),
                    delivery_type = table.Column<string>(type: "TEXT", nullable: true),
                    delivery_price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ship_date = table.Column<string>(type: "TEXT", nullable: true),
                    delivery_date = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.order_id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    prod_id = table.Column<decimal>(type: "TEXT", nullable: false),
                    prod_name = table.Column<string>(type: "TEXT", nullable: true),
                    price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.prod_id);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    stock_id = table.Column<decimal>(type: "TEXT", nullable: false),
                    prod_id = table.Column<decimal>(type: "TEXT", nullable: false),
                    warehouse_id = table.Column<decimal>(type: "TEXT", nullable: false),
                    quantity = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.stock_id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    sup_id = table.Column<decimal>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    prod_id = table.Column<decimal>(type: "TEXT", nullable: false),
                    price = table.Column<decimal>(type: "TEXT", nullable: false),
                    address = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.sup_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<decimal>(type: "TEXT", nullable: false),
                    user_type = table.Column<string>(type: "TEXT", nullable: true),
                    username = table.Column<string>(type: "TEXT", nullable: true),
                    salary = table.Column<decimal>(type: "TEXT", nullable: true),
                    job_title = table.Column<string>(type: "TEXT", nullable: true),
                    home_address = table.Column<string>(type: "TEXT", nullable: true),
                    delivery_address = table.Column<string>(type: "TEXT", nullable: true),
                    payment_address = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    warehouse_id = table.Column<decimal>(type: "TEXT", nullable: false),
                    capacity = table.Column<decimal>(type: "TEXT", nullable: true),
                    address = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.warehouse_id);
                });

            migrationBuilder.InsertData(
                table: "CreditCards",
                columns: new[] { "CardId", "CardNumber", "ExpireDate", "UserId" },
                values: new object[,]
                {
                    { 1, "1234123412341234", "2025-12-31", 1 },
                    { 2, "5678567856785678", "2025-01-31", 2 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "prod_id", "price", "prod_name" },
                values: new object[,]
                {
                    { 1m, 59.99m, "Wilson Evolution Indoor Basketball" },
                    { 2m, 29.99m, "Spalding NBA Street Outdoor Basketball" },
                    { 3m, 89.99m, "Nike Elite Championship Basketball" },
                    { 4m, 39.99m, "Under Armour 495 Indoor/Outdoor Basketball" },
                    { 5m, 44.99m, "Molten BGG Composite Basketball" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "delivery_address", "home_address", "job_title", "payment_address", "salary", "user_type", "username" },
                values: new object[,]
                {
                    { 1m, null, null, null, null, null, "Customer", "John Doe" },
                    { 2m, null, null, null, null, null, "Staff", "Dan Johnson" }
                });

            migrationBuilder.InsertData(
                table: "Warehouse",
                columns: new[] { "warehouse_id", "address", "capacity" },
                values: new object[,]
                {
                    { 1m, "123 Main Street", 100m },
                    { 2m, "456 Elm Avenue", 75m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Warehouse");
        }
    }
}
