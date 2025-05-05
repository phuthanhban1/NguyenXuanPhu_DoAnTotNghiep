using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentBlock_QuestionType_QuestionLevelId",
                table: "ContentBlock");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("7504f69b-512f-4684-8873-0bfdb1e40564"));

            migrationBuilder.DropColumn(
                name: "Struct",
                table: "QuestionType");

            migrationBuilder.DropColumn(
                name: "QuestionAmount",
                table: "ContentBlock");

            migrationBuilder.DropColumn(
                name: "QuestionStruct",
                table: "ContentBlock");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "Examinee",
                newName: "ReadingScore");

            migrationBuilder.RenameColumn(
                name: "UnConFirmedReason",
                table: "ContentBlock",
                newName: "RejectionReason");

            migrationBuilder.RenameColumn(
                name: "QuestionLevelId",
                table: "ContentBlock",
                newName: "QuestionTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ContentBlock_QuestionLevelId",
                table: "ContentBlock",
                newName: "IX_ContentBlock_QuestionTypeId");

            migrationBuilder.AddColumn<bool>(
                name: "IsSingle",
                table: "QuestionType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte>(
                name: "Score",
                table: "Question",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AlterColumn<int>(
                name: "Location",
                table: "Examinee",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExamineeNumber",
                table: "Examinee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListeningScore",
                table: "Examinee",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "QuestionBank",
                keyColumn: "Id",
                keyValue: new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"),
                columns: new[] { "CreatedDate", "QuestionCreateDue", "QuestionReviewDue" },
                values: new object[] { new DateOnly(2025, 5, 5), new DateTime(2025, 6, 4, 21, 56, 3, 47, DateTimeKind.Local).AddTicks(3433), new DateTime(2025, 7, 4, 21, 56, 3, 47, DateTimeKind.Local).AddTicks(3438) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("752636d2-02a0-4d99-bdba-789279ac7fa7"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });

            migrationBuilder.AddForeignKey(
                name: "FK_ContentBlock_QuestionType_QuestionTypeId",
                table: "ContentBlock",
                column: "QuestionTypeId",
                principalTable: "QuestionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentBlock_QuestionType_QuestionTypeId",
                table: "ContentBlock");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("752636d2-02a0-4d99-bdba-789279ac7fa7"));

            migrationBuilder.DropColumn(
                name: "IsSingle",
                table: "QuestionType");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "ExamineeNumber",
                table: "Examinee");

            migrationBuilder.DropColumn(
                name: "ListeningScore",
                table: "Examinee");

            migrationBuilder.RenameColumn(
                name: "ReadingScore",
                table: "Examinee",
                newName: "Score");

            migrationBuilder.RenameColumn(
                name: "RejectionReason",
                table: "ContentBlock",
                newName: "UnConFirmedReason");

            migrationBuilder.RenameColumn(
                name: "QuestionTypeId",
                table: "ContentBlock",
                newName: "QuestionLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_ContentBlock_QuestionTypeId",
                table: "ContentBlock",
                newName: "IX_ContentBlock_QuestionLevelId");

            migrationBuilder.AddColumn<int>(
                name: "Struct",
                table: "QuestionType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Examinee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "QuestionAmount",
                table: "ContentBlock",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionStruct",
                table: "ContentBlock",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "QuestionBank",
                keyColumn: "Id",
                keyValue: new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"),
                columns: new[] { "CreatedDate", "QuestionCreateDue", "QuestionReviewDue" },
                values: new object[] { new DateOnly(2025, 5, 4), new DateTime(2025, 6, 3, 21, 21, 14, 141, DateTimeKind.Local).AddTicks(6095), new DateTime(2025, 7, 3, 21, 21, 14, 141, DateTimeKind.Local).AddTicks(6105) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("7504f69b-512f-4684-8873-0bfdb1e40564"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });

            migrationBuilder.AddForeignKey(
                name: "FK_ContentBlock_QuestionType_QuestionLevelId",
                table: "ContentBlock",
                column: "QuestionLevelId",
                principalTable: "QuestionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
