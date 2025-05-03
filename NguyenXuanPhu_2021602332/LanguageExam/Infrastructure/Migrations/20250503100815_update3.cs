using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("16cddab8-8aec-4ea5-a7ed-6f28adec32e0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2aa00230-37f5-4a65-8cdc-d639ee480d5c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3ac15aed-7556-42db-bff1-89f7468a5dc9"));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[,]
                {
                    { new Guid("42afbf60-5754-43ce-9895-0127d4ab9c7f"), null, null, "taocau@gmail.com", "Tạo Câu Hỏi", null, null, null, null, null, true, "1", null, null, new Guid("93d09639-a7b9-4825-b364-30366908b007"), null, null },
                    { new Guid("cf5c0639-c6cc-481a-ba0d-8073ddd1ed44"), null, null, "review@gmail.com", "Đánh Giá Câu", null, null, null, null, null, true, "1", null, null, new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"), null, null },
                    { new Guid("faff3232-3fbc-4344-9415-de3d357bf79b"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("42afbf60-5754-43ce-9895-0127d4ab9c7f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("cf5c0639-c6cc-481a-ba0d-8073ddd1ed44"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("faff3232-3fbc-4344-9415-de3d357bf79b"));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[,]
                {
                    { new Guid("16cddab8-8aec-4ea5-a7ed-6f28adec32e0"), null, null, "taocau@gmail.com", "Tạo Câu Hỏi", null, null, null, null, null, true, "1", null, null, new Guid("93d09639-a7b9-4825-b364-30366908b007"), null, null },
                    { new Guid("2aa00230-37f5-4a65-8cdc-d639ee480d5c"), null, null, "review@gmail.com", "Đánh Giá Câu", null, null, null, null, null, true, "1", null, null, new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"), null, null },
                    { new Guid("3ac15aed-7556-42db-bff1-89f7468a5dc9"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null }
                });
        }
    }
}
