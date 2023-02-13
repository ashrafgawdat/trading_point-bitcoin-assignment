using AutoMapper;
using BitcoinTicker.Application.BitcoinTicks;
using BitcoinTicker.Application.Shared.BitcoinTicks;
using BitcoinTicker.Application.Shared.BitcoinTicks.Dto;
using BitcoinTicker.EntityFrameworkCore.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddScoped<IBitcoinPriceFactory, BitcoinPriceFactory>()
                .AddScoped<IBitcoinPriceBitstampProvider, BitstampBitcoinPriceProvider>()
                .AddScoped<IBitcoinPriceBitfinexProvider, BitfinexBitcoinPriceProvider>()
                .AddScoped<IBitcoinPriceService, BitcoinPriceService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
