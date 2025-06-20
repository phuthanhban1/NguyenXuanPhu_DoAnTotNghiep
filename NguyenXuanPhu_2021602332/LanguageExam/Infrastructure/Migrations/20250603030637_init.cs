﻿using System;
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
                name: "ExamFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamFile", x => x.Id);
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
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
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
                    DateOfIssue = table.Column<DateOnly>(type: "date", nullable: true),
                    PlaceOfIssue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
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
                        name: "FK_User_ExamFile_ImageFaceId",
                        column: x => x.ImageFaceId,
                        principalTable: "ExamFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_ExamFile_ImageIdCardAfterId",
                        column: x => x.ImageIdCardAfterId,
                        principalTable: "ExamFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_ExamFile_ImageIdCardBeforeId",
                        column: x => x.ImageIdCardBeforeId,
                        principalTable: "ExamFile",
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
                name: "Exam",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Fee = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateQuestionDue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCreated = table.Column<bool>(type: "bit", nullable: false),
                    CreatedQuestionUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.Id);
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
                name: "QuestionBank",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
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
                name: "Examinee",
                columns: table => new
                {
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location = table.Column<int>(type: "int", nullable: true),
                    IsExamTaken = table.Column<bool>(type: "bit", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReadingScore = table.Column<int>(type: "int", nullable: true),
                    ListeningScore = table.Column<int>(type: "int", nullable: true),
                    SpeakingScore = table.Column<int>(type: "int", nullable: true),
                    WritingScore = table.Column<int>(type: "int", nullable: true),
                    ExamineeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Examinee_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Examinee_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamStruct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionBankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserCreateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamStruct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamStruct_QuestionBank_QuestionBankId",
                        column: x => x.QuestionBankId,
                        principalTable: "QuestionBank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamStruct_User_UserCreateId",
                        column: x => x.UserCreateId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReviewDue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReviewedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    QuestionBankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
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
                name: "ExamQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamStructId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamQuestion_ExamStruct_ExamStructId",
                        column: x => x.ExamStructId,
                        principalTable: "ExamStruct",
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
                name: "QuestionType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSingle = table.Column<bool>(type: "bit", nullable: false),
                    HasImage = table.Column<bool>(type: "bit", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionType_Skill_SkillId",
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
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AudioFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ImageFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    QuestionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentBlock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentBlock_ExamFile_AudioFileId",
                        column: x => x.AudioFileId,
                        principalTable: "ExamFile",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContentBlock_ExamFile_ImageFileId",
                        column: x => x.ImageFileId,
                        principalTable: "ExamFile",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContentBlock_QuestionType_QuestionTypeId",
                        column: x => x.QuestionTypeId,
                        principalTable: "QuestionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamStructDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Skill = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    QuestionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<byte>(type: "tinyint", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "ExamQuestionDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Skill = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ContentBlockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestionDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamQuestionDetail_ContentBlock_ContentBlockId",
                        column: x => x.ContentBlockId,
                        principalTable: "ContentBlock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamQuestionDetail_ExamQuestion_ExamQuestionId",
                        column: x => x.ExamQuestionId,
                        principalTable: "ExamQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Score = table.Column<byte>(type: "tinyint", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "SimilarQuestion",
                columns: table => new
                {
                    ContentBlockId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentBlockId2 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Score = table.Column<float>(type: "real", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimilarQuestion", x => new { x.ContentBlockId1, x.ContentBlockId2 });
                    table.ForeignKey(
                        name: "FK_SimilarQuestion_ContentBlock_ContentBlockId1",
                        column: x => x.ContentBlockId1,
                        principalTable: "ContentBlock",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SimilarQuestion_ContentBlock_ContentBlockId2",
                        column: x => x.ContentBlockId2,
                        principalTable: "ContentBlock",
                        principalColumn: "Id");
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
                name: "DetailResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Skill = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        name: "FK_DetailResult_Examinee_ExamId_UserId",
                        columns: x => new { x.ExamId, x.UserId },
                        principalTable: "Examinee",
                        principalColumns: new[] { "ExamId", "UserId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), "quản trị viên" },
                    { new Guid("316f8c9c-a9a2-4b17-b4c4-6434d165bc62"), "quản lý ngân hàng câu hỏi" },
                    { new Guid("45b76d26-26e2-41d1-a0f7-ed6b55dc2190"), "người tạo đề" },
                    { new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"), "người đánh giá câu hỏi" },
                    { new Guid("85af4517-be3b-4ea9-b2cd-1ad9b4417870"), "quản lý kỳ thi" },
                    { new Guid("93d09639-a7b9-4825-b364-30366908b007"), "người tạo câu hỏi" },
                    { new Guid("a0e4f1d5-3c8b-4f2a-8e6c-7d9b5e0a2f1d"), "thí sinh" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "DateOfIssue", "Email", "FullName", "Gender", "IdCard", "ImageFaceId", "ImageIdCardAfterId", "ImageIdCardBeforeId", "IsActive", "Password", "PhoneNumber", "PlaceOfIssue", "RoleId", "Strict", "WardId" },
                values: new object[,]
                {
                    { new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"), null, null, "review@gmail.com", "Đánh Giá Câu", null, null, null, null, null, true, "1", null, null, new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"), null, null },
                    { new Guid("8a7dd16f-85bf-4143-be0b-a31da3bbe44a"), null, null, "quanlybank@gmail.com", "Quản lý bank", null, null, null, null, null, true, "1", null, null, new Guid("316f8c9c-a9a2-4b17-b4c4-6434d165bc62"), null, null },
                    { new Guid("93d09639-a7b9-4825-b364-30366908b007"), null, null, "taocau@gmail.com", "Tạo Câu Hỏi", null, null, null, null, null, true, "1", null, null, new Guid("93d09639-a7b9-4825-b364-30366908b007"), null, null },
                    { new Guid("a851f658-9397-435d-8d2f-cbd356f76848"), null, null, "phuthanhban3@gmail.com", "Nguyễn Xuân Phú", null, null, null, null, null, true, "1", null, null, new Guid("2959ca56-a667-46a0-acea-eba1e9961419"), null, null }
                });

            migrationBuilder.InsertData(
                table: "QuestionBank",
                columns: new[] { "Id", "CreatedDate", "Language", "ManagerId", "Name", "Status" },
                values: new object[] { new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"), new DateOnly(2025, 6, 3), "Hàn", new Guid("8a7dd16f-85bf-4143-be0b-a31da3bbe44a"), "Topik 1", (byte)0 });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "CreateDue", "CreatedUserId", "Name", "QuestionBankId", "ReviewDue", "ReviewedUserId" },
                values: new object[] { new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"), null, new Guid("93d09639-a7b9-4825-b364-30366908b007"), "Đọc", new Guid("61af889a-7617-43e7-9cb2-537a01e97a34"), null, new Guid("61af889a-7617-43e7-9cb2-537a01e97a34") });

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
                name: "IX_ContentBlock_ImageFileId",
                table: "ContentBlock",
                column: "ImageFileId",
                unique: true,
                filter: "[ImageFileId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContentBlock_QuestionTypeId",
                table: "ContentBlock",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailResult_AnswerId",
                table: "DetailResult",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailResult_ExamId_UserId",
                table: "DetailResult",
                columns: new[] { "ExamId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_District_ProvinceId",
                table: "District",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_CreatedQuestionUserId",
                table: "Exam",
                column: "CreatedQuestionUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_ManagerId",
                table: "Exam",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Examinee_RoomId",
                table: "Examinee",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Examinee_UserId",
                table: "Examinee",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestion_ExamId",
                table: "ExamQuestion",
                column: "ExamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestion_ExamStructId",
                table: "ExamQuestion",
                column: "ExamStructId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestionDetail_ContentBlockId",
                table: "ExamQuestionDetail",
                column: "ContentBlockId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestionDetail_ExamQuestionId",
                table: "ExamQuestionDetail",
                column: "ExamQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamStruct_QuestionBankId",
                table: "ExamStruct",
                column: "QuestionBankId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamStruct_UserCreateId",
                table: "ExamStruct",
                column: "UserCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamStructDetail_ExamStructId",
                table: "ExamStructDetail",
                column: "ExamStructId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamStructDetail_QuestionTypeId",
                table: "ExamStructDetail",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_ContentBlockId",
                table: "Question",
                column: "ContentBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionBank_ManagerId",
                table: "QuestionBank",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionBank_Name",
                table: "QuestionBank",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionType_SkillId",
                table: "QuestionType",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_Name",
                table: "Room",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SimilarQuestion_ContentBlockId2",
                table: "SimilarQuestion",
                column: "ContentBlockId2");

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
                name: "ExamQuestionDetail");

            migrationBuilder.DropTable(
                name: "ExamStructDetail");

            migrationBuilder.DropTable(
                name: "SimilarQuestion");

            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "Examinee");

            migrationBuilder.DropTable(
                name: "ExamQuestion");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "ExamStruct");

            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropTable(
                name: "ContentBlock");

            migrationBuilder.DropTable(
                name: "QuestionType");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "QuestionBank");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ExamFile");

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
