using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateExamQuestion : Migration
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
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("19267d7a-41bb-4cd6-8ce5-80a3e33897b3"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("2fd16e5b-3af5-4676-b276-55e9c39e2b78"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("7576f581-708c-4ca7-9eb3-9528fc4dee08"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("82126af4-5e34-47d9-95af-9264aab6111e"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("87c34622-caf5-487d-b778-131b7827ef09"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("8a205d0b-32ee-480a-9f78-7d8a0d7c461c"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("9d6ebb95-24eb-4682-bae5-0f1d0c90d9f0"));

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ExamQuestion");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ExamQuestion");

            migrationBuilder.DropColumn(
                name: "ExamQuestionId",
                table: "ContentBlock");

            migrationBuilder.DropColumn(
                name: "UsedDate",
                table: "ContentBlock");

            migrationBuilder.AddColumn<Guid>(
                name: "ContentBlockId",
                table: "ExamQuestion",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Skill",
                table: "ExamQuestion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte>(
                name: "QuestionAmount",
                table: "ContentBlock",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0063fa63-e83b-45a6-bf95-85dd1e6812b1"), "TestCreator" },
                    { new Guid("03a7bc8c-48ca-44dd-847b-e033c360ead4"), "QuestionBankManager" },
                    { new Guid("22d63de4-3fdc-468b-bc4b-fe733f8638e4"), "Admin" },
                    { new Guid("28f93555-9065-4115-a017-2ca4ddb13505"), "ExamManager" },
                    { new Guid("365bc42b-8f58-47a1-b838-1a872faaaa52"), "QuestionContributor" },
                    { new Guid("4586a5d0-44c8-4862-95bd-a9e4677635b7"), "User" },
                    { new Guid("870de52e-e757-4cef-98e6-8bb8f057164f"), "QuestionContributor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestion_ContentBlockId",
                table: "ExamQuestion",
                column: "ContentBlockId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_ContentBlock_ContentBlockId",
                table: "ExamQuestion",
                column: "ContentBlockId",
                principalTable: "ContentBlock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_ContentBlock_ContentBlockId",
                table: "ExamQuestion");

            migrationBuilder.DropIndex(
                name: "IX_ExamQuestion_ContentBlockId",
                table: "ExamQuestion");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("0063fa63-e83b-45a6-bf95-85dd1e6812b1"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("03a7bc8c-48ca-44dd-847b-e033c360ead4"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("22d63de4-3fdc-468b-bc4b-fe733f8638e4"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("28f93555-9065-4115-a017-2ca4ddb13505"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("365bc42b-8f58-47a1-b838-1a872faaaa52"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("4586a5d0-44c8-4862-95bd-a9e4677635b7"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("870de52e-e757-4cef-98e6-8bb8f057164f"));

            migrationBuilder.DropColumn(
                name: "ContentBlockId",
                table: "ExamQuestion");

            migrationBuilder.DropColumn(
                name: "Skill",
                table: "ExamQuestion");

            migrationBuilder.DropColumn(
                name: "QuestionAmount",
                table: "ContentBlock");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ExamQuestion",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ExamQuestion",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ExamQuestionId",
                table: "ContentBlock",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UsedDate",
                table: "ContentBlock",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("19267d7a-41bb-4cd6-8ce5-80a3e33897b3"), "TestCreator" },
                    { new Guid("2fd16e5b-3af5-4676-b276-55e9c39e2b78"), "User" },
                    { new Guid("7576f581-708c-4ca7-9eb3-9528fc4dee08"), "Admin" },
                    { new Guid("82126af4-5e34-47d9-95af-9264aab6111e"), "QuestionContributor" },
                    { new Guid("87c34622-caf5-487d-b778-131b7827ef09"), "QuestionContributor" },
                    { new Guid("8a205d0b-32ee-480a-9f78-7d8a0d7c461c"), "QuestionBankManager" },
                    { new Guid("9d6ebb95-24eb-4682-bae5-0f1d0c90d9f0"), "ExamManager" }
                });

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
