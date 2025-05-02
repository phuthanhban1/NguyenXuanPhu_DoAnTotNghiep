using Application.Dtos.ContentBlockDtos;
using Application.Services;
using Domain.Entities;
using System.Text;

var oldContents = new List<ContentBlockDto>();
oldContents.Add(new ContentBlockDto() { Content = "오늘 날씨 어때요?" });
oldContents.Add(new ContentBlockDto() { Content =  "어디에 가고 계세요?" });
oldContents.Add(new ContentBlockDto() { Content = "지금 몇 시예요?" });
oldContents.Add(new ContentBlockDto() { Content = "무슨 일이 있었나요?" });
oldContents.Add(new ContentBlockDto() { Content = "점심 먹었어요?" });



var newContents = new List<ContentBlockDto>();
newContents.Add(new ContentBlockDto() { Content = "식사하셨어요?" });
newContents.Add(new ContentBlockDto() { Content = "무슨 일 있어요?" });
newContents.Add(new ContentBlockDto() { Content = "현재 시간이 어떻게 되나요?" });
newContents.Add(new ContentBlockDto() { Content = "어디 가세요?" });
newContents.Add(new ContentBlockDto() { Content = "날씨가 어떤가요?" });

var list = await ExtensionService.SimilarCheck(oldContents, newContents);
Console.OutputEncoding = Encoding.UTF8;
list.ForEach(x => Console.WriteLine(x.Score + "\n" + x.Reason));
