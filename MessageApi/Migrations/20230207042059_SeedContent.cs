using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessageApi.Migrations
{
    public partial class SeedContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "BoardId", "Date", "UserMessage", "UserName" },
                values: new object[] { 1, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Meow", "Tiger23" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "BoardId", "Date", "UserMessage", "UserName" },
                values: new object[] { 2, new DateTime(1000, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Am I holy?", "Jon56" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "BoardId", "Date", "UserMessage", "UserName" },
                values: new object[] { 3, new DateTime(2008, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "What's the secret ingredient?", "FluffyPanda" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: 3);
        }
    }
}
