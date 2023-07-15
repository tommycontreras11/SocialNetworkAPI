global using Microsoft.EntityFrameworkCore;
global using SocialNetworkAPI.Models;
global using SocialNetworkAPI.Enums;
global using SocialNetworkAPI.Dtos.UserDto;
global using SocialNetworkAPI.Dtos.PostDto;
global using SocialNetworkAPI.Dtos.CommentDto;
global using SocialNetworkAPI.Data;
global using SocialNetworkAPI.Services.UserService;
global using SocialNetworkAPI.Services.PostService;
global using SocialNetworkAPI.Services.CommentService;
global using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

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
