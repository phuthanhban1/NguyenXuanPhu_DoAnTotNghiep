using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_ExamQuestionStruct_ExamStructId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestionStruct_QuestionLevel_QuestionLevelId",
                table: "ExamQuestionStruct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamQuestionStruct",
                table: "ExamQuestionStruct");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e5ba2233-2ded-48b9-a314-da9ee3b0db03"));

            migrationBuilder.RenameTable(
                name: "ExamQuestionStruct",
                newName: "ExamStruct");

            migrationBuilder.RenameIndex(
                name: "IX_ExamQuestionStruct_QuestionLevelId",
                table: "ExamStruct",
                newName: "IX_ExamStruct_QuestionLevelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamStruct",
                table: "ExamStruct",
                column: "Id");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "Email", "FullName", "Gener", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("49284141-e165-44b6-8cb8-62e82a95bebb"), null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_ExamStruct_ExamStructId",
                table: "Exam",
                column: "ExamStructId",
                principalTable: "ExamStruct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamStruct_QuestionLevel_QuestionLevelId",
                table: "ExamStruct",
                column: "QuestionLevelId",
                principalTable: "QuestionLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_ExamStruct_ExamStructId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamStruct_QuestionLevel_QuestionLevelId",
                table: "ExamStruct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamStruct",
                table: "ExamStruct");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("49284141-e165-44b6-8cb8-62e82a95bebb"));

            migrationBuilder.RenameTable(
                name: "ExamStruct",
                newName: "ExamQuestionStruct");

            migrationBuilder.RenameIndex(
                name: "IX_ExamStruct_QuestionLevelId",
                table: "ExamQuestionStruct",
                newName: "IX_ExamQuestionStruct_QuestionLevelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamQuestionStruct",
                table: "ExamQuestionStruct",
                column: "Id");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "Email", "FullName", "Gener", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("e5ba2233-2ded-48b9-a314-da9ee3b0db03"), null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_ExamQuestionStruct_ExamStructId",
                table: "Exam",
                column: "ExamStructId",
                principalTable: "ExamQuestionStruct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestionStruct_QuestionLevel_QuestionLevelId",
                table: "ExamQuestionStruct",
                column: "QuestionLevelId",
                principalTable: "QuestionLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
