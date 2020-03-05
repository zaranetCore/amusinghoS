using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amusinghoS.Services;
using Microsoft.AspNetCore.Mvc;
using amusinghoS.EntityData.Model;
using amusinghoS.App.Models;
using amusinghoS.Shared;

namespace amusinghoS.App.Controllers
{
    public class MarkDownController : Controller
    {
        UnitOfWork _unitWork;
        public MarkDownController(UnitOfWork unitOfWork)
        {
            _unitWork = unitOfWork;
        }
        [Route("/markdown")]
        [Route("/markdown/{isUpdate}")]
        public IActionResult Index(string isUpdate)
        {
            if (string.IsNullOrWhiteSpace(isUpdate))
            {
                ViewData["page_Obj"] = new amusingArticle() {  articleId = Guid.NewGuid().ToString()};
                ViewData["page_Html"] = "";
            }
            else
            {
                var obj = _unitWork.amusingArticleRepository.Get(u => u.articleId == isUpdate);
                string html = "";
                if (obj != null)
                {
                    html = _unitWork.amusingArticleDeatilsRepository.Get(u => u.amusingArticleId == obj.articleId).Html;
                }
                if (obj != null)//修改
                {
                    ViewData["page_Obj"] = obj;
                    ViewData["page_Html"] = html;
                }
                else
                {
                    //如果没有 则url是瞎x乱写的 那这里就直接让他Create
                    return RedirectToAction("Index", "/markdown");
                }
            }
            return View();
        }
        [HttpPost]
        [Route("/markdown/updateorcreate")]
        public async Task<IActionResult> UpdateOrCreate([FromBody]md_CreateUpdate md_Create)
        {
            var strarray = HtmlHelper.GetHtmlImageUrlList(md_Create.markdown_unicode);
            var model = new amusingArticle()
            {
                Title = md_Create.title,
                Image = strarray.Length == 0 ? null : strarray[0],
                Description = md_Create.details,
                articleId = md_Create.aticleId
            };
            if (_unitWork.amusingArticleRepository.Any(u => u.articleId == md_Create.aticleId))//修改
            {
                //查询amusingArticleDetails 索引Keys
                var amusingArticleDetails_Key = _unitWork.amusingArticleDeatilsRepository
                                                                            .Get(u => u.amusingArticleId == model.articleId)
                                                                                .articleDetailsId;
                _unitWork.amusingArticleRepository.Update(model); //修改文章表

                //修改文章明细表
                _unitWork.amusingArticleDeatilsRepository.Update(new amusingArticleDetails()
                {
                    Html = md_Create.htmlContent,
                    articleDetailsId = amusingArticleDetails_Key
                });
            }
            else//添加
            {
                await _unitWork.amusingArticleRepository.InsertAsync(model, false);//添加文章表
                                                                                   //添加文章明细表
                bool isok = _unitWork.amusingArticleDeatilsRepository.Insert(new amusingArticleDetails()
                {
                    Html = md_Create.htmlContent,
                    LastUpdate = DateTime.Now,
                    articleDetailsId = Guid.NewGuid().ToString(),
                    amusingArticleId = model.articleId
                }, true);
            }
            return Ok(new { code = 200, msg = "保存成功！" });
        }
    }
}
