using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amusinghoS.Services;
using Microsoft.AspNetCore.Mvc;
using amusinghoS.EntityData.Model;
using amusinghoS.App.Models;

namespace amusinghoS.App.Controllers
{
    public class MarkDownController : Controller
    {
        UnitOfWork _unitWork;
        public MarkDownController(UnitOfWork unitOfWork)
        {
            _unitWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("/markdown/updateorcreate")]
        public async Task<IActionResult> UpdateOrCreate([FromBody]md_CreateUpdate md_Create)
        {
            var model = new amusingArticle()
            {
                Title = md_Create.title,
                Image = null,
                Description = md_Create.details
            };
            if (_unitWork.amusingArticleRepository.Any(u=>u.articleId == md_Create.aticleId))//修改
            {
                await _unitWork.amusingArticleRepository.UpdateAsync(model,true);
            }
            else//添加
            {
                await _unitWork.amusingArticleRepository.InsertAsync(model,true);
            }
            return View();
        }
    }
}
