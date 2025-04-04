using Domain.Entities;
using System.Text;

Answer answer = new Answer
{
    Id = Guid.NewGuid(),
    Content = "안녕하세요"
};
Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine(answer.Content);