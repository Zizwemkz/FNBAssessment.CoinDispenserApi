using FNBAssessment.CoinDispenserApi.Repository;
using FNBAssessment.CoinDispenserApi.Service;
using FNBAssessment.CoinDispenserApi.Common.Interface;
using FNBAssessment.CoinDispenserApi.Data.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CoinDispenserContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICoinDispenserRepository, CoinDispenserRepository>();
builder.Services.AddScoped<ICoinDispenserService, CoinDispenserService>();


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
