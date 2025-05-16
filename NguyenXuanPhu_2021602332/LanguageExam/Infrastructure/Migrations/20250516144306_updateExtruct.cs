using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateExtruct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("0bb1dae1-839d-4d6f-9d9a-5e248ccb35da"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserCreateId",
                table: "ExamStruct",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreateDue",
                table: "Exam",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("4710320e-2a2c-463e-9a77-35b5a6b67747"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });

            migrationBuilder.CreateIndex(
                name: "IX_ExamStruct_UserCreateId",
                table: "ExamStruct",
                column: "UserCreateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamStruct_User_UserCreateId",
                table: "ExamStruct",
                column: "UserCreateId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamStruct_User_UserCreateId",
                table: "ExamStruct");

            migrationBuilder.DropIndex(
                name: "IX_ExamStruct_UserCreateId",
                table: "ExamStruct");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4710320e-2a2c-463e-9a77-35b5a6b67747"));

            migrationBuilder.DropColumn(
                name: "UserCreateId",
                table: "ExamStruct");

            migrationBuilder.DropColumn(
                name: "CreateDue",
                table: "Exam");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("0bb1dae1-839d-4d6f-9d9a-5e248ccb35da"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });
        }
    }
}
