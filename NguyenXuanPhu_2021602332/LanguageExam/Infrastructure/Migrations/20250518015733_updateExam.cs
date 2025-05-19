using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateExam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("dabc2eb7-ae81-43a6-9de8-fa81a12fe3b7"));

            migrationBuilder.DropColumn(
                name: "BeginDate",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Exam");

            migrationBuilder.RenameColumn(
                name: "RegisterStartDate",
                table: "Exam",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "RegisterEndDate",
                table: "Exam",
                newName: "RegistDate");

            migrationBuilder.RenameColumn(
                name: "CreateDue",
                table: "Exam",
                newName: "CreateQuestionDue");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("c64fab69-f14f-4869-a501-1db9aebc0b4e"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c64fab69-f14f-4869-a501-1db9aebc0b4e"));

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Exam",
                newName: "RegisterStartDate");

            migrationBuilder.RenameColumn(
                name: "RegistDate",
                table: "Exam",
                newName: "RegisterEndDate");

            migrationBuilder.RenameColumn(
                name: "CreateQuestionDue",
                table: "Exam",
                newName: "CreateDue");

            migrationBuilder.AddColumn<DateTime>(
                name: "BeginDate",
                table: "Exam",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Exam",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("dabc2eb7-ae81-43a6-9de8-fa81a12fe3b7"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });
        }
    }
}
