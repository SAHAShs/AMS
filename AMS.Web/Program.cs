using AMS.Application.Repository.Assets;
using AMS.Application.Repository.Category;
using AMS.Application.Repository.Employees;
using AMS.Application.Service.Assets;
using AMS.Application.Service.Category;
using AMS.Application.Service.Employees;
using AMS.Application.Shared;
using AMS.Infrastructure.Context;
using AMS.Infrastructure.Repository;
using AMS.Web.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContext<AMSDbContext>(options =>
  {  options.UseSqlServer(builder.Configuration.GetConnectionString("connectionstring"));
options.EnableSensitiveDataLogging(); // <-- Add this
});

builder.Services.AddScoped<IAssetRepository, AssetRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddScoped<IAssetService, AssetService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddAutoMapper(typeof(AssetProfile));


builder.Services.AddServerSideBlazor()
    .AddCircuitOptions(options => { options.DetailedErrors = true; });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
