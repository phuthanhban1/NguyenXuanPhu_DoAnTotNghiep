using Application.Dtos.QuestionTypeDtos;
using Application.Exceptions;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.UnitOfWork;

namespace Application.Services.Implements
{
    public class QuestionTypeService : IQuestionTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public QuestionTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddAsync(QuestionTypeCreateDto questionLevelCreateDto)
        {
            var questionLevel = _mapper.Map<QuestionType>(questionLevelCreateDto);
            var check = await _unitOfWork.QuestionTypes.CheckNameBySkillId(questionLevelCreateDto.SkillId, questionLevelCreateDto.Name);
            if (check)
            {
                throw new BadRequestException("Không thể thêm do loại câu hỏi đã tồn tại");
            }
            await _unitOfWork.QuestionTypes.AddAsync(questionLevel);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<QuestionTypeCountDto>> CountQuestionType(Guid skillId)
        {
            var list = await _unitOfWork.QuestionTypes.GetsBySkillId(skillId);
            List<QuestionTypeCountDto> listDto = new List<QuestionTypeCountDto>();
            foreach(var qt in list)
            {
                var qtcd = _mapper.Map<QuestionTypeCountDto>(qt);
                var listDistinct = new List<ContentBlock>();
                
                while(qt.ContentBlocks.Count != 0)
                {
                    var first = qt.ContentBlocks.FirstOrDefault();
                    listDistinct.Add(first);
                    qt.ContentBlocks.RemoveAt(0);
                    var listGuid = await _unitOfWork.SimilarQuestions.GetSimilarQuestions(first.Id);
                    listGuid.ForEach(l =>
                    {
                        var index = qt.ContentBlocks.FindIndex(x => x.Id == l);
                        qt.ContentBlocks.RemoveAt(index);
                    });
                }
                qtcd.Count = listDistinct.Count;
                listDto.Add(qtcd);
            }
            return listDto;
        }

        public Task<List<QuestionTypeCountDto>> CountQuestionType(Guid skillId, string skillName)
        {
            throw new NotImplementedException();
        }

        // lấy số lượng dạng còn lại
        public async Task<List<QuestionTypeCountDto>> CountQuestionType2(Guid skillId, Guid structId)
        {
            var skill = await _unitOfWork.Skills.GetByIdAsync(skillId);
            var list = await this.CountQuestionType(skillId);
            Dictionary<Guid, QuestionTypeCountDto> dictQuestionType = new Dictionary<Guid, QuestionTypeCountDto>();
            foreach (var qt in list)
            {
                dictQuestionType.Add(qt.Id, qt);
            }
            Dictionary<Guid, int> dictExamStructDetail = new Dictionary<Guid, int>();
            var listStructDetail = await _unitOfWork.ExamStructDetails.GetByExamStructId(structId, skill.Name);
            listStructDetail.ForEach(l =>
            {
                if(dictExamStructDetail.ContainsKey(l.QuestionTypeId))
                {
                    dictExamStructDetail[l.QuestionTypeId] += l.Amount;
                } else
                {
                    dictExamStructDetail.Add(l.QuestionTypeId, 0);
                }    
            });
            foreach (Guid key in dictExamStructDetail.Keys)
            {
                dictQuestionType[key].Count -= dictExamStructDetail[key];
            }
            return dictQuestionType.Values.ToList();

        }

        public async Task DeleteAsync(Guid id)
        {
            var questionLevel = await _unitOfWork.QuestionTypes.GetByIdAsync(id);
            if (questionLevel == null)
            {
                throw new NotFoundException("Không tìm thấy loại câu hỏi");
            }
            
            var listContent = await _unitOfWork.ContentBlocks.GetByQuestionTypeId(id);
            if (listContent != null && listContent.Count > 0)
            {
                throw new BadRequestException("Không thể xóa do dạng câu hỏi này đã có câu hỏi");
            }
            await _unitOfWork.QuestionTypes.DeleteAsync(questionLevel);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<QuestionType>> GetAllAsync()
        {
            var questionLevels = await _unitOfWork.QuestionTypes.GetAllAsync();
           
            return questionLevels.ToList(); // Explicitly convert IEnumerable to List
        }

        public async Task<QuestionTypeUpdateDto> GetByIdAsync(Guid id)
        {
            var questionLevel = await _unitOfWork.QuestionTypes.GetByIdAsync(id);
            if (questionLevel == null)
            {
                throw new NotFoundException("Không tìm thấy loại câu hỏi");
            }
            
            var questionLevelDto = _mapper.Map<QuestionTypeUpdateDto>(questionLevel);
            return questionLevelDto;
        }

        public async Task<List<QuestionTypeDto>> GetsBySkillId(Guid skillId)
        {
            var list = await _unitOfWork.QuestionTypes.GetsBySkillId(skillId);
            return _mapper.Map<List<QuestionTypeDto>>(list);
        }

        public async Task UpdateAsync(QuestionTypeUpdateDto questionTypeUpdateDto)
        {
            var questionLevel = await _unitOfWork.QuestionTypes.GetByIdAsync(questionTypeUpdateDto.Id);
            
            if (questionLevel == null)
            {
                throw new NotFoundException("Không tìm thấy loại câu hỏi");
            }
            if(questionLevel.Name != questionTypeUpdateDto.Name)
            {
                var check = await _unitOfWork.QuestionTypes.CheckNameBySkillId(questionTypeUpdateDto.SkillId, questionTypeUpdateDto.Name);
                if (check)
                {
                    throw new BadRequestException("Không thể sửa do loại câu hỏi đã tồn tại");
                }
            }
            
            _mapper.Map(questionTypeUpdateDto, questionLevel);

            await _unitOfWork.QuestionTypes.UpdateAsync(questionLevel);
            await _unitOfWork.SaveChangeAsync();

        }
    }
}
