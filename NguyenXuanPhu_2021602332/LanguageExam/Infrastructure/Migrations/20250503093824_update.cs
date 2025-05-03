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
                name: "FK_ContentBlock_QuestionLevel_QuestionLevelId",
                table: "ContentBlock");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamStruct_QuestionLevel_QuestionLevelId",
                table: "ExamStruct");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionLevel_Skill_SkillId",
                table: "QuestionLevel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionLevel",
                table: "QuestionLevel");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("02c7aedf-29d5-4506-86f8-b00798948ccf"));

            migrationBuilder.RenameTable(
                name: "QuestionLevel",
                newName: "QuestionType");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionLevel_SkillId",
                table: "QuestionType",
                newName: "IX_QuestionType_SkillId");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "CreatedDate",
                table: "QuestionBank",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionType",
                table: "QuestionType",
                column: "Id");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("41385260-dc58-4699-a291-d009d2c377d9"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });

            migrationBuilder.AddForeignKey(
                name: "FK_ContentBlock_QuestionType_QuestionLevelId",
                table: "ContentBlock",
                column: "QuestionLevelId",
                principalTable: "QuestionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamStruct_QuestionType_QuestionLevelId",
                table: "ExamStruct",
                column: "QuestionLevelId",
                principalTable: "QuestionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionType_Skill_SkillId",
                table: "QuestionType",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentBlock_QuestionType_QuestionLevelId",
                table: "ContentBlock");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamStruct_QuestionType_QuestionLevelId",
                table: "ExamStruct");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionType_Skill_SkillId",
                table: "QuestionType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionType",
                table: "QuestionType");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("41385260-dc58-4699-a291-d009d2c377d9"));

            migrationBuilder.RenameTable(
                name: "QuestionType",
                newName: "QuestionLevel");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionType_SkillId",
                table: "QuestionLevel",
                newName: "IX_QuestionLevel_SkillId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "QuestionBank",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionLevel",
                table: "QuestionLevel",
                column: "Id");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("02c7aedf-29d5-4506-86f8-b00798948ccf"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });

            migrationBuilder.AddForeignKey(
                name: "FK_ContentBlock_QuestionLevel_QuestionLevelId",
                table: "ContentBlock",
                column: "QuestionLevelId",
                principalTable: "QuestionLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamStruct_QuestionLevel_QuestionLevelId",
                table: "ExamStruct",
                column: "QuestionLevelId",
                principalTable: "QuestionLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionLevel_Skill_SkillId",
                table: "QuestionLevel",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
