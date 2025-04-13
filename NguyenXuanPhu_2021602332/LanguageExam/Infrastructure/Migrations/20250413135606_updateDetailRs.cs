using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateDetailRs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("225bc2d4-7d77-4ef2-bf58-249ef2d95a70"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("23ad4800-5d72-4944-bea4-a65feed901d5"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("328f0282-6706-43a6-b6c7-fa696ed075ec"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("50906a13-19c3-46af-a09e-9c6fa48c5882"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("5130d847-1af3-4d1d-98c3-b0eab31cd505"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("7f6619db-f76a-4a16-8b3e-0548d6ded7e3"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("ee3d27c6-242a-49da-9368-d9e6cda7c0df"));

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "DetailResult");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "QuestionBank",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.AddColumn<Guid>(
                name: "AnswerId",
                table: "DetailResult",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                name: "IX_DetailResult_AnswerId",
                table: "DetailResult",
                column: "AnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailResult_Answer_AnswerId",
                table: "DetailResult",
                column: "AnswerId",
                principalTable: "Answer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailResult_Answer_AnswerId",
                table: "DetailResult");

            migrationBuilder.DropIndex(
                name: "IX_DetailResult_AnswerId",
                table: "DetailResult");

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
                name: "CreatedAt",
                table: "QuestionBank");

            migrationBuilder.DropColumn(
                name: "QuestionCreateDue",
                table: "QuestionBank");

            migrationBuilder.DropColumn(
                name: "QuestionReviewDue",
                table: "QuestionBank");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "DetailResult");

            migrationBuilder.AddColumn<byte>(
                name: "Answer",
                table: "DetailResult",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("225bc2d4-7d77-4ef2-bf58-249ef2d95a70"), "TestCreator" },
                    { new Guid("23ad4800-5d72-4944-bea4-a65feed901d5"), "User" },
                    { new Guid("328f0282-6706-43a6-b6c7-fa696ed075ec"), "QuestionContributor" },
                    { new Guid("50906a13-19c3-46af-a09e-9c6fa48c5882"), "ExamManager" },
                    { new Guid("5130d847-1af3-4d1d-98c3-b0eab31cd505"), "QuestionContributor" },
                    { new Guid("7f6619db-f76a-4a16-8b3e-0548d6ded7e3"), "QuestionBankManager" },
                    { new Guid("ee3d27c6-242a-49da-9368-d9e6cda7c0df"), "Admin" }
                });
        }
    }
}
