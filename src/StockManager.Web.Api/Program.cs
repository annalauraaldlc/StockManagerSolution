
using Microsoft.EntityFrameworkCore;
using StockManager.AdministrationContext;
using StockManager.AdministrationContext.Domain.ProductAggregate;
using StockManager.AdministrationContext.Infra.Data;
using StockManager.AdministrationContext.Infra.Repositories.ProductAggregate;
using StockManager.Infra.Multitenancy;
using StockManager.Web.Api.Multitenancy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMultitenancy<Tenant, TenantResolver>();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(AdministrationContextModule).Assembly);
builder.Services.AddDbContext<AdministrationDbContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMultitenancy<Tenant>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
