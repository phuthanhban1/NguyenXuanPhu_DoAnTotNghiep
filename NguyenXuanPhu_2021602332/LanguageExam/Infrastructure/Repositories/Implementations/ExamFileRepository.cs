using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Implementations
{
    public class ExamFileRepository : GenericRepository<Domain.Entities.ExamFile>, IExamFileRepository
    {
        public ExamFileRepository(ExamContext context) : base(context)
        {

        }

        

        //public async Task UpdateImageFile(Guid id, IFormFile file)
        //{
            
        //    using var memoryStream = new MemoryStream();
        //    await file.CopyToAsync(memoryStream);

        //    var image = await _context.FindAsync(id);


        //    else
        //    {
        //        image.FileName = file.FileName;
        //        image.FileData = memoryStream.ToArray();
        //        image.ContentType = file.ContentType;
        //        await _unitOfWork.ImageFiles.UpdateAsync(image);
        //        await _unitOfWork.SaveChangeAsync();
        //    }
        //}
    }
}
