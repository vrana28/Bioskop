using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Bioskop.WebApp.Middlewares
{
    public class CheckIfUserIsLoggedInMiddleware
    {
        private readonly RequestDelegate _next;

        public CheckIfUserIsLoggedInMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            int? id = httpContext.Session.GetInt32("userid");
            if (id == null && httpContext.Request.Path!="/Korisnik/Login") {
                httpContext.Response.Redirect("/Korisnik/Login");
            }
            return _next(httpContext);
        }
    }

    public static class CheckIfUserIsLoggedInMiddlewareExtensions
    {
        public static IApplicationBuilder UseCheckIfUserIsLoggedInMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CheckIfUserIsLoggedInMiddleware>();
        }
    }
}
