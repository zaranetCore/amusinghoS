using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amusinghoS.App.Extensions
{
    public static class CustomErrorPagesExtensions
    {
        public static IApplicationBuilder UseCustomErrorPages(this IApplicationBuilder app)
        {
            //为了防止MVC内部错误 在这里我们要做这样的操作
            app.UseExceptionHandler("/Errors/500");
            app.UseStatusCodePagesWithReExecute("/Errors/{0}");
            return app;
        }
    }
}
