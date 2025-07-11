﻿using Application.Services.Implements;
using Application.Services.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json;
using WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ExamContext>(ops => ops.UseSqlServer(builder.Configuration.GetConnectionString("ExamConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<IExamFileService, ExamFileService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IProvinceService, ProvinceService>();
builder.Services.AddTransient<IDistrictService, DistrictService>();
builder.Services.AddTransient<IWardService, WardService>();
builder.Services.AddTransient<IQuestionBankService, QuestionBankService>();
builder.Services.AddTransient<IExamService, ExamService>();
builder.Services.AddTransient<ISkillService, SkillService>();
builder.Services.AddTransient<IQuestionTypeService, QuestionTypeService>();
builder.Services.AddTransient<IContentBlockService, ContentBlockService>();
builder.Services.AddTransient<IExamStructService, ExamStructService>();
builder.Services.AddTransient<IExamStructDetailService, ExamStructDetailService>();
builder.Services.AddTransient<IExamQuestionDetailService, ExamQuestionDetailService>();
builder.Services.AddTransient<IExamQuestionService, ExamQuestionService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<IRoomService, RoomService>();
builder.Services.AddTransient<IExamineeService, ExamineeService>();
builder.Services.AddTransient<IDetailResultService, DetailResultService>();



// DI auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var jwtSetting = builder.Configuration.GetSection("JwtSettings");
var key = Encoding.UTF8.GetBytes(jwtSetting["Key"] ?? throw new InvalidOperationException("Jwt key is missing"));

if (key.Length < 32)
{
    throw new InvalidOperationException("Key must be 32 character");
}

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSetting["Issuer"],
            ValidAudience = jwtSetting["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)

        };

        option.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var token = context.Request.Cookies["token"];
                if (!string.IsNullOrEmpty(token))
                {
                    context.Token = token;
                }
                return Task.CompletedTask;
            }
        };
    }
        
    );

builder.Services.AddAuthorization();
builder.Services.AddSwaggerGen(ops =>
{
    ops.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My Api",
        Version = "v1",
        Description = "API authentication with Jwt"
    });
    ops.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Input token"
    });

    ops.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"

                }
            },
             new string[]{}
        }
    });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins("http://127.0.0.1:5505") // domain FE
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();

        policy.WithOrigins("http://127.0.0.1:5505") 
              .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});


var app = builder.Build();
//app.UseCors("AllowAll")
app.UseCors("AllowFrontend");
// DI Exception
app.UseMiddleware<ExceptionMiddleware>();
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
        var exception = exceptionHandlerPathFeature?.Error;

        // Ghi log chi ti?t:
        //logger.LogError();

        var result = JsonSerializer.Serialize(new
        {
            StatusCode = 500,
            Message = exception?.Message,
            Detail = exception?.InnerException?.Message,
            Exception = exception?.StackTrace?.Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
        });

        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(result);
    });
});
// Configure the HTTP request pipeline.
app.Use(async (context, next) =>
{
    if (context.Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase)
        && context.Request.Headers.TryGetValue("X-HTTP-Method-Override", out var overrideMethod))
    {
        var newMethod = overrideMethod.ToString().ToUpperInvariant();
        if (newMethod == "PUT")
        {
            context.Request.Method = newMethod;
        }
    }

    await next();
});
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
