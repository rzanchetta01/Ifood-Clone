using IfoodCoreApi.Infra.Context;
using IfoodCoreApi.Infra.Repository.Business;
using IfoodCoreApi.Services.BusinessService;
using IfoodCoreApi.Services.BusinessService.RestaurantService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//EntityFramework
builder.Services.AddSingleton<DbContextOptions<AppDbContext>>();
builder.Services.AddSingleton<AppDbContext>();

//Repository's
builder.Services.AddSingleton<RestaurantRepository>();
builder.Services.AddSingleton<BusinessCategoryRepository>();

//Service's
builder.Services.AddSingleton<RestaurantService>();
builder.Services.AddSingleton<BusinessCategoryService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction() || app.Environment.IsStaging())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IfoodCoreApi v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
