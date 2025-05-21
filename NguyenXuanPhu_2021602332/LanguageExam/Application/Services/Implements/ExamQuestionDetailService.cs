using Application.Dtos.AnswerDtos;
using Application.Dtos.ContentBlockDtos;
using Application.Dtos.ExamQuestionDetailDtos;
using Application.Dtos.ExamStructDetail;
using Application.Dtos.QuestionDtos;
using Application.Exceptions;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implements
{
    public class ExamQuestionDetailService : IExamQuestionDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ExamQuestionDetailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task GenExam(ExamQuestionDetailCreateDto examQuestionDetailCreateDto)
        {
            var listExamQuestion = new List<ExamQuestionDetail>();
            var examQuestionId = await _unitOfWork.ExamQuestions.GetIdByExamId(examQuestionDetailCreateDto.ExamId);
            
            if(examQuestionId != Guid.Empty)
            {
                await DeleteDetail(examQuestionId);
                await _unitOfWork.SaveChangeAsync();
            } else
            {
                var examQuestion = new ExamQuestion
                {
                    Id = Guid.NewGuid(),
                    ExamId = examQuestionDetailCreateDto.ExamId,
                    ExamStructId = examQuestionDetailCreateDto.ExamStructId
                };
                examQuestionId = examQuestion.Id;
                await _unitOfWork.ExamQuestions.AddAsync(examQuestion);
            }

            var examStructs = await _unitOfWork.ExamStructDetails.GetAllByExamStructId(examQuestionDetailCreateDto.ExamStructId);
            Dictionary<Guid, List<ExamStructDetail>> dictQuestionTypes = new Dictionary<Guid, List<ExamStructDetail>>();
            examStructs.ForEach(e =>
            {
                if (!dictQuestionTypes.ContainsKey(e.QuestionTypeId))
                {
                    dictQuestionTypes[e.QuestionTypeId] = new List<ExamStructDetail>();
                }
                dictQuestionTypes[e.QuestionTypeId].Add(e);
            });
            // duyệt các questionType
            foreach (var key in  dictQuestionTypes.Keys)
            {
                // lấy tên skill

                // lấy tất cả content trong 1 question type
                var contentBlocks = await _unitOfWork.ContentBlocks.GetByQuestionTypeId(key);
                contentBlocks = contentBlocks.Where(c => c.Status == 1).ToList();
                foreach (var item in dictQuestionTypes[key])
                {
                    // lấy số lượng câu hỏi
                    var amount = await GetAmountOfStructDetail(item.Id);
                    for(int i = 0; i < amount; i++)
                    {
                        // lấy từng câu hỏi một
                        if (contentBlocks != null && contentBlocks.Count > 0)
                        {
                            Random rand = new Random();
                            int index = rand.Next(contentBlocks.Count);
                            var contentBlock = contentBlocks[index];
                            var examQuestionDetail = new ExamQuestionDetail
                            {
                                Id = Guid.NewGuid(),
                                ContentBlockId = contentBlock.Id,
                                ExamQuestionId = examQuestionId,
                                Skill = item.Skill,
                                Order = item.Order
                            };
                            await _unitOfWork.ContentBlocks.ChangeStatus(contentBlock.Id, 3);
                            await _unitOfWork.ExamQuestionDetails.AddAsync(examQuestionDetail);
                            listExamQuestion.Add(examQuestionDetail);
                            contentBlocks.RemoveAt(index);
                            var listGuid = await _unitOfWork.SimilarQuestions.GetSimilarQuestions(contentBlock.Id);
                            listGuid.ForEach(l =>
                            {
                                var index = contentBlocks.FindIndex(x => x.Id == l);
                                contentBlocks.RemoveAt(index);
                            });
                        }
                        
                    }
                }
            }
            await _unitOfWork.SaveChangeAsync();
            
        }
        public async Task<int> GetAmountOfStructDetail(Guid id)
        {
            var stuctDetail = _unitOfWork.ExamStructDetails.GetById(id).ToList();
            return stuctDetail[0].Amount;
        }

        public async Task DeleteDetail(Guid examQuestionId)
        {
            var list = await _unitOfWork.ExamQuestionDetails.GetAllByExamQuestionId(examQuestionId);
            list.ForEach(async l =>
            {
                await _unitOfWork.ContentBlocks.ChangeStatus(l.ContentBlockId, 1);
                await _unitOfWork.ExamQuestionDetails.DeleteAsync(l);
            });
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<Dictionary<string, Dictionary<int, List<ContentBlockExamDto>>>> GetExamQuestionDetail(Guid examId)
        {
            var examQuestion = await _unitOfWork.ExamQuestions.GetByExamId(examId);
            if(examQuestion == null)
            {
                throw new NotFoundException("Không tìm thấy mã đề thi");
            }
            var list = await _unitOfWork.ExamQuestionDetails.GetAllByExamQuestionId(examQuestion.Id);
            if (list == null)
            {
                throw new NotFoundException("Không tìm thấy danh sách câu hỏi");
            }
            Dictionary<string, Dictionary<int, List<ContentBlockExamDto>>> listQuestions = new Dictionary<string, Dictionary<int, List<ContentBlockExamDto>>>();
            foreach (var item in list)
            {
                var contentBlock = await _unitOfWork.ContentBlocks.GetContentBlockByIdAsync(item.ContentBlockId);
                var contentBlockDto = new ContentBlockExamDto();
                contentBlockDto.Id = contentBlock.Id;
                contentBlockDto.Content = contentBlock.Content;
                contentBlockDto.IsSingle = contentBlock.QuestionType.IsSingle;
                if(contentBlock.AudioFile != null)
                {
                    contentBlockDto.AudioBase64 = Convert.ToBase64String(contentBlock.AudioFile.FileData);
                }
                if (contentBlock.ImageFile != null)
                {
                    contentBlockDto.ImageBase64 = Convert.ToBase64String(contentBlock.ImageFile.FileData);
                }
                contentBlock.Questions.ForEach(q =>
                {
                    var questionDto = new QuestionCreateDto2
                    {
                        Content = q.Content,
                    };
                    q.Answers.ForEach(a =>
                    {
                        var answerDto = new AnswerDto
                        {
                            Id = a.Id,
                            Content = a.Content,
                            IsCorrect = (bool)a.IsCorrect
                        };
                        if(questionDto.Answers == null)
                        {
                            questionDto.Answers = new List<AnswerDto>();
                        }
                        questionDto.Answers.Add(answerDto);
                    });
                    if (contentBlockDto.Questions == null)
                    {
                        contentBlockDto.Questions = new List<QuestionCreateDto2>();
                    }
                    contentBlockDto.Questions.Add(questionDto);
                });
                if (!listQuestions.ContainsKey(item.Skill))
                {
                    listQuestions[item.Skill] = new Dictionary<int, List<ContentBlockExamDto>>();
                } else { 
                }
                if (!listQuestions[item.Skill].ContainsKey(item.Order))
                {
                    listQuestions[item.Skill][item.Order] = new List<ContentBlockExamDto>();
                }
                listQuestions[item.Skill][item.Order].Add(contentBlockDto);
            }
            return listQuestions;
        }
    }
}
