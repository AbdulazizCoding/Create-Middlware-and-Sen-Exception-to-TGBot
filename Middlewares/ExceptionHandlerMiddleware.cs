using Middlware.Models;

namespace Middlware.Middlwares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly TelegramData _botConfig;

    public ExceptionHandlerMiddleware(RequestDelegate next, TelegramData botConfig)
    {
        _next = next;
        _botConfig = botConfig;
    } 

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception e)
        {
            using var client = new HttpClient();
            var result = await client.GetAsync($"https://api.telegram.org/bot{_botConfig.BotToken}/sendmessage?chat_id={_botConfig.UserId}&text={e}");

            Console.WriteLine($"{result.StatusCode}");
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(new{ Error = e.Message });
        }
    }
}