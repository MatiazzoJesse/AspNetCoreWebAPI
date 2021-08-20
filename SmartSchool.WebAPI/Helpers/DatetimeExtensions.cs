using System;

namespace SmartSchool.WebAPI.Helpers
{
    public static class DatetimeExtensions
    {
        public static int GetCurrentYear(this DateTime datetime)
        {
            var currentDate = DateTime.UtcNow;
            int age = currentDate.Year - datetime.Year;
            if (currentDate < datetime.AddYears(age))
            {
                age--;
            }
            return age;
        }
    }
}