
using eshop.Application.Services;
using eshop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductService, FakeProductService>();
builder.Services.AddScoped<ICategoryService, FakeCategoryService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddSession();

var connectionStrings = builder.Configuration.GetConnectionString("db");
builder.Services.AddDbContext<AkbankDbContext>(option => option.UseSqlServer(connectionStrings));
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
