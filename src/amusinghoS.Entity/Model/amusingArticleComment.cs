using amusinghoS.EntityData.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace amusinghoS.EntityData.Model
{
    public class amusingArticleComment : amusingBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string articleCommentId { get; set; }
        [Column(TypeName = "varchar(64)")]
        public string commentatorName { get; set; }
        [Column(TypeName = "LongText")]
        public string content { get; set; }
    }
}
