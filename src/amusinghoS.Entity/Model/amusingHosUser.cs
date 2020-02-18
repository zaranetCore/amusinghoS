using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace amusinghoS.EntityData.Model
{
    public class amusingHosUser
    {
        public Guid userId { get; set; }
        [MaxLength(16)]
        public string Name { get; set; }
        public string PassWord { get; set; }

    }
}
