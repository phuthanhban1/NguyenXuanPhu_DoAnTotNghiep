using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateContentBlock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("07e95d49-fd96-43cf-bd0f-97acb28edce6"));

            migrationBuilder.DropColumn(
                name: "IsConfirm",
                table: "ContentBlock");

            migrationBuilder.RenameColumn(
                name: "TextContent",
                table: "ContentBlock",
                newName: "Content");

            migrationBuilder.AlterColumn<Guid>(
                name: "ReviewedUserId",
                table: "Skill",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewDue",
                table: "Skill",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "Skill",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDue",
                table: "Skill",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "ContentBlock",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "QuestionBank",
                keyColumn: "Id",
                keyValue: new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"),
                column: "CreatedDate",
                value: new DateOnly(2025, 5, 14));

            migrationBuilder.UpdateData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"),
                columns: new[] { "CreateDue", "ReviewDue" },
                values: new object[] { null, null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("b3a5b7bf-72ca-4a85-bf14-6fbeeee9f387"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b3a5b7bf-72ca-4a85-bf14-6fbeeee9f387"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ContentBlock");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "ContentBlock",
                newName: "TextContent");

            migrationBuilder.AlterColumn<Guid>(
                name: "ReviewedUserId",
                table: "Skill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewDue",
                table: "Skill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                table: "Skill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDue",
                table: "Skill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirm",
                table: "ContentBlock",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "QuestionBank",
                keyColumn: "Id",
                keyValue: new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"),
                column: "CreatedDate",
                value: new DateOnly(2025, 5, 8));

            migrationBuilder.UpdateData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"),
                columns: new[] { "CreateDue", "ReviewDue" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("07e95d49-fd96-43cf-bd0f-97acb28edce6"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });
        }
    }
}
