using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class detailResult1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailResult_Examinee_UserId_ExamId",
                table: "DetailResult");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("cedb1899-fde8-4146-8af0-743e6d3ebcf0"));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("f0fdd836-8295-4cfd-9efb-55dbccc55b53"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });

            migrationBuilder.AddForeignKey(
                name: "FK_DetailResult_Examinee_UserId_ExamId",
                table: "DetailResult",
                columns: new[] { "UserId", "ExamId" },
                principalTable: "Examinee",
                principalColumns: new[] { "ExamId", "UserId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailResult_Examinee_UserId_ExamId",
                table: "DetailResult");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f0fdd836-8295-4cfd-9efb-55dbccc55b53"));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("cedb1899-fde8-4146-8af0-743e6d3ebcf0"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });

            migrationBuilder.AddForeignKey(
                name: "FK_DetailResult_Examinee_UserId_ExamId",
                table: "DetailResult",
                columns: new[] { "UserId", "ExamId" },
                principalTable: "Examinee",
                principalColumns: new[] { "ExamId", "UserId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
