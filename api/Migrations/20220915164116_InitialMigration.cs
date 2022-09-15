using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("1e111058-d56d-44aa-9566-4e14513d5c83"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("336a7f10-5b9f-4bfa-9d2c-fb432bff84ba"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("4541fee3-7da5-45f2-841e-1b33616b9f32"));

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("7741c67d-666b-43cc-8565-b8dbe6285210"), "Go to post office", "Item 3" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("9c1f05af-ff16-4361-8491-579d642a408b"), "Pick up groceries", "Item 1" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("ef497495-d977-4f6b-9ad5-c20e76914436"), "Go to bank", "Item 2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7741c67d-666b-43cc-8565-b8dbe6285210"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("9c1f05af-ff16-4361-8491-579d642a408b"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ef497495-d977-4f6b-9ad5-c20e76914436"));

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("1e111058-d56d-44aa-9566-4e14513d5c83"), "Pick up groceries", "Item 1" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("336a7f10-5b9f-4bfa-9d2c-fb432bff84ba"), "Go to post office", "Item 3" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("4541fee3-7da5-45f2-841e-1b33616b9f32"), "Go to bank", "Item 2" });
        }
    }
}
