using Microsoft.EntityFrameworkCore;
using DictionaryService.Data.Entities;
using DictionaryService.Models.DTO;
using DictionaryService.Data.Repositories;
using DictionaryService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<AppDbContext>(opt =>
//{
//    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
//});builder.Configuration.GetConnectionString("DefaultConnection")
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton(builder.Configuration.GetConnectionString("DefaultConnection"));

var app = builder.Build();

app.UseCors(x => x
     .WithOrigins("http://localhost:4200")
     .AllowAnyMethod()
     .AllowAnyHeader());


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
