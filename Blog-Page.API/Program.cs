using Microsoft.EntityFrameworkCore;
using Blog_Page.API.Persistance.Repositories;
using Blog_Page.API.Infrastructure.Tools.JwtTokenDefaults;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Blog_Page.Persistance.Context;
using Blog_Page.Infrastructure.Middleware;
using AutoMapper;
using Blog_Page.Service.Mappings.AutoMappers;
using Blog_Page.Service.Helpers;
using Blog_Page.Service.Interfaces;
using Blog_Page.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = builder.Configuration;

//builder.Services.AddDbContext<BlogContext>(opt =>
//{
//    opt.UseSqlServer("Server=.\\SQLEXPRESS;Database=BlogDb;Trusted_Connection=True;TrustServerCertificate=True");
//});


builder.Services.AddDbContext<BlogDbContext>(opt =>
{
    opt.UseSqlServer("Server=.\\SQLEXPRESS;Database=blogdb;Trusted_Connection=True;TrustServerCertificate=True");
});
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();




builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

//RegisterService Middleware
//ServiceMiddleware.RegisterServices();

//Database Migrate Middleware 
//DatabaseMigrator.Migrate();

//AutoMapper Configuration
var profiles = ProfileHelper.GetProfiles();
var mapConfiguration = new MapperConfiguration(opt =>
{
    opt.AddProfiles(profiles);
});
var mapper = mapConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidAudience = JwtTokenDefaults.ValidAudience,
        ValidIssuer = JwtTokenDefaults.ValidIssuer,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
