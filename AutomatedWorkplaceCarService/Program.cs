using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using AutomatedWorkplaceCarService.WEB.ViewModels;
using FluentValidation;
using AutomatedWorkplaceCarService.WEB.Infrastructure.Validators;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.BLL.Services;
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

builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ITransmissionService, TransmissionService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IStageService, StageService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<ClientViewModel>, ClientModelValidator>();
builder.Services.AddScoped<IValidator<AuthenticationViewModel>, AuthenticationModelValidator>();
builder.Services.AddScoped<IValidator<CreateCarDTO>, CarValidator>();
builder.Services.AddScoped<IValidator<EmployeeViewModel>, EmployeeModelValidator>();
builder.Services.AddScoped<IValidator<CreateApplicationViewModel>, CreateApplicationModelValidator>();
builder.Services.AddScoped<IValidator<EvaluationApplicationViewModel>, EvaluationApplicatonModelValidator>();
builder.Services.AddScoped<IValidator<CompleteApplicationViewModel>, CompleteApplicationModelValidator>();

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
