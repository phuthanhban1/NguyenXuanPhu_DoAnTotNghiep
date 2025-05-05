using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_ExamFile_ImageFileId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_ImageFileId",
                table: "Question");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("752636d2-02a0-4d99-bdba-789279ac7fa7"));

            migrationBuilder.DropColumn(
                name: "Level",
                table: "QuestionType");

            migrationBuilder.DropColumn(
                name: "ImageFileId",
                table: "Question");

            migrationBuilder.UpdateData(
                table: "QuestionBank",
                keyColumn: "Id",
                keyValue: new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"),
                columns: new[] { "QuestionCreateDue", "QuestionReviewDue" },
                values: new object[] { new DateTime(2025, 6, 4, 22, 27, 15, 754, DateTimeKind.Local).AddTicks(4042), new DateTime(2025, 7, 4, 22, 27, 15, 754, DateTimeKind.Local).AddTicks(4047) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("92edbc74-66b0-471c-a042-31c79d4739a3"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("92edbc74-66b0-471c-a042-31c79d4739a3"));

            migrationBuilder.AddColumn<byte>(
                name: "Level",
                table: "QuestionType",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<Guid>(
                name: "ImageFileId",
                table: "Question",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "QuestionBank",
                keyColumn: "Id",
                keyValue: new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"),
                columns: new[] { "QuestionCreateDue", "QuestionReviewDue" },
                values: new object[] { new DateTime(2025, 6, 4, 21, 56, 3, 47, DateTimeKind.Local).AddTicks(3433), new DateTime(2025, 7, 4, 21, 56, 3, 47, DateTimeKind.Local).AddTicks(3438) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("752636d2-02a0-4d99-bdba-789279ac7fa7"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Question_ImageFileId",
                table: "Question",
                column: "ImageFileId",
                unique: true,
                filter: "[ImageFileId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_ExamFile_ImageFileId",
                table: "Question",
                column: "ImageFileId",
                principalTable: "ExamFile",
                principalColumn: "Id");
        }
    }
}
