using System;
using System.Collections.Generic;
using System.Text;

namespace amusinghoS.Repository
{
    public class Page<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int TotalRows { get; set; }
        public int PageSize { get; set; }
        public IList<T> LsList { get; set; }
    }
}
