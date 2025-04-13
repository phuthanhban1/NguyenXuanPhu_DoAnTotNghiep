using Application.Services.Implements;
using Application.Services.Interfaces;
using Infrastructure.Context;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ExamContext>(ops => ops.UseSqlServer(builder.Configuration.GetConnectionString("ExamConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IAnswerService, AnswerService>();
builder.Services.AddTransient<IImageFileService, ImageFileService>();
builder.Services.AddTransient<IUserService, UserService>();
//builder.Services.AddTransient<ICategoryService, CategoryService>();
//builder.Services.AddTransient<ITagService, TagService>();
//builder.Services.AddTransient<ICommentService, CommentService>();
//builder.Services.AddTransient<IRateService, RateService>();


// ---add auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
