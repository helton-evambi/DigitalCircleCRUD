using DigitalCircle.Backend.DigitalCircle.CrossCutting.Extensions;
using DigitalCircle.Backend.DigitalCircle.CrossCutting.IoC;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDepencyInjection(builder.Configuration);
builder.AddApiSwagger();

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


var app = builder.Build();

// Configure the HTTP request pipeline.
var enviroment = app.Environment;

app.UseExceptionHandling(enviroment)
    .UseSwaggerMiddleware()
    .UseAppCors();

app.UseHttpsRedirection();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
