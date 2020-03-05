using amusinghoS.EntityData;
using amusinghoS.EntityData.Model;
using amusinghoS.Services.Base;

namespace amusinghoS.Services.Table
{
    public class amusingArticleCommentRepository : RepositoryBase<amusingArticleComment>
    {
        public amusingArticleCommentRepository(amusinghoSDbContext context) : base(context)
        {

        }
    }
}
