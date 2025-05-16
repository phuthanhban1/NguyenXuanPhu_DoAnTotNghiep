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
            migrationBuilder.DropForeignKey(
                name: "FK_ExamStruct_QuestionType_QuestionTypeId",
                table: "ExamStruct");

            migrationBuilder.DropIndex(
                name: "IX_ExamStruct_QuestionTypeId",
                table: "ExamStruct");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8efc50ba-7d0d-493a-bee7-694ecebb7285"));

            migrationBuilder.DropColumn(
                name: "QuestionTypeId",
                table: "ExamStruct");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("12e53e30-c9bc-4771-8671-7b94733dbc32"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("12e53e30-c9bc-4771-8671-7b94733dbc32"));

            migrationBuilder.AddColumn<Guid>(
                name: "QuestionTypeId",
                table: "ExamStruct",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("8efc50ba-7d0d-493a-bee7-694ecebb7285"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });

            migrationBuilder.CreateIndex(
                name: "IX_ExamStruct_QuestionTypeId",
                table: "ExamStruct",
                column: "QuestionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamStruct_QuestionType_QuestionTypeId",
                table: "ExamStruct",
                column: "QuestionTypeId",
                principalTable: "QuestionType",
                principalColumn: "Id");
        }
    }
}
