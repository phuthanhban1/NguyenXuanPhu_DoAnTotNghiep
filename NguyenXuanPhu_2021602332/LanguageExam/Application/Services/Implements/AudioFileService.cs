using Application.Services.Interfaces;
using Infrastructure.UnitOfWork;

namespace Application.Services.Implements
{
    public class AudioFileService : ImageFileService, IAudioFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AudioFileService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
