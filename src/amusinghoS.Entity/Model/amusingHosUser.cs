using amusinghoS.EntityData.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace amusinghoS.EntityData.Model
{
    public class amusingHosUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string userId { get; set; }
        [MaxLength(16)]
        public string Name { get; set; }
        public string PassWord { get; set; }

    }
}
