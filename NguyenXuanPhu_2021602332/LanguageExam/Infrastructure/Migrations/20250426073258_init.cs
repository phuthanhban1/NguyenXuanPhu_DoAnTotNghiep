using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AudioFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioFile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ward",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ward", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ward_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gener = table.Column<bool>(type: "bit", nullable: true),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strict = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    WardId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageFaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ImageIdCardBeforeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ImageIdCardAfterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_ImageFile_ImageFaceId",
                        column: x => x.ImageFaceId,
                        principalTable: "ImageFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_ImageFile_ImageIdCardAfterId",
                        column: x => x.ImageIdCardAfterId,
                        principalTable: "ImageFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_ImageFile_ImageIdCardBeforeId",
                        column: x => x.ImageIdCardBeforeId,
                        principalTable: "ImageFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Ward_WardId",
                        column: x => x.WardId,
                        principalTable: "Ward",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestionBank",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuestionCreateDue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuestionReviewDue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionBank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionBank_User_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionBankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AudioFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skill_AudioFile_AudioFileId",
                        column: x => x.AudioFileId,
                        principalTable: "AudioFile",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Skill_QuestionBank_QuestionBankId",
                        column: x => x.QuestionBankId,
                        principalTable: "QuestionBank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skill_User_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Skill_User_ReviewedUserId",
                        column: x => x.ReviewedUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionLevel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionLevel_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentBlock",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsConfirm = table.Column<bool>(type: "bit", nullable: false),
                    QuestionAmount = table.Column<byte>(type: "tinyint", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    UnConFirmedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionStruct = table.Column<int>(type: "int", nullable: false),
                    AudioFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    QuestionLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentBlock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentBlock_AudioFile_AudioFileId",
                        column: x => x.AudioFileId,
                        principalTable: "AudioFile",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContentBlock_QuestionLevel_QuestionLevelId",
                        column: x => x.QuestionLevelId,
                        principalTable: "QuestionLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamQuestionStruct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Skill = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    QuestionLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestionStruct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamQuestionStruct_QuestionLevel_QuestionLevelId",
                        column: x => x.QuestionLevelId,
                        principalTable: "QuestionLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContentBlockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_ContentBlock_ContentBlockId",
                        column: x => x.ContentBlockId,
                        principalTable: "ContentBlock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Question_ImageFile_ImageFileId",
                        column: x => x.ImageFileId,
                        principalTable: "ImageFile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fee = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedQuestionUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamStructId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exam_ExamQuestionStruct_ExamStructId",
                        column: x => x.ExamStructId,
                        principalTable: "ExamQuestionStruct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exam_User_CreatedQuestionUserId",
                        column: x => x.CreatedQuestionUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exam_User_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: true),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Examinee",
                columns: table => new
                {
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Room = table.Column<int>(type: "int", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examinee", x => new { x.ExamId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Examinee_Exam_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Skill = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentBlockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamQuestion_ContentBlock_ContentBlockId",
                        column: x => x.ContentBlockId,
                        principalTable: "ContentBlock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamQuestion_Exam_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionNumber = table.Column<int>(type: "int", nullable: false),
                    AnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailResult_Answer_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DetailResult_Examinee_UserId_ExamId",
                        columns: x => new { x.UserId, x.ExamId },
                        principalTable: "Examinee",
                        principalColumns: new[] { "ExamId", "UserId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), "Admin" },
                    { new Guid("316f8c9c-a9a2-4b17-b4c4-6434d165bc62"), "QuestionBankManager" },
                    { new Guid("45b76d26-26e2-41d1-a0f7-ed6b55dc2190"), "TestCreator" },
                    { new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"), "QuestionReviewer" },
                    { new Guid("85af4517-be3b-4ea9-b2cd-1ad9b4417870"), "ExamManager" },
                    { new Guid("8a7dd16f-85bf-4143-be0b-a31da3bbe44a"), "User" },
                    { new Guid("93d09639-a7b9-4825-b364-30366908b007"), "QuestionContributor" },
                    { new Guid("a0e4f1d5-3c8b-4f2a-8e6c-7d9b5e0a2f1d"), "Examinee" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "Email", "FullName", "Gener", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "RoleId", "Strict", "WardId" },
                values: new object[] { new Guid("e5ba2233-2ded-48b9-a314-da9ee3b0db03"), null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionId",
                table: "Answer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentBlock_AudioFileId",
                table: "ContentBlock",
                column: "AudioFileId",
                unique: true,
                filter: "[AudioFileId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContentBlock_QuestionLevelId",
                table: "ContentBlock",
                column: "QuestionLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailResult_AnswerId",
                table: "DetailResult",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailResult_UserId_ExamId",
                table: "DetailResult",
                columns: new[] { "UserId", "ExamId" });

            migrationBuilder.CreateIndex(
                name: "IX_District_ProvinceId",
                table: "District",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_CreatedQuestionUserId",
                table: "Exam",
                column: "CreatedQuestionUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_ExamStructId",
                table: "Exam",
                column: "ExamStructId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exam_ManagerId",
                table: "Exam",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestion_ContentBlockId",
                table: "ExamQuestion",
                column: "ContentBlockId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestion_ExamId",
                table: "ExamQuestion",
                column: "ExamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestionStruct_QuestionLevelId",
                table: "ExamQuestionStruct",
                column: "QuestionLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_ContentBlockId",
                table: "Question",
                column: "ContentBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_ImageFileId",
                table: "Question",
                column: "ImageFileId",
                unique: true,
                filter: "[ImageFileId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionBank_ManagerId",
                table: "QuestionBank",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionLevel_SkillId",
                table: "QuestionLevel",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_AudioFileId",
                table: "Skill",
                column: "AudioFileId",
                unique: true,
                filter: "[AudioFileId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_CreatedUserId",
                table: "Skill",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_QuestionBankId",
                table: "Skill",
                column: "QuestionBankId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_ReviewedUserId",
                table: "Skill",
                column: "ReviewedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ImageFaceId",
                table: "User",
                column: "ImageFaceId",
                unique: true,
                filter: "[ImageFaceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_ImageIdCardAfterId",
                table: "User",
                column: "ImageIdCardAfterId",
                unique: true,
                filter: "[ImageIdCardAfterId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_ImageIdCardBeforeId",
                table: "User",
                column: "ImageIdCardBeforeId",
                unique: true,
                filter: "[ImageIdCardBeforeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_WardId",
                table: "User",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_Ward_DistrictId",
                table: "Ward",
                column: "DistrictId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailResult");

            migrationBuilder.DropTable(
                name: "ExamQuestion");

            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "Examinee");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropTable(
                name: "ContentBlock");

            migrationBuilder.DropTable(
                name: "ExamQuestionStruct");

            migrationBuilder.DropTable(
                name: "QuestionLevel");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "AudioFile");

            migrationBuilder.DropTable(
                name: "QuestionBank");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ImageFile");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Ward");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "Province");
        }
    }
}
