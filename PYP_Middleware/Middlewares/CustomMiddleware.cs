namespace PYP_Middleware.Middlewares;

public class CustomMiddleware
{
    private readonly IConfiguration _configuration;
    private readonly RequestDelegate _next;

    public CustomMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task Invoke(HttpContext context)
    {
        //1.//_configuration.GetSection("CompanyInfo").GetChildren().ToList().ForEach(x =>
        //{
        //    context.Response.Headers.Add(x.Key, x.Value);
        //});
        //await _next.Invoke(context);
       //2.
        var dict = _configuration.GetSection("CompanyInfo").GetChildren().ToDictionary(x => x.Key, x => x.Value);

        foreach (var key in dict)
        {
            context.Response.Headers.Add(key.Key, key.Value);
        }
        await _next.Invoke(context);

    }
}
