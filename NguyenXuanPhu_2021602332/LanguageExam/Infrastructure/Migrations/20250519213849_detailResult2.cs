using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class detailResult2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailResult_Examinee_UserId_ExamId",
                table: "DetailResult");

            migrationBuilder.DropIndex(
                name: "IX_DetailResult_UserId_ExamId",
                table: "DetailResult");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f0fdd836-8295-4cfd-9efb-55dbccc55b53"));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("55b8d8d5-56b1-440a-92a6-ee7cbed4378d"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });

            migrationBuilder.CreateIndex(
                name: "IX_DetailResult_ExamId_UserId",
                table: "DetailResult",
                columns: new[] { "ExamId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DetailResult_Examinee_ExamId_UserId",
                table: "DetailResult",
                columns: new[] { "ExamId", "UserId" },
                principalTable: "Examinee",
                principalColumns: new[] { "ExamId", "UserId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailResult_Examinee_ExamId_UserId",
                table: "DetailResult");

            migrationBuilder.DropIndex(
                name: "IX_DetailResult_ExamId_UserId",
                table: "DetailResult");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("55b8d8d5-56b1-440a-92a6-ee7cbed4378d"));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("f0fdd836-8295-4cfd-9efb-55dbccc55b53"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });

            migrationBuilder.CreateIndex(
                name: "IX_DetailResult_UserId_ExamId",
                table: "DetailResult",
                columns: new[] { "UserId", "ExamId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DetailResult_Examinee_UserId_ExamId",
                table: "DetailResult",
                columns: new[] { "UserId", "ExamId" },
                principalTable: "Examinee",
                principalColumns: new[] { "ExamId", "UserId" });
        }
    }
}
