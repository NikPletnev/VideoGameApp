using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using VideoGameApp.API.Configs;
using VideoGameApp.API.Extensions;
using VideoGameApp.API.Infrastructure;
using VideoGameApp.BLL.Configs;
using VideoGameApp.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.RegisterVideoGameAppServices();
builder.Services.RegisterVideoGameAppRepositories();
builder.Services.AddConnectionString();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(DataMapper).Assembly, typeof(BusinessMapper).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<GlobalExeptionHandler>();
app.MapControllers();

app.Run();

