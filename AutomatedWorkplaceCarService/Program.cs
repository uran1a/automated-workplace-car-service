using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using AutomatedWorkplaceCarService.WEB.Models;
using FluentValidation;
using AutomatedWorkplaceCarService.WEB.Infrastructure.Validators;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.BLL.Services;
using AutomatedWorkplaceCarService.DAL.Interfaces;
using AutomatedWorkplaceCarService.DAL.Repositories;
using AutomatedWorkplaceCarService.DAL.EF;
using FluentValidation.AspNetCore;
using AutomatedWorkplaceCarService.WEB.Infrastructure.Mapping;
using AutomatedWorkplaceCarService.BLL.DTOs.Car;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("appsettings.json");
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
{
    options.UseNpgsql(connection);
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();
builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork>();
builder.Services.AddScoped<IAuthentificationService, AuthentificationService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ITransmissionService, TransmissionService>();
builder.Services.AddScoped<IImageService, ImageService>();
/*services.AddTransient<IUnitOfWork, EFUnitOfWork>();*/
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//typeof(UserMappingProfile), typeof(ClientMappingProfile), typeof(EmployeeMappingProfile), typeof(PostMappingProfile)
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<ClientModel>, ClientModelValidator>();
builder.Services.AddScoped<IValidator<AuthenticationModel>, AuthenticationModelValidator>();
builder.Services.AddScoped<IValidator<CreateCarDTO>, CarValidator>();
builder.Services.AddScoped<IValidator<EmployeeModel>, EmployeeModelValidator>();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapRazorPages();

app.Run();
