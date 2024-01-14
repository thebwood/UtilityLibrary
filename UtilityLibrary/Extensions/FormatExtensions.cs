using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLibrary.Extensions
{
    public static class FormatExtensions
    {
        public static string FormatDuration(this TimeSpan duration)
        {
            return $"{duration.Days} days, {duration.Hours} hours, {duration.Minutes} minutes";
        }

    }
}
