using PYP_Middleware.Middlewares;

namespace PYP_Middleware.Extentions;

public static class ApplicationExtentions
{
    public static IApplicationBuilder UseContent(this IApplicationBuilder app)
    {
       return app.UseMiddleware<CustomMiddleware>();
        
    }
}
