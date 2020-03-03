using amusinghoS.EntityData;
using amusinghoS.EntityData.Model;
using amusinghoS.Services.Base;

namespace amusinghoS.Services.Table
{
    public class amusingArticleRepository : RepositoryBase<amusingArticle>
    {
        public amusingArticleRepository(amusinghoSDbContext context) : base(context)
        {

        }
    }
}
