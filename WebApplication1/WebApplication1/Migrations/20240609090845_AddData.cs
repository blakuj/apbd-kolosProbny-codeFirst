using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientID", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "John", "Doe" },
                    { 2, "Jane", "Smith" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Alice", "Johnson" },
                    { 2, "Bob", "Brown" }
                });

            migrationBuilder.InsertData(
                table: "Pastry",
                columns: new[] { "PastryID", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 1, "Croissant", 2.5, "Bread" },
                    { 2, "Muffin", 3.0, "Cake" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "AcceptedAt", "ClientId", "Comments", "EmployeeId", "FulfilledAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 9, 11, 8, 45, 133, DateTimeKind.Local).AddTicks(2502), 1, "First order", 1, new DateTime(2024, 6, 9, 13, 8, 45, 133, DateTimeKind.Local).AddTicks(2545) },
                    { 2, new DateTime(2024, 6, 9, 11, 8, 45, 133, DateTimeKind.Local).AddTicks(2550), 2, "Second order", 2, new DateTime(2024, 6, 9, 14, 8, 45, 133, DateTimeKind.Local).AddTicks(2551) }
                });

            migrationBuilder.InsertData(
                table: "Order_pastry",
                columns: new[] { "OrderId", "PastryId", "Amount", "Comment" },
                values: new object[,]
                {
                    { 1, 1, 3, "For breakfast" },
                    { 2, 2, 5, "For meeting" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Order_pastry",
                keyColumns: new[] { "OrderId", "PastryId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Order_pastry",
                keyColumns: new[] { "OrderId", "PastryId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pastry",
                keyColumn: "PastryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pastry",
                keyColumn: "PastryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 2);
        }
    }
}
