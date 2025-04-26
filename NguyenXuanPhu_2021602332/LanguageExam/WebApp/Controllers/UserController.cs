using Application.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        private const string ApiUser = "https://localhost:7001/api/user";
        private readonly HttpClient _httpClient;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Register(Guid id)
        {
            var response = await _httpClient.GetAsync($"{ApiUser}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var user = await response.Content.ReadFromJsonAsync<UserDto>();
                return View(user);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserCreateDto userCreateDto)
        {
            if (!ModelState.IsValid)
            {
                // Nếu ModelState lỗi thì trả lại view cho người dùng sửa
                foreach (var state in ModelState)
                {
                    var key = state.Key; // tên field (ví dụ: "Username", "Email")
                    var errors = state.Value.Errors; // danh sách lỗi liên quan đến field đó

                    foreach (var error in errors)
                    {
                        var errorMessage = error.ErrorMessage; // nội dung lỗi cụ thể
                        Console.WriteLine($"Field: {key} - Error: {errorMessage}");
                    }
                }
                return View(userCreateDto);
            }

            using (var content = new MultipartFormDataContent())
            {
                // Thêm các field dạng text
                content.Add(new StringContent(userCreateDto.IdCard ?? ""), "IdCard");
                if (userCreateDto.DateOfIssue.HasValue)
                    content.Add(new StringContent(userCreateDto.DateOfIssue.Value.ToString("yyyy-MM-dd")), "DateOfIssue");
                content.Add(new StringContent(userCreateDto.PlaceOfIssue ?? ""), "PlaceOfIssue");
                content.Add(new StringContent(userCreateDto.Gender.ToString()), "Gender");
                content.Add(new StringContent(userCreateDto.DateOfBirth.ToString("yyyy-MM-dd")), "DateOfBirth");
                content.Add(new StringContent(userCreateDto.Password ?? ""), "Password");
                content.Add(new StringContent(userCreateDto.FullName ?? ""), "FullName");
                content.Add(new StringContent(userCreateDto.Email ?? ""), "Email");
                content.Add(new StringContent(userCreateDto.PhoneNumber ?? ""), "PhoneNumber");
                content.Add(new StringContent(userCreateDto.Strict ?? ""), "Strict");
                content.Add(new StringContent(userCreateDto.WardId.ToString()), "WardId");

                // Thêm các file
                if (userCreateDto.ImageFace != null)
                {
                    var imageContent = new StreamContent(userCreateDto.ImageFace.OpenReadStream());
                    imageContent.Headers.ContentType = new MediaTypeHeaderValue(userCreateDto.ImageFace.ContentType);
                    content.Add(imageContent, "ImageFace", userCreateDto.ImageFace.FileName);
                }

                if (userCreateDto.ImageIdCardBefore != null)
                {
                    var imageContent = new StreamContent(userCreateDto.ImageIdCardBefore.OpenReadStream());
                    imageContent.Headers.ContentType = new MediaTypeHeaderValue(userCreateDto.ImageIdCardBefore.ContentType);
                    content.Add(imageContent, "ImageIdCardBefore", userCreateDto.ImageIdCardBefore.FileName);
                }

                if (userCreateDto.ImageIdCardAfter != null)
                {
                    var imageContent = new StreamContent(userCreateDto.ImageIdCardAfter.OpenReadStream());
                    imageContent.Headers.ContentType = new MediaTypeHeaderValue(userCreateDto.ImageIdCardAfter.ContentType);
                    content.Add(imageContent, "ImageIdCardAfter", userCreateDto.ImageIdCardAfter.FileName);
                }

                // Gửi FormData tới API
                var response = await _httpClient.PostAsync(ApiUser, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Lỗi khi gửi API: " + errorContent);
                    ModelState.AddModelError("", "Đăng ký thất bại: " + errorContent);
                    return View(userCreateDto);
                }
            }

        }
    }
}
