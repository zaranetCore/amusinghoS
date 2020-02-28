using amusinghoS.EntityData.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace amusinghoS.EntityData.Model
{
    public class amusingArticleDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string articleDetailsId { get; set; }
        [Column(TypeName = "varchar(48)")]
        public string Html { get; set; }
        public DateTime LastUpdate { get; set; }
        public virtual amusingArticle AmusingArticle { get; set; }
    }
}
