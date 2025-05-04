using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_ExamFile_AudioFileId",
                table: "Skill");

            migrationBuilder.DropIndex(
                name: "IX_Skill_AudioFileId",
                table: "Skill");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("0e187088-4b12-4ea9-8cef-877c7982da9b"));

            migrationBuilder.DropColumn(
                name: "AudioFileId",
                table: "Skill");

            migrationBuilder.UpdateData(
                table: "QuestionBank",
                keyColumn: "Id",
                keyValue: new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"),
                columns: new[] { "QuestionCreateDue", "QuestionReviewDue" },
                values: new object[] { new DateTime(2025, 6, 3, 20, 51, 46, 78, DateTimeKind.Local).AddTicks(6640), new DateTime(2025, 7, 3, 20, 51, 46, 78, DateTimeKind.Local).AddTicks(6644) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("d71eea03-6551-46fb-9e90-b8884ea09987"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d71eea03-6551-46fb-9e90-b8884ea09987"));

            migrationBuilder.AddColumn<Guid>(
                name: "AudioFileId",
                table: "Skill",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "QuestionBank",
                keyColumn: "Id",
                keyValue: new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"),
                columns: new[] { "QuestionCreateDue", "QuestionReviewDue" },
                values: new object[] { new DateTime(2025, 6, 3, 19, 47, 11, 411, DateTimeKind.Local).AddTicks(1753), new DateTime(2025, 7, 3, 19, 47, 11, 411, DateTimeKind.Local).AddTicks(1758) });

            migrationBuilder.UpdateData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"),
                column: "AudioFileId",
                value: null);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("0e187088-4b12-4ea9-8cef-877c7982da9b"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Skill_AudioFileId",
                table: "Skill",
                column: "AudioFileId",
                unique: true,
                filter: "[AudioFileId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_ExamFile_AudioFileId",
                table: "Skill",
                column: "AudioFileId",
                principalTable: "ExamFile",
                principalColumn: "Id");
        }
    }
}
