using amusinghoS.EntityData.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace amusinghoS.EntityData.Model
{
   public  class amusingArticle : amusingBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string articleId { get; set; }
        [Required]
        [Column(TypeName = "varchar(36)")]
        public string Title { get; set; }
        [Column(TypeName = "varchar(130)")]
        public string Image { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Description { get; set; }
    }
}
