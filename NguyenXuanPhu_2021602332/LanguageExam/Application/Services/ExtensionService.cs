using Application.Dtos.ContentBlockDtos;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;




namespace Application.Services
{
    public class ExtensionService
    {
        static readonly HttpClient client = new HttpClient();
        static string apiKey = ""; // Thay bằng API key Gemini của bạn
        static string model = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={apiKey}";

        public static async Task SendEmailAsync(string fromEmail, string fromName, string toEmail, string subject, string body)
        {
            var fromAddress = new MailAddress(fromEmail, fromName);
            var toAddress = new MailAddress(toEmail);
            const string fromPassword = "bzbz pjvm lqeo yndu";
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            {
                await smtp.SendMailAsync(message);
            }
        }
        public static async Task<ImageFile> GetImageFile(IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            Guid idImage = Guid.NewGuid();
            var image = new ImageFile
            {
                Id = idImage,
                FileName = file.FileName,
                FileData = memoryStream.ToArray(),
                ContentType = file.ContentType
            };
            return image;
        }
        public static async Task<string> FormatReasonGPT(string a)
        {
            a = Regex.Replace(a, @"(?m)^\*\s*", "");
            a = a.Replace("*", "");
            a = Regex.Replace(a, @"\s+", " ");

            // 2. Chuyển **bold** sang <strong>
            a = Regex.Replace(a, @"\*\*(.+?)\*\*", "<strong>$1</strong>");

            // 3. Thêm <br><br> trước mỗi từ in đậm để dễ xuống dòng mỗi lần giải thích từ mới
            a = Regex.Replace(a, @"(?=<strong>)", "<br>");

            // 4. Tách các đoạn theo khoảng trắng lớn (giữa các đoạn) và bao bởi <p>
            var paragraphs = a.Split(new string[] { "\n\n", "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string html = "";
            foreach (var p in paragraphs)
            {
                var cleaned = p.Trim().Replace("\n", " ").Replace("\r", " ");
                html += $"<p>{cleaned}</p>\n";
            }

            return html;
        }
        static async Task<(float Score, string Reason)> GetScoreAndReasonFromGemini(string prompt)
        {
            var requestBody = new
            {
                contents = new[]
                {
                new
                {
                    parts = new[]
                    {
                        new { text = prompt }
                    }
                }
            }
            };
            float score = -1;
            string reason = "";
            string contentText = "";
            var requestJson = JsonSerializer.Serialize(requestBody);
            while(score < 0)
            {
                var request = new HttpRequestMessage(HttpMethod.Post, model);
                request.Content = new StringContent(requestJson, Encoding.UTF8, "application/json");
                var response = await client.SendAsync(request);
                var responseString = await response.Content.ReadAsStringAsync();

                contentText = JObject.Parse(responseString)?["candidates"]?[0]?["content"]?["parts"]?[0]?["text"]?.ToString() ?? "";
                // Parse điểm
                var match = Regex.Match(contentText, @"(\d+(\.\d+)?)");
                if (match.Success) float.TryParse(match.Groups[1].Value, out score);
                await Task.Delay(100);
            }

            if (score >= 7)
            {
                var index = contentText.IndexOf("Lý do:");
                if (index != -1)
                {
                    // Lấy từ sau "Lý do:" đến hết chuỗi
                    reason = contentText.Substring(index + "Lý do:".Length).Trim();
                }
                //Console.OutputEncoding = Encoding.UTF8;

                reason = await FormatReasonGPT(reason);
            }

            return (score, reason);
        }

        public static async Task<List<SimilarQuestion>> 
        SimilarCheck(List<ContentBlockDto> oldList, List<ContentBlockDto> newList)
        {
            var results = new List<SimilarQuestion>();

            for (int i = 0; i < newList.Count; i++)
            {
                for (int j = 0; j < oldList.Count; j++)
                {
                    var q1 = newList[i];
                    var q2 = oldList[j];

                    var prompt = @$"So sánh mức độ giống nhau về ý nghĩa giữa hai câu hỏi tiếng Hàn sau đây:
                            1. {q1.Content}
                            2. {q2.Content}
                            Trả lời theo định dạng sau:
                            Đánh giá: [0–10]
                            Lý do: ...";

                    var scoreAndReason = await GetScoreAndReasonFromGemini(prompt);

                    Guid id1 = q1.Id < q2.Id ? q1.Id : q2.Id;
                    Guid id2 = q1.Id >= q2.Id ? q1.Id : q2.Id;
                    if (scoreAndReason.Score >= 7)
                    {
                        results.Add(new SimilarQuestion()
                        {
                            ContentBlockId1 = id1,
                            ContentBlockId2 = id2,
                            Score = scoreAndReason.Score,
                            Reason = scoreAndReason.Reason
                        });
                    }
                }
            }

            for (int i = 0; i < newList.Count; i++)
            {
                for (int j = i + 1; j < newList.Count; j++)
                {
                    var q1 = newList[i];
                    var q2 = newList[j];

                    var prompt = @$"So sánh mức độ giống nhau về ý nghĩa giữa hai câu hỏi tiếng Hàn sau đây:
                            1. {q1.Content}
                            2. {q2.Content}
                            Trả lời theo định dạng sau:
                            Đánh giá: [0–10]
                            Lý do: ...";

                    var scoreAndReason = await GetScoreAndReasonFromGemini(prompt);
                    Guid id1 = q1.Id < q2.Id ? q1.Id : q2.Id;
                    Guid id2 = q1.Id >= q2.Id ? q1.Id : q2.Id;
                    if (scoreAndReason.Score >= 7)
                    {
                        results.Add(new SimilarQuestion()
                        {
                            ContentBlockId1 = id1,
                            ContentBlockId2 = id2,
                            Score = scoreAndReason.Score,
                            Reason = scoreAndReason.Reason
                        });
                    }
                }
            }
            return results;
        }
    }
}
