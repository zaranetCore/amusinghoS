using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amusinghoS.App.Dto;
using amusinghoS.Services;
using Microsoft.AspNetCore.Mvc;
using amusinghoS.Shared;
using amusinghoS.Redis;
using AutoMapper;
using amusinghoS.EntityData.Model;

namespace amusinghoS.App.Controllers
{
    public class ArticleController : Controller
    {
        UnitOfWork _unitWork;
        private readonly IRedisClient _redisclient;
        private readonly IMapper _mapper;
        public ArticleController(UnitOfWork unitOfWork,IRedisClient redisClient,IMapper mapper)
        {
            _unitWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _redisclient = redisClient ?? throw new ArgumentNullException(nameof(redisClient));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [Route("/Article/{articleid}")]
        public async Task<IActionResult> IndexAsync(string articleid)
        {
            var amusingArticleList = _unitWork.amusingArticleRepository.GetAll();


            //comment from database or redis 
            var redis_comment = await RedisHelper.LRangeAsync<Comment>("newcomment", 0, -1);

            var commentList = from article in amusingArticleList
                              join comment in _unitWork.amusingArticleCommentRepository.GetAll()
                              on article.articleId equals comment.amusingArticleId
                              where article.articleId == articleid
                              orderby comment.CreateTime
                              select new
                              {
                                  comment.content,
                                  comment.commentatorName,
                                  comment.eamil,
                                  comment.weburl
                              };
            List<amusingArticleComment> list = new List<amusingArticleComment>();

            foreach (var item in redis_comment)
            {
                var result = _mapper.Map<amusingArticleComment>(item);
                list.Add(result);
            }

            var model = (from details in _unitWork.amusingArticleDeatilsRepository.GetAll()
                         join article in _unitWork.amusingArticleRepository.GetAll()
                         on details.amusingArticleId equals article.articleId
                         where articleid == details.amusingArticleId
                         select new ArticleViewModel()
                         {
                             html = details.Html,
                             formatdetatime = article.CreateTime.ToString() +
                             DatetimeHelper.GetPeriod(article.CreateTime),
                             title = article.Title
                         }).FirstOrDefault();

            ViewData["ViewBinding"] = model;
            ViewData["articleid"] = articleid;
            return View();
        }

        [HttpPost]
        [Route("/Article/Add")]
        public async Task<IActionResult> AddComment([FromForm]Comment commentVm)
        {
            try
            {
                await _redisclient.RPushAsync("newcomment", commentVm, 3000);
                return Ok(new { resultCode = 200, msg = "保存成功！" });
            }
            catch
            {
                throw new ApplicationException("redis sever error..");
            }
        }
    }
}
