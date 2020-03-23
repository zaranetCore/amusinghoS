using amusinghoS.EntityData;
using amusinghoS.EntityData.Model;
using amusinghoS.Services.Base;

namespace amusinghoS.Services.Table
{
    public class amusingArticleUserRepository : RepositoryBase<amusingUser>
    {
        public amusingArticleUserRepository(amusinghoSDbContext context) : base(context)
        {
            
        }
    }
}
