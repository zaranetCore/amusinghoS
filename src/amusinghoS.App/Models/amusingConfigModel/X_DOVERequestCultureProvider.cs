using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amusinghoS.App.Models.amusingConfigModel
{
    public class X_DOVERequestCultureProvider : RequestCultureProvider
    {
        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            var CULTURE_String = "CULTURE";
            var CultureCookie = httpContext.Request.Cookies[CULTURE_String]?.ToString() ?? "";
            if (string.IsNullOrWhiteSpace(CultureCookie))
            {
                CultureCookie = "zh-CN";
                httpContext.Response.Cookies.Append(key: CULTURE_String, value: CultureCookie, options: new CookieOptions() { Expires = DateTime.Now.AddYears(1) });
            }
            return Task.FromResult(new ProviderCultureResult(CultureCookie));
        }
    }
}
