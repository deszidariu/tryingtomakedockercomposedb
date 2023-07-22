using Microsoft.EntityFrameworkCore;
using PriceAggregator.Api.Data;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddDbContext<PriceAggregatorApiContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("PriceAggregator") ?? throw new InvalidOperationException("Connection string 'PriceAggregator' not found.")));

// Add services to the container.

builder.Services.AddControllers();

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
