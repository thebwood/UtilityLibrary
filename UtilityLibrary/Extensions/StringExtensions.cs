
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLibrary.Extensions
{
    public static class StringExtensions
    {
        // Extension method for string to reverse its content
        public static string Reverse(this string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input string cannot be null or empty.");
            }

            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        // Extension method for string to check if it's a palindrome
        public static bool IsPalindrome(this string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input string cannot be null or empty.");
            }

            string reversed = input.Reverse();
            return input.Equals(reversed, StringComparison.OrdinalIgnoreCase);
        }

        public static string Truncate(this string? input, int maxLength)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            return input.Length <= maxLength ? input : input.Substring(0, maxLength);
        }

        public static string ToTitleCase(this string? input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }


        public static string RemoveWhitespace(this string? input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            return new string(input.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray());
        }
        public static string Left(this string?   input, int length)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            return input.Substring(0, Math.Min(length, input.Length));
        }

        public static string Right(this string? input, int length)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            return input.Substring(Math.Max(0, input.Length - length));
        }
        public static string Join(this IEnumerable<string> source, string separator)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return string.Join(separator, source);
        }

        public static string SafeSubstring(this string? input, int startIndex, int length)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (startIndex < 0 || startIndex >= input.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Invalid start index.");

            if (length < 0 || startIndex + length > input.Length)
                throw new ArgumentOutOfRangeException(nameof(length), "Invalid length.");

            return input.Substring(startIndex, length);
        }


        public static string RemoveSpecialCharacters(this string? input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            return new string(input.Where(char.IsLetterOrDigit).ToArray());
        }
        public static SecureString ToSecureString(this string? input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            var secureString = new SecureString();
            foreach (char c in input)
            {
                secureString.AppendChar(c);
            }
            return secureString;
        }

    }
}
