using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateSkill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_ExamStruct_ExamStructId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_ContentBlock_ContentBlockId",
                table: "ExamQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamStruct_QuestionType_QuestionLevelId",
                table: "ExamStruct");

            migrationBuilder.DropIndex(
                name: "IX_ExamQuestion_ContentBlockId",
                table: "ExamQuestion");

            migrationBuilder.DropIndex(
                name: "IX_Exam_ExamStructId",
                table: "Exam");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("8a7dd16f-85bf-4143-be0b-a31da3bbe44a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("92edbc74-66b0-471c-a042-31c79d4739a3"));

            migrationBuilder.DropColumn(
                name: "QuestionCreateDue",
                table: "QuestionBank");

            migrationBuilder.DropColumn(
                name: "QuestionReviewDue",
                table: "QuestionBank");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "ExamStruct");

            migrationBuilder.DropColumn(
                name: "Skill",
                table: "ExamStruct");

            migrationBuilder.DropColumn(
                name: "ExamStructId",
                table: "Exam");

            migrationBuilder.RenameColumn(
                name: "IsConfirm",
                table: "Skill",
                newName: "IsReviewConfirm");

            migrationBuilder.RenameColumn(
                name: "QuestionLevelId",
                table: "ExamStruct",
                newName: "QuestionBankId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamStruct_QuestionLevelId",
                table: "ExamStruct",
                newName: "IX_ExamStruct_QuestionBankId");

            migrationBuilder.RenameColumn(
                name: "ContentBlockId",
                table: "ExamQuestion",
                newName: "ExamStructId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDue",
                table: "Skill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsCreateConfirm",
                table: "Skill",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewDue",
                table: "Skill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreatedDate",
                table: "ExamStruct",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<Guid>(
                name: "QuestionTypeId",
                table: "ExamStruct",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "UpdatedDate",
                table: "ExamStruct",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<Guid>(
                name: "AudioFileId",
                table: "ExamQuestion",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ExamQuestionId",
                table: "ContentBlock",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExamStructDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Skill = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    QuestionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamStructId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamStructDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamStructDetail_ExamStruct_ExamStructId",
                        column: x => x.ExamStructId,
                        principalTable: "ExamStruct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamStructDetail_QuestionType_QuestionTypeId",
                        column: x => x.QuestionTypeId,
                        principalTable: "QuestionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "QuestionBank",
                keyColumn: "Id",
                keyValue: new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"),
                column: "CreatedDate",
                value: new DateOnly(2025, 5, 7));

            migrationBuilder.UpdateData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"),
                columns: new[] { "CreateDue", "IsCreateConfirm", "ReviewDue" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("4da9c7cf-c58f-4520-83db-11e6cb156ea7"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });

            migrationBuilder.CreateIndex(
                name: "IX_ExamStruct_QuestionTypeId",
                table: "ExamStruct",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestion_AudioFileId",
                table: "ExamQuestion",
                column: "AudioFileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestion_ExamStructId",
                table: "ExamQuestion",
                column: "ExamStructId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentBlock_ExamQuestionId",
                table: "ContentBlock",
                column: "ExamQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamStructDetail_ExamStructId",
                table: "ExamStructDetail",
                column: "ExamStructId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamStructDetail_QuestionTypeId",
                table: "ExamStructDetail",
                column: "QuestionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentBlock_ExamQuestion_ExamQuestionId",
                table: "ContentBlock",
                column: "ExamQuestionId",
                principalTable: "ExamQuestion",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_ExamFile_AudioFileId",
                table: "ExamQuestion",
                column: "AudioFileId",
                principalTable: "ExamFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_ExamStruct_ExamStructId",
                table: "ExamQuestion",
                column: "ExamStructId",
                principalTable: "ExamStruct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamStruct_QuestionBank_QuestionBankId",
                table: "ExamStruct",
                column: "QuestionBankId",
                principalTable: "QuestionBank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamStruct_QuestionType_QuestionTypeId",
                table: "ExamStruct",
                column: "QuestionTypeId",
                principalTable: "QuestionType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentBlock_ExamQuestion_ExamQuestionId",
                table: "ContentBlock");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_ExamFile_AudioFileId",
                table: "ExamQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_ExamStruct_ExamStructId",
                table: "ExamQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamStruct_QuestionBank_QuestionBankId",
                table: "ExamStruct");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamStruct_QuestionType_QuestionTypeId",
                table: "ExamStruct");

            migrationBuilder.DropTable(
                name: "ExamStructDetail");

            migrationBuilder.DropIndex(
                name: "IX_ExamStruct_QuestionTypeId",
                table: "ExamStruct");

            migrationBuilder.DropIndex(
                name: "IX_ExamQuestion_AudioFileId",
                table: "ExamQuestion");

            migrationBuilder.DropIndex(
                name: "IX_ExamQuestion_ExamStructId",
                table: "ExamQuestion");

            migrationBuilder.DropIndex(
                name: "IX_ContentBlock_ExamQuestionId",
                table: "ContentBlock");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4da9c7cf-c58f-4520-83db-11e6cb156ea7"));

            migrationBuilder.DropColumn(
                name: "CreateDue",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "IsCreateConfirm",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "ReviewDue",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ExamStruct");

            migrationBuilder.DropColumn(
                name: "QuestionTypeId",
                table: "ExamStruct");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ExamStruct");

            migrationBuilder.DropColumn(
                name: "AudioFileId",
                table: "ExamQuestion");

            migrationBuilder.DropColumn(
                name: "ExamQuestionId",
                table: "ContentBlock");

            migrationBuilder.RenameColumn(
                name: "IsReviewConfirm",
                table: "Skill",
                newName: "IsConfirm");

            migrationBuilder.RenameColumn(
                name: "QuestionBankId",
                table: "ExamStruct",
                newName: "QuestionLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamStruct_QuestionBankId",
                table: "ExamStruct",
                newName: "IX_ExamStruct_QuestionLevelId");

            migrationBuilder.RenameColumn(
                name: "ExamStructId",
                table: "ExamQuestion",
                newName: "ContentBlockId");

            migrationBuilder.AddColumn<DateTime>(
                name: "QuestionCreateDue",
                table: "QuestionBank",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "QuestionReviewDue",
                table: "QuestionBank",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "ExamStruct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Skill",
                table: "ExamStruct",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ExamStructId",
                table: "Exam",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "QuestionBank",
                keyColumn: "Id",
                keyValue: new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"),
                columns: new[] { "CreatedDate", "QuestionCreateDue", "QuestionReviewDue" },
                values: new object[] { new DateOnly(2025, 5, 5), new DateTime(2025, 6, 4, 22, 27, 15, 754, DateTimeKind.Local).AddTicks(4042), new DateTime(2025, 7, 4, 22, 27, 15, 754, DateTimeKind.Local).AddTicks(4047) });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("8a7dd16f-85bf-4143-be0b-a31da3bbe44a"), "người dùng" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("92edbc74-66b0-471c-a042-31c79d4739a3"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestion_ContentBlockId",
                table: "ExamQuestion",
                column: "ContentBlockId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exam_ExamStructId",
                table: "Exam",
                column: "ExamStructId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_ExamStruct_ExamStructId",
                table: "Exam",
                column: "ExamStructId",
                principalTable: "ExamStruct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_ContentBlock_ContentBlockId",
                table: "ExamQuestion",
                column: "ContentBlockId",
                principalTable: "ContentBlock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamStruct_QuestionType_QuestionLevelId",
                table: "ExamStruct",
                column: "QuestionLevelId",
                principalTable: "QuestionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
