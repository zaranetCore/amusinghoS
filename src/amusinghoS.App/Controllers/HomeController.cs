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
            //默认 8个文章
            var list = _unitWork.amusingArticleRepository.GetAll().Take(3).ToList();
            ViewData["ArticleCount"] = list.Count;
            return View(list);
        }
        [Route("/Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var list = await _unitWork.amusingArticleRepository
                .GetListAsync() ;
            ViewData["ArticleCount"] = list.Count;
            return View(list.Skip((id - 1) * 3)
                .Take(3).ToList());
        }
    }
}
