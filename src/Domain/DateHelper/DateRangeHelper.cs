using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DateHelper
{
    public class DateRangeHelper
    {
        
        public static (DateTime From, DateTime To) GetWeekTimeRange(DayOfWeek dayOfWeek)
        {
            var today = DateTime.Today;
            var currentDayOfWeek = today.DayOfWeek;

            // Friday is the start of the week
            int daysUntilFriday = ((int)DayOfWeek.Friday - (int)currentDayOfWeek + 7) % 7;
            var startOfWeek = today.AddDays(-daysUntilFriday);

            int daysToAdd = ((int)dayOfWeek - (int)startOfWeek.DayOfWeek + 7) % 7;
            var targetDay = startOfWeek.AddDays(daysToAdd);

            var from = targetDay;
            var to = targetDay.AddDays(1).AddTicks(-1);

            return (from, to);
        }

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
