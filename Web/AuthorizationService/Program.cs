using AuthorizationService.Data;
using AuthorizationService.Data.Entities;
using AuthorizationService.Data.Repositories;
using AuthorizationService.Models;
using AuthorizationService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

 //string _loginOrigin = "_localorigin";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.Configure<JWTConfig>(builder.Configuration.GetSection("JWTConfig"));
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.User.RequireUniqueEmail = true;
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    var cnfgKey = builder.Configuration.GetSection("JWTConfig:Key").Value;
    var cnfgIssuer = builder.Configuration.GetSection("JWTConfig:Issuer").Value;
    var cnfgAudience= builder.Configuration.GetSection("JWTConfig:Audience").Value;
    var key = Encoding.ASCII.GetBytes(cnfgKey);
   // var issuer = Encoding.ASCII.GetBytes(cnfgIssuer).ToString();
   // var audience = Encoding.ASCII.GetBytes(cnfgAudience).ToString();
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        SaveSigninToken = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = false,
        RequireExpirationTime = true,
        ValidIssuer = cnfgIssuer,
        ValidAudience = cnfgAudience,
    };
});
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
var app = builder.Build();
//core policty deiþ
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
