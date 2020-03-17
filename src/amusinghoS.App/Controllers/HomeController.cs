using Microsoft.AspNetCore.Mvc;
using System.Linq;
using amusinghoS.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace amusinghoS.Controllers
{
    [Authorize()]
    public class HomeController : Controller
    {
        UnitOfWork _unitWork;
        public HomeController(UnitOfWork unitOfWork)
        {
            _unitWork = unitOfWork;

        }
        public async Task<IActionResult> Index()
        {
            //默认 8个文章
            var list = _unitWork.amusingArticleRepository.GetAll();
            ViewData["Current"] = 1;
            ViewData["NextIsNull"] = "NO";

            var accessToken  = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            var idToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);

            var refreshToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);
            var authorzationCode = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.Code);

            return View(list.Take(3).ToList());
        }
        [Route("/Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var list = await _unitWork.amusingArticleRepository
                .GetListAsync() ;

            ViewData["NextIsNull"] = "NO";

            if ((list.Count / 3) + 1 == id)
            {
                ViewData["NextIsNull"] = "OK";
            }
            ViewData["Current"] = id;
            list = list.Skip((id - 1) * 3)
                .Take(3).ToList();
            if (list.Count == 0)
                ViewData["NextIsNull"] = "OK";

            return View(list);
        }

        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }
    }
}
