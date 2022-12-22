
using StockManager.Infra.Multitenancy;
using StockManager.Web.Api.Multitenancy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMultitenancy<Tenant, TenantResolver>();

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

app.UseMultitenancy<Tenant>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
