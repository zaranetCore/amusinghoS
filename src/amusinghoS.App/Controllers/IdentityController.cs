using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace amusinghoS.App.Controllers
{
    public class IdentityController : Controller
    {
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return new JsonResult(from c in HttpContext.User.Claims select new { c.Type, c.Value });
        }
    }
}