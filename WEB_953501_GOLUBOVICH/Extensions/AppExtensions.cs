using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953501_GOLUBOVICH.Middleware;

namespace WEB_953501_GOLUBOVICH.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder UseFileLogging(this IApplicationBuilder app) =>
            app.UseMiddleware<LogMiddleware>();
    }
}
