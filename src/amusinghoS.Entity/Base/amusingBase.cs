using System;
using System.Collections.Generic;
using System.Text;

namespace amusinghoS.EntityData.Base
{
    /// <summary>
    /// Base class of model class
    /// </summary>
    public class amusingBase
    {
        public DateTime CreateTime { get; set; }
        public string CreateUserId { get; set; }
        public DateTime DelTime { get; set; }
        public string DeleteId { get; set; }
    }
}
