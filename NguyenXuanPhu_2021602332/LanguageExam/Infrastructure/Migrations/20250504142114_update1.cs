using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d71eea03-6551-46fb-9e90-b8884ea09987"));

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirm",
                table: "Skill",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "QuestionBank",
                keyColumn: "Id",
                keyValue: new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"),
                columns: new[] { "QuestionCreateDue", "QuestionReviewDue" },
                values: new object[] { new DateTime(2025, 6, 3, 21, 21, 14, 141, DateTimeKind.Local).AddTicks(6095), new DateTime(2025, 7, 3, 21, 21, 14, 141, DateTimeKind.Local).AddTicks(6105) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("2959ca56-a667-46a0-acea-eba1e9961419"),
                column: "Name",
                value: "quản trị viên");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("316f8c9c-a9a2-4b17-b4c4-6434d165bc62"),
                column: "Name",
                value: "quản lý ngân hàng đề");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("45b76d26-26e2-41d1-a0f7-ed6b55dc2190"),
                column: "Name",
                value: "người tạo đề");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"),
                column: "Name",
                value: "người đánh giá câu hỏi");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("85af4517-be3b-4ea9-b2cd-1ad9b4417870"),
                column: "Name",
                value: "quản lý kỳ thi");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("8a7dd16f-85bf-4143-be0b-a31da3bbe44a"),
                column: "Name",
                value: "người dùng");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("93d09639-a7b9-4825-b364-30366908b007"),
                column: "Name",
                value: "người tạo câu hỏi");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a0e4f1d5-3c8b-4f2a-8e6c-7d9b5e0a2f1d"),
                column: "Name",
                value: "thí sinh");

            migrationBuilder.UpdateData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"),
                column: "IsConfirm",
                value: false);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("7504f69b-512f-4684-8873-0bfdb1e40564"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("7504f69b-512f-4684-8873-0bfdb1e40564"));

            migrationBuilder.DropColumn(
                name: "IsConfirm",
                table: "Skill");

            migrationBuilder.UpdateData(
                table: "QuestionBank",
                keyColumn: "Id",
                keyValue: new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"),
                columns: new[] { "QuestionCreateDue", "QuestionReviewDue" },
                values: new object[] { new DateTime(2025, 6, 3, 20, 51, 46, 78, DateTimeKind.Local).AddTicks(6640), new DateTime(2025, 7, 3, 20, 51, 46, 78, DateTimeKind.Local).AddTicks(6644) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("2959ca56-a667-46a0-acea-eba1e9961419"),
                column: "Name",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("316f8c9c-a9a2-4b17-b4c4-6434d165bc62"),
                column: "Name",
                value: "QuestionBankManager");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("45b76d26-26e2-41d1-a0f7-ed6b55dc2190"),
                column: "Name",
                value: "TestCreator");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"),
                column: "Name",
                value: "QuestionReviewer");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("85af4517-be3b-4ea9-b2cd-1ad9b4417870"),
                column: "Name",
                value: "ExamManager");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("8a7dd16f-85bf-4143-be0b-a31da3bbe44a"),
                column: "Name",
                value: "User");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("93d09639-a7b9-4825-b364-30366908b007"),
                column: "Name",
                value: "QuestionContributor");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a0e4f1d5-3c8b-4f2a-8e6c-7d9b5e0a2f1d"),
                column: "Name",
                value: "Examinee");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("d71eea03-6551-46fb-9e90-b8884ea09987"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });
        }
    }
}
