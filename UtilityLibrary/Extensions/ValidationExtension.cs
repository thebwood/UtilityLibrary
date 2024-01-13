
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UtilityLibrary.Extensions
{
    public static class ValidationExtension
    {
        public static bool IsNumeric(this string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return double.TryParse(input, out _);
        }

        public static bool IsEmail(this string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return Regex.IsMatch(input,
                @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
                RegexOptions.IgnoreCase);
        }



        public static bool IsAlphaNumeric(this string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return input.All(char.IsLetterOrDigit);
        }

    }
}
