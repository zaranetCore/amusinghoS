using amusinghoS.EntityData.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace amusinghoS.EntityData.Model
{
    public class amusingArticleComment : amusingBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string articleCommentId { get; set; } = Guid.NewGuid().ToString();
        [Column(TypeName = "varchar(64)")]
        public string commentatorName { get; set; }
        [Column(TypeName = "LongText")]
        public string content { get; set; }

        public string eamil { get; set; }

        public string weburl { get; set; }

        public string amusingArticleId { get; set; }
        public amusingArticle amusingArticle { get; set; }
    }
}
