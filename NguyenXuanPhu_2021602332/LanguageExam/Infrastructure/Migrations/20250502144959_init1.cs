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
                name: "FK_ContentBlock_ImageFile_AudioFileId",
                table: "ContentBlock");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentBlock_ImageFile_ImageFileId",
                table: "ContentBlock");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_ImageFile_ImageFileId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_ImageFile_AudioFileId",
                table: "Skill");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ImageFile_ImageFaceId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ImageFile_ImageIdCardAfterId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ImageFile_ImageIdCardBeforeId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageFile",
                table: "ImageFile");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("fc9b50b7-9351-445f-80bf-5ed64255e6f0"));

            migrationBuilder.RenameTable(
                name: "ImageFile",
                newName: "ExamFile");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamFile",
                table: "ExamFile",
                column: "Id");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("f3f68c43-37b1-4b4b-b088-c3d2e9c8e33a"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });

            migrationBuilder.AddForeignKey(
                name: "FK_ContentBlock_ExamFile_AudioFileId",
                table: "ContentBlock",
                column: "AudioFileId",
                principalTable: "ExamFile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentBlock_ExamFile_ImageFileId",
                table: "ContentBlock",
                column: "ImageFileId",
                principalTable: "ExamFile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_ExamFile_ImageFileId",
                table: "Question",
                column: "ImageFileId",
                principalTable: "ExamFile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_ExamFile_AudioFileId",
                table: "Skill",
                column: "AudioFileId",
                principalTable: "ExamFile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ExamFile_ImageFaceId",
                table: "User",
                column: "ImageFaceId",
                principalTable: "ExamFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_ExamFile_ImageIdCardAfterId",
                table: "User",
                column: "ImageIdCardAfterId",
                principalTable: "ExamFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_ExamFile_ImageIdCardBeforeId",
                table: "User",
                column: "ImageIdCardBeforeId",
                principalTable: "ExamFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentBlock_ExamFile_AudioFileId",
                table: "ContentBlock");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentBlock_ExamFile_ImageFileId",
                table: "ContentBlock");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_ExamFile_ImageFileId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_ExamFile_AudioFileId",
                table: "Skill");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ExamFile_ImageFaceId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ExamFile_ImageIdCardAfterId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ExamFile_ImageIdCardBeforeId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamFile",
                table: "ExamFile");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f3f68c43-37b1-4b4b-b088-c3d2e9c8e33a"));

            migrationBuilder.RenameTable(
                name: "ExamFile",
                newName: "ImageFile");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageFile",
                table: "ImageFile",
                column: "Id");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("fc9b50b7-9351-445f-80bf-5ed64255e6f0"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });

            migrationBuilder.AddForeignKey(
                name: "FK_ContentBlock_ImageFile_AudioFileId",
                table: "ContentBlock",
                column: "AudioFileId",
                principalTable: "ImageFile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentBlock_ImageFile_ImageFileId",
                table: "ContentBlock",
                column: "ImageFileId",
                principalTable: "ImageFile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_ImageFile_ImageFileId",
                table: "Question",
                column: "ImageFileId",
                principalTable: "ImageFile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_ImageFile_AudioFileId",
                table: "Skill",
                column: "AudioFileId",
                principalTable: "ImageFile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ImageFile_ImageFaceId",
                table: "User",
                column: "ImageFaceId",
                principalTable: "ImageFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_ImageFile_ImageIdCardAfterId",
                table: "User",
                column: "ImageIdCardAfterId",
                principalTable: "ImageFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_ImageFile_ImageIdCardBeforeId",
                table: "User",
                column: "ImageIdCardBeforeId",
                principalTable: "ImageFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
