using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using TestSpiAspCoreMiddleWare;

namespace Microsoft.AspNetCore.Builder
{
    public class WinOrLooseMiddleware
    {
        private readonly RequestDelegate _next;

        public WinOrLooseMiddleware(RequestDelegate next, IOptions<LooseOrWinOptions> options )
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (Environment.TickCount % 2 == 0)
            {
                await httpContext.Response.WriteAsync("LOOSE!");
            }
            else
            {
                await httpContext.Response.WriteAsync("OK, you win =>!");
                await _next(httpContext);
            }
        }
    }

    public static class WinOrLooseMiddlewareExtensions
    {
        public static IApplicationBuilder UseLooseOrWinService(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<WinOrLooseMiddleware>();
        }
    }
    //public class WinOrLooseMiddlewareExtensions
    //{
    //    private static WinOrLooseMiddlewareExtensions instance;

    //    private WinOrLooseMiddlewareExtensions() { }

    //    public static WinOrLooseMiddlewareExtensions Instance {
    //        get {
    //            if (instance == null)
    //            {
    //                instance = new WinOrLooseMiddlewareExtensions();
    //            }
    //            return instance;
    //        }
    //    }
    //}
}
