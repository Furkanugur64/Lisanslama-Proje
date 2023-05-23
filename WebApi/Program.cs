using WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FluentValidation.AspNetCore;
using FluentValidation;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using WebApi.Models.DTO;
using WebApi.Abstract;
using WebApi.Concrete;

var builder = WebApplication.CreateBuilder(args);






builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "https://localhost:7168",
                ValidAudience = "https://localhost:7168",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("64A63153-11C1-4919-9133-EFAF99A9B456"))
            };
        });
builder.Services.AddAuthorization();

builder.Services.AddControllers()
    .AddFluentValidation(fv => {
        fv.RegisterValidatorsFromAssemblyContaining<AdminValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<LisansDTOValidator>();
    });

builder.Services.AddScoped<IAdminService, AdminManager>();
builder.Services.AddScoped<ILisansService, LisansManager>();


// Validasyon için eklediklerim
//builder.Services.AddControllers().AddFluentValidation(options =>
//{
//    options.ImplicitlyValidateChildProperties = true;
//    options.ImplicitlyValidateRootCollectionElements = true;
//    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
//}).AddFluentValidation();


//builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

//builder.Services.AddFluentValidationAutoValidation();
//builder.Services.AddScoped<IValidator<Admin>, AdminValidator>();
//builder.Services.AddScoped<IValidator<Lisans>, LisansValidator>();

//builder.Services.AddValidatorsFromAssemblyContaining<AdminValidator>();
//builder.Services.AddValidatorsFromAssemblyContaining<LisansValidator>();

// validasyon son

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Eklediklerim
builder.Services.AddDbContext<Context>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHttpContextAccessor();




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

app.Run();
