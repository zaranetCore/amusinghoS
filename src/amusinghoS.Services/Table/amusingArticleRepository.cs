using amusinghoS.EntityData;
using amusinghoS.EntityData.Model;
using amusinghoS.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace amusinghoS.Services.Table
{
    public class amusingArticleRepository : RepositoryBase<amusingArticle>
    {
        public amusingArticleRepository(amusinghoSDbContext context) : base(context)
        {

        }
    }
}
