using BusinessBackendApi.Infra;
using BusinessBackendApi.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//EntityFrameWork
builder.Services.AddSingleton<DbContextOptions<AppDbContext>>();
builder.Services.AddSingleton<AppDbContext>();

//Repository
builder.Services.AddSingleton<RestaurantRepository>();
builder.Services.AddSingleton<ProductRepository>();

//Service
builder.Services.AddSingleton<RestaurantService>();
builder.Services.AddSingleton<ProductService>();




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

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
