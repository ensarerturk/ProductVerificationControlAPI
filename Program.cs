using System.Reflection;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProductManage.DBOperations;
using ProductManage.ProductOperations.CreateProduct;
using ProductManage.ProductOperations.DeleteProduct;
using ProductManage.ProductOperations.UpdateProduct;
using ProductManage.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductServices, ProductServices>();

builder.Services.AddDbContext<ProductDbContext>(options => options.UseInMemoryDatabase(databaseName: "ProductDB"));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddTransient<IValidator<CreateProductModel>, CreateProductCommandValidator>();
builder.Services.AddTransient<IValidator<DeleteProductCommand>, DeleteProductCommandValidator>();
builder.Services.AddTransient<IValidator<UpdateProductCommand>, UpdateProductCommandValidator>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataGenerator.Initialize(services);
}

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