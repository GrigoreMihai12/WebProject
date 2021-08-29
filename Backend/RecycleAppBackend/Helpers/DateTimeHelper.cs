using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleAppBackend.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime GetDateFromStringFormatYearMonthAndDay(string date, string separator = "-")
        {
            var dateParams = date.Split(separator);

            return new DateTime(int.Parse(dateParams[0]), int.Parse(dateParams[1]), int.Parse(dateParams[2]));
        }
    }
}
