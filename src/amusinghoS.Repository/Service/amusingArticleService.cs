using System;
using System.Collections.Generic;
using System.Text;
using amusinghoS.EntityData;
using amusinghoS.EntityData.Model;
using amusinghoS.Interface.Repository;

namespace amusinghoS.Service.Service
{
    public class amusingArticleService : Repository<amusingArticle>
    {
        private readonly amusinghoSDbContext _context;
        public amusingArticleService(amusinghoSDbContext context) : base (context) 
        {
            _context = context;
        }
        public IEnumerable<amusingArticle> GetAllArticle()
        {
            return _context.amusingArticles;
        }
    }
}
