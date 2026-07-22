using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DateHelper
{
    public class DateRangeHelper
    {
        
        public static DateTime GetFromDate(TimeRange range = TimeRange.None)
        {
            var thisDay = DateTime.Today;
            switch (range)
            {
                case TimeRange.None: return thisDay.AddYears(-1000);
                case TimeRange.Day: return thisDay;
                case TimeRange.Week: return thisDay.AddDays(-7);
                case TimeRange.Month: return thisDay.AddMonths(-1);
                case TimeRange.Year: return thisDay.AddYears(-1);
                default:  throw new ArgumentOutOfRangeException(nameof(range));
            }
        }
    }
}
