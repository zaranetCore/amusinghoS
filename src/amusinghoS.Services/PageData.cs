using System;
using System.Collections.Generic;
using System.Text;

namespace amusinghoS.Services
{
    public class PageData<T>
    {
        public List<T> Rows { get; set; }
        public long Totals { get; set; }
    }
}
