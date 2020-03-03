using amusinghoS.EntityData;
using amusinghoS.EntityData.Model;
using amusinghoS.Services.Base;

namespace amusinghoS.Services.Table
{
    public class amusingArticleDetailsRepository : RepositoryBase<amusingArticleDetails>
    {
        public amusingArticleDetailsRepository(amusinghoSDbContext context) : base(context)
        {

        }
    }
}
