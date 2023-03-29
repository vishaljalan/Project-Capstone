using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Serilog;
using System.Threading.Tasks;

namespace SerilogLib
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SerilogMiddleware: IMiddleware
    {
        private readonly RequestDelegate _next;

        public SerilogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }


        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Log the HTTP request
            Log.Information("Request {Method} {Path} received", context.Request.Method, context.Request.Path);

            // Call the next middleware in the pipeline
            await next(context);

            // Log the HTTP response
            Log.Information("Response {StatusCode} sent for {Method} {Path}", context.Response.StatusCode, context.Request.Method, context.Request.Path);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SerilogMiddlewareExtensions
    {
        public static IApplicationBuilder UseSerilogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SerilogMiddleware>();
        }
    }
}
