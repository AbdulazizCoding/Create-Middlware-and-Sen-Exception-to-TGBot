using Middlware.Middlwares;
using Middlware.Models;

var builder = WebApplication.CreateBuilder(args);

var botConfig = builder.Configuration
    .GetSection("TelegramData")
    .Get<TelegramData>();

builder.Services.AddSingleton(botConfig);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseMiddleware<LanguageMiddleware>();
app.MapControllers();

app.Run();
