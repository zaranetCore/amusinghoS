using Microsoft.AspNetCore.Mvc;

namespace amusinghoS.App.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("errors/{statusCode}")]
        public IActionResult CustomError(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("~/Views/Errors/404.cshtml");
            }
            return View("~/Views/Errors/500.cshtml");
        }
    }
}
