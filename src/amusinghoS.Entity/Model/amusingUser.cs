using amusinghoS.EntityData.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace amusinghoS.EntityData.Model
{
    public class amusingUser : amusingBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string articleUserId { get; set; } = Guid.NewGuid().ToString();

        [Column(TypeName = "varchar(64)")]
        public string articleUserName { get; set; }
        [Column(TypeName = "varchar(128)")]
        public string password { get; set; }

        public string phoneID { get; set; }

        public string wechat_user_ID { get; set; }

    }
}
