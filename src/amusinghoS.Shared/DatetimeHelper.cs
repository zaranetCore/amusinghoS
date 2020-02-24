using System;
using System.Collections.Generic;
using System.Text;

namespace amusinghoS.Shared
{
    public static class DatetimeHelper
    {
        public static string GetPeriod(DateTime tmCur)
        {
            if (tmCur.Hour < 8 || tmCur.Hour > 18)
                return "晚上";
            else if (tmCur.Hour >= 8 && tmCur.Hour < 12)
                return "上午";

            return "下午";
        } 
    }
}
