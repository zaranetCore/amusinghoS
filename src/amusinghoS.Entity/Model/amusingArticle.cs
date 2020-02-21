using amusinghoS.EntityData.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace amusinghoS.EntityData.Model
{
   public  class amusingArticle : amusingBase
    {
        [Key]
        public string articleId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
