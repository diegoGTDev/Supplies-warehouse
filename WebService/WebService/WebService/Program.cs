using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;
using WebService.Data;
using WebService.Models.Common;
using WebService.Services;

var builder = WebApplication.CreateBuilder(args);
var MiCors = "MiCors";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<iItemService, ItemService>();
builder.Services.AddScoped<iUserService, UserService>();
builder.Services.AddScoped<iRequirementService, RequirementService>();
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppConfiguration>(appSettingsSection);
var appSettings = appSettingsSection.Get<AppConfiguration>();
var uKey = Encoding.ASCII.GetBytes(appSettings.SecretKey);
builder.Services.AddDbContext<db_warehouseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("db_context"));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MiCors,
        policy =>
        {
            policy.WithHeaders("*");
            policy.WithMethods("*");
            policy.WithOrigins("*");
        });
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowAnyHeader();
    });
});
//Indicamos que usaremos autenticacion y autorizacion con JWT
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
{
    //options.RequireHttpsMetadata = false;
   //options.SaveToken = true;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = appSettings.Issuer,
        ValidAudience = appSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(uKey),
    };
});
var app = builder.Build();


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
app.UseCors("AllowAll");
app.Run();
