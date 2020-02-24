using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using amusinghoS.EntityData.Model;
using amusinghoS.EntityData;
using System.Linq;
using amusinghoS.Services;
using amusinghoS.App;

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
            var list = _unitWork.amusingArticleRepository.GetAll().Take(8).ToList();
            return View(list);
        }
        [Route("/Index/{id}")]
        public IActionResult Index(int id)
        {
            ViewData["page"] = id;
            return View();
        }
    }
}
