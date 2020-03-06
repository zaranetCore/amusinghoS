using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amusinghoS.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace amusinghoS.App.Controllers
{
    public class ArticleController : Controller
    {
        UnitOfWork _unitWork;
        public ArticleController(UnitOfWork unitOfWork)
        {
            _unitWork = unitOfWork;
        }
        [Route("/Article/{articleid}")]
        public IActionResult Index(string articleid)
        {
            var amusingArticleList = _unitWork.amusingArticleRepository.GetAll();
            var commentList = from article in amusingArticleList
                              join comment in _unitWork.amusingArticleCommentRepository.GetAll()
                              on article.articleId equals comment.amusingArticleId
                              where article.articleId == articleid
                              orderby comment.CreateTime
                              select new
                              {
                                  comment.content,
                                  comment.commentatorName
                              };
            var model = (from details in _unitWork.amusingArticleDeatilsRepository.GetAll()
                         join article in _unitWork.amusingArticleRepository.GetAll()
                         on details.amusingArticleId equals article.articleId
                         where articleid == details.amusingArticleId
                         select new { details.Html, article.Title, article.CreateTime }).FirstOrDefault();
            //ViewData["model"] = 
            return View();
        }
    }
}
