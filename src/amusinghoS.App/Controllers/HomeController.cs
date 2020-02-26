using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using amusinghoS.EntityData.Model;
using amusinghoS.EntityData;
using System.Linq;
using amusinghoS.Services;
using amusinghoS.App;
using System.Threading.Tasks;

namespace amusinghoS.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork _unitWork;
        public HomeController(UnitOfWork unitOfWork)
        {
            _unitWork = unitOfWork;
        }
        public IActionResult Index()
        {
            throw new System.Exception("asd");

            //默认 8个文章
            var list = _unitWork.amusingArticleRepository.GetAll();
            ViewData["Current"] = 1;

            ViewData["NextIsNull"] = "NO";

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
    }
}
