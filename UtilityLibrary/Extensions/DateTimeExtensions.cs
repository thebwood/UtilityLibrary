using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLibrary.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsValidDate(this DateTime date)
        {
            return date > DateTime.MinValue && date < DateTime.MaxValue;
        }
        public static bool IsLeapYear(this DateTime date)
        {
            if (!date.IsValidDate())
                throw new ArgumentException("Invalid date.");

            return DateTime.IsLeapYear(date.Year);
        }

        public static bool IsWeekend(this DateTime date)
        {
            if (date == DateTime.MinValue)
                throw new ArgumentException("Invalid date. Minimum date value not allowed.");

            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        public static bool IsWeekday(this DateTime date)
        {
            if (date == DateTime.MinValue)
                throw new ArgumentException("Invalid date. Minimum date value not allowed.");

            return !date.IsWeekend();
        }

        public static bool IsBusinessDay(this DateTime date)
        {
            if (date == DateTime.MinValue)
                throw new ArgumentException("Invalid date. Minimum date value not allowed.");

            return !date.IsWeekend();
        }

        public static int CalculateAge(this DateTime birthDate)
        {
            if (!birthDate.IsValidDate())
                throw new ArgumentException("Invalid birth date.");

            DateTime currentDate = DateTime.Now;

            int age = currentDate.Year - birthDate.Year;

            if (currentDate.Month < birthDate.Month || (currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day))
            {
                age--;
            }

            return age;
        }

        public static DateTime AddBusinessDays(this DateTime current, int days)
        {
            if (days == 0)
                return current;

            if (days < 0)
                throw new ArgumentException("Number of business days to add must be greater than or equal to zero.");

            int direction = Math.Sign(days);
            int remainingDays = Math.Abs(days);

            while (remainingDays > 0)
            {
                current = current.AddDays(direction);

                if (current.DayOfWeek != DayOfWeek.Saturday && current.DayOfWeek != DayOfWeek.Sunday)
                {
                    remainingDays--;
                }
            }

            return current;
        }
        public static DateTime SubtractBusinessDays(this DateTime date, int businessDays)
        {
            if (businessDays < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(businessDays), "Number of business days to subtract must be non-negative.");
            }

            int sign = businessDays >= 0 ? -1 : 1;
            int remainingBusinessDays = Math.Abs(businessDays);

            while (remainingBusinessDays > 0)
            {
                date = date.AddDays(sign);

                // Check if the current day is a business day (Monday to Friday)
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    remainingBusinessDays--;
                }
            }

            return date;
        }


        public static DateTime FirstDayOfMonth(this DateTime current)
        {
            if (current == DateTime.MinValue)
                throw new ArgumentException("Invalid date. Minimum date value not allowed.");

            return new DateTime(current.Year, current.Month, 1);
        }
        public static DateTime LastDayOfMonth(this DateTime current)
        {
            if (current == DateTime.MinValue)
                throw new ArgumentException("Invalid date. Minimum date value not allowed.");

            return new DateTime(current.Year, current.Month, DateTime.DaysInMonth(current.Year, current.Month));
        }

        public static bool IsInFuture(this DateTime date)
        {
            if (!date.IsValidDate())
                throw new ArgumentException("Invalid date.");

            return date > DateTime.Now;
        }

        public static bool IsInPast(this DateTime date)
        {
            if (!date.IsValidDate())
                throw new ArgumentException("Invalid date.");

            return date < DateTime.Now;
        }
        public static DateTime NextDayOfWeek(this DateTime date, DayOfWeek dayOfWeek)
        {
            if (!date.IsValidDate())
                throw new ArgumentException("Invalid date.");

            int daysUntilTarget = ((int)dayOfWeek - (int)date.DayOfWeek + 7) % 7;
            return date.AddDays(daysUntilTarget);
        }
        public static int GetQuarter(this DateTime date)
        {
            if (!date.IsValidDate())
                throw new ArgumentException("Invalid date.");

            return (date.Month - 1) / 3 + 1;
        }

        public static DateTime RoundDownToNearestHour(this DateTime date)
        {
            if (!date.IsValidDate())
                throw new ArgumentException("Invalid date.");

            return new DateTime(date.Year, date.Month, date.Day, date.Hour, 0, 0);
        }
    }
}
