using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e1c6f265-82bc-4733-abc9-5cfd86b5df36"));

            migrationBuilder.UpdateData(
                table: "QuestionBank",
                keyColumn: "Id",
                keyValue: new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"),
                columns: new[] { "QuestionCreateDue", "QuestionReviewDue" },
                values: new object[] { new DateTime(2025, 6, 3, 19, 47, 11, 411, DateTimeKind.Local).AddTicks(1753), new DateTime(2025, 7, 3, 19, 47, 11, 411, DateTimeKind.Local).AddTicks(1758) });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "AudioFileId", "CreatedUserId", "IsProcess", "Name", "QuestionBankId", "ReviewedUserId" },
                values: new object[] { new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"), null, new Guid("93d09639-a7b9-4825-b364-30366908b007"), false, "Đọc", new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"), new Guid("61af889a-7617-43e7-9cb2-537a01e97a34") });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("0e187088-4b12-4ea9-8cef-877c7982da9b"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("0e187088-4b12-4ea9-8cef-877c7982da9b"));

            migrationBuilder.UpdateData(
                table: "QuestionBank",
                keyColumn: "Id",
                keyValue: new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"),
                columns: new[] { "QuestionCreateDue", "QuestionReviewDue" },
                values: new object[] { new DateTime(2025, 6, 3, 19, 43, 20, 140, DateTimeKind.Local).AddTicks(433), new DateTime(2025, 7, 3, 19, 43, 20, 140, DateTimeKind.Local).AddTicks(437) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("e1c6f265-82bc-4733-abc9-5cfd86b5df36"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });
        }
    }
}
