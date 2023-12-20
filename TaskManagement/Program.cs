using Application;
using Application.Helper;
using Application.Interfaces;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using TaskManagement;
using TaskManagement.Helper;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddApplicationLayer();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
{
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
}
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthorization();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<JwtMiddleware>();

app.Run();
