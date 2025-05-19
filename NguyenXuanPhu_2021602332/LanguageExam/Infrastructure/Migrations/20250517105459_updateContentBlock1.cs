using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateContentBlock1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_ExamFile_AudioFileId",
                table: "ExamQuestion");

            migrationBuilder.DropIndex(
                name: "IX_ExamQuestion_AudioFileId",
                table: "ExamQuestion");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a251c6ab-b358-4243-9176-c3dd6b21c544"));

            migrationBuilder.AlterColumn<Guid>(
                name: "AudioFileId",
                table: "ExamQuestion",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("550300ea-2e29-4214-bd34-184ef6767488"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestion_AudioFileId",
                table: "ExamQuestion",
                column: "AudioFileId",
                unique: true,
                filter: "[AudioFileId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_ExamFile_AudioFileId",
                table: "ExamQuestion",
                column: "AudioFileId",
                principalTable: "ExamFile",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_ExamFile_AudioFileId",
                table: "ExamQuestion");

            migrationBuilder.DropIndex(
                name: "IX_ExamQuestion_AudioFileId",
                table: "ExamQuestion");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("550300ea-2e29-4214-bd34-184ef6767488"));

            migrationBuilder.AlterColumn<Guid>(
                name: "AudioFileId",
                table: "ExamQuestion",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("a251c6ab-b358-4243-9176-c3dd6b21c544"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestion_AudioFileId",
                table: "ExamQuestion",
                column: "AudioFileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_ExamFile_AudioFileId",
                table: "ExamQuestion",
                column: "AudioFileId",
                principalTable: "ExamFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
