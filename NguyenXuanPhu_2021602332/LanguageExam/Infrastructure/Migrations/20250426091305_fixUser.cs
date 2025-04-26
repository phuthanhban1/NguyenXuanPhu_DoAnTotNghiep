using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("49284141-e165-44b6-8cb8-62e82a95bebb"));

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfIssue",
                table: "User",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlaceOfIssue",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gener", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("256a171a-df37-4286-af6e-857fffd7f96e"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("256a171a-df37-4286-af6e-857fffd7f96e"));

            migrationBuilder.DropColumn(
                name: "DateOfIssue",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PlaceOfIssue",
                table: "User");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "Email", "FullName", "Gener", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("49284141-e165-44b6-8cb8-62e82a95bebb"), null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });
        }
    }
}
