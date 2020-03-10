using amusinghoS.EntityData;
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
        public DataSynchronize(IRedisClient redisClient)
        {
            _redisclient = redisClient ?? throw new ArgumentNullException(nameof(redisClient));
        }
        public static async Task SynchronizeAsync()
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new amusinghoSDbContext()))
                {
                    var list = await RedisHelper.LRangeAsync<Comment>("newcomment", 0, -1);

                    //入库操作
                    foreach (var item in list)
                    {
                        var model = new amusingArticleComment()
                        {
                            amusingArticleId = item.articleId,
                            content = item.content,
                            commentatorName = item.name,
                            weburl = item.httpurl,
                            eamil = item.email
                        };
                        await unitOfWork.amusingArticleCommentRepository.InsertAsync(model, isSaveChange: true);
                    }
                    await RedisHelper.DelAsync("newcomment");
                }
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
