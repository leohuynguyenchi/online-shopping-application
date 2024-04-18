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
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: 1m,
                columns: new[] { "delivery_address", "home_address", "payment_address" },
                values: new object[] { "123 Main St, Anytown, USA", "123 Main St, Anytown, USA", "123 Main St, Anytown, USA" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: 2m,
                columns: new[] { "delivery_address", "home_address", "payment_address", "user_type", "username" },
                values: new object[] { "456 Elm St, Somecity, USA", "456 Elm St, Somecity, USA", "456 Elm St, Somecity, USA", "Customer", "Jane Smith" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "delivery_address", "home_address", "job_title", "payment_address", "salary", "user_type", "username" },
                values: new object[,]
                {
                    { 3m, null, "789 Oak St, Othercity, USA", "Manager", null, 60000m, "Staff", "Dan Johnson" },
                    { 4m, null, "321 Pine St, Anothercity, USA", "Sales Associate", null, 45000m, "Staff", "Bob Williams" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: 3m);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: 4m);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: 1m,
                columns: new[] { "delivery_address", "home_address", "payment_address" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: 2m,
                columns: new[] { "delivery_address", "home_address", "payment_address", "user_type", "username" },
                values: new object[] { null, null, null, "Staff", "Dan Johnson" });
        }
    }
}
