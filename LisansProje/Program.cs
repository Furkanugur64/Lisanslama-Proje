using FluentValidation;
using FluentValidation.AspNetCore;
using LisansProje.Models;
using LisansProje.ValidationRules;
using Microsoft.Extensions.DependencyInjection;
using LisansProje.Abstract;
using System;
using System.Reflection;
using LisansProje.Concrete;
using LisansProje.Models.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllersWithViews();

builder.Services.AddControllers()
    .AddFluentValidation(fv => {
        fv.RegisterValidatorsFromAssemblyContaining<LisansValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<AdminValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<KurumValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<AdminEkleValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<FirmaValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<UrunValidator>();
    });


//Servisleri dahil ettik
// 3 farklý türü var --> Singleton,Scoped,Transient

builder.Services.AddScoped<ILisansService, LisansManager>();
builder.Services.AddScoped<ILoginService, LoginManager>();
builder.Services.AddScoped<IKurumService, KurumManager>();
builder.Services.AddScoped<IFirmaService, FirmaManager>();
builder.Services.AddScoped<IUrunService, UrunManager>();



//Session için eklenen
builder.Services.AddHttpContextAccessor(); 

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddApplicationInsightsTelemetry();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();



app.UseAuthorization();

//session
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=GirisYap}/{id?}");

app.Run();
