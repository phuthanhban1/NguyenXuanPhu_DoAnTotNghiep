using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class detailResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2a11ff56-dcd2-4c97-abe9-41b1085a4a9c"));

            migrationBuilder.DropColumn(
                name: "QuestionNumber",
                table: "DetailResult");

            migrationBuilder.RenameColumn(
                name: "IsCreating",
                table: "Exam",
                newName: "IsCreated");

            migrationBuilder.AddColumn<string>(
                name: "Skill",
                table: "DetailResult",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "QuestionBank",
                keyColumn: "Id",
                keyValue: new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"),
                column: "CreatedDate",
                value: new DateOnly(2025, 5, 20));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("cedb1899-fde8-4146-8af0-743e6d3ebcf0"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("cedb1899-fde8-4146-8af0-743e6d3ebcf0"));

            migrationBuilder.DropColumn(
                name: "Skill",
                table: "DetailResult");

            migrationBuilder.RenameColumn(
                name: "IsCreated",
                table: "Exam",
                newName: "IsCreating");

            migrationBuilder.AddColumn<int>(
                name: "QuestionNumber",
                table: "DetailResult",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "QuestionBank",
                keyColumn: "Id",
                keyValue: new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"),
                column: "CreatedDate",
                value: new DateOnly(2025, 5, 19));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("2a11ff56-dcd2-4c97-abe9-41b1085a4a9c"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });
        }
    }
}
