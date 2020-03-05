using amusinghoS.EntityData.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace amusinghoS.EntityData.Model
{
    public class amusingArticleDetails : amusingBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string articleDetailsId { get; set; }
        [Column(TypeName = "LongText")]
        public string Html { get; set; }
        public DateTime LastUpdate { get; set; }

        public string amusingArticleId { get; set; }
        public amusingArticle amusingArticle { get; set; }
    }
}
