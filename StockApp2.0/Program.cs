using Microsoft.EntityFrameworkCore;
using StockApp2._0.Context;
using StockApp2._0.Repositories.Interfaces;
using StockApp2._0.Repositories;
using StockApp2._0.Services.Interfaces;
using StockApp2._0.Services;
using System.Text.Json.Serialization;
using StockApp2._0.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(opts =>
    {
        opts.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddDbContext<StockAppContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
        .EnableSensitiveDataLogging()
        .LogTo(Console.WriteLine, LogLevel.Information);
});

//Product
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

//Category 
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

//Inventory
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();

//Batch
builder.Services.AddScoped<IBatchRepository, BatchRepository>();
builder.Services.AddScoped<IBatchService, BatchService>();

builder.Services.AddScoped<EntryBatchProcessingStrategy>();
builder.Services.AddScoped<ExitBatchProcessingStrategy>();
builder.Services.AddSingleton<IBatchFactory, BatchFactory>();
builder.Services.AddScoped<BatchProcessingStrategyFactory>();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

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
