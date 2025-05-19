using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateContentBlock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentBlock_ExamQuestion_ExamQuestionId",
                table: "ContentBlock");

            migrationBuilder.DropIndex(
                name: "IX_ContentBlock_ExamQuestionId",
                table: "ContentBlock");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ce8ceeec-5624-425e-8bbe-13fd1e81978d"));

            migrationBuilder.DropColumn(
                name: "ExamQuestionId",
                table: "ContentBlock");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("a251c6ab-b358-4243-9176-c3dd6b21c544"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a251c6ab-b358-4243-9176-c3dd6b21c544"));

            migrationBuilder.AddColumn<Guid>(
                name: "ExamQuestionId",
                table: "ContentBlock",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("ce8ceeec-5624-425e-8bbe-13fd1e81978d"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });

            migrationBuilder.CreateIndex(
                name: "IX_ContentBlock_ExamQuestionId",
                table: "ContentBlock",
                column: "ExamQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentBlock_ExamQuestion_ExamQuestionId",
                table: "ContentBlock",
                column: "ExamQuestionId",
                principalTable: "ExamQuestion",
                principalColumn: "Id");
        }
    }
}
