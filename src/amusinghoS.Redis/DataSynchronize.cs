using amusinghoS.EntityData.Model;
using amusinghoS.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace amusinghoS.Redis
{
    //Redis and database data consistency synchronization dispatched by Hangfire
    public class DataSynchronize
    {

        public static IRedisClient _redisclient;
        public static UnitOfWork _unitOfWork;
        public DataSynchronize(IRedisClient redisClient,UnitOfWork unitOfWork)
        {
            _redisclient = redisClient ?? throw new ArgumentNullException(nameof(redisClient));

            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public static async Task SynchronizeAsync()
        {
            try
            {
                var list = await RedisHelper.LRangeAsync<Comment>("newcomment", 0, -1);
                //入库操作
                foreach (var item in list)
                {
                    await _unitOfWork.amusingArticleCommentRepository.InsertAsync(new amusingArticleComment()
                    {
                        amusingArticleId = item.articleId,
                        content = item.content,
                        commentatorName = item.name,
                        weburl = item.httpurl,
                        eamil = item.email
                    }, isSaveChange: true);
                }
                await RedisHelper.DelAsync("newcomment");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    public class Comment
    {
        public string email { get; set; }
        public string name { get; set; }
        public string httpurl { get; set; }
        public string content { get; set; }
        public string articleId { get; set; }
    }
}
