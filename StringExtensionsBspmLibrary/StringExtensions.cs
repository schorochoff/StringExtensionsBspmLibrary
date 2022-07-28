using System.Text.RegularExpressions;

namespace StringExtensionsBspmLibrary
{
    public static class StringExtensions
    {

        /// <summary>
        /// Trims a string and returns it. If the string is null, replace it with <paramref name="defaultReplacement"/>
        /// or with string.Empty if no parameter is specified.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultReplacement"></param>
        /// <returns></returns>
        public static string CleanWhitespaces(this string? value, string defaultReplacement = "")
        {
            return value?.Trim() ?? defaultReplacement;
        }

        /// <summary>
        /// Truncate a string with maximum <paramref name="length"/> characters if needed.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string? Left(this string? item, int length)
        {
            if (item == null)
                return null;
            if (item.Length > length)
                return item.Substring(0, length);
            else
                return item;
        }

        /// <summary>
        /// Return null if <paramref name="value"/> is null or empty. Return <paramref name="value"/> otherwize
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string? OrNullIfEmpty(this string? value)
        {
            if (string.IsNullOrEmpty(value))
                return null;
            else
                return value;
        }

        /// <summary>
        /// Return null if <paramref name="value"/> is null or empty or white space. Return <paramref name="value"/> otherwize
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string? OrNullIfWhiteSpace(this string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;
            else
                return value;
        }

        #region Numbers

        /// <summary>
        /// Try to parse the value to an integer.
        /// Returns default value if an error occured.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int? TryParseToInt(this string? value)
        {
            if (value == null)
            {
                return default;
            }
            else
            {
                var success = int.TryParse(value, out int result);
                return success ? result : (int?)null;
            }
        }

        /// <summary>
        /// Return the integers contained in <paramref name="value"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int? ExtractInt(this string? value)
        {
            var valueCleaned = Regex.Match(value, @"\d+").Value;
            int result;
            if (int.TryParse(valueCleaned, out result))
                return result;
            else
                return null;
        }

        /// <summary>
        /// Return the decimal contained in <paramref name="value"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal? ExtractDecimal(this string? value)
        {
            var valueCleaned = Regex.Replace(value, "[^0-9.,]", "").Replace(".", ",");
            decimal result;
            if (decimal.TryParse(valueCleaned, out result))
                return result;
            else
                return null;
        }

        #endregion

        #region Boolean 
        /// <summary>
        /// Returns True if the value is "true", "True", "TRUE", "YES", "yes, "OK", "ok", 1, ...
        /// </summary>
        /// <param name="value">Value to test</param>
        /// <returns></returns>
        public static bool IsTrue(this string value)
        {
            return value.Trim() == "1" ||
                    string.Compare(value.Trim(), "true", ignoreCase: true) == 0 ||
                    string.Compare(value.Trim(), "yes", ignoreCase: true) == 0 ||
                    string.Compare(value.Trim(), "ok", ignoreCase: true) == 0 ||
                    string.Compare(value.Trim(), "ja", ignoreCase: true) == 0 ||
                    string.Compare(value.Trim(), "y", ignoreCase: true) == 0 ||
                    string.Compare(value.Trim(), "oui", ignoreCase: true) == 0;
        }

        #endregion
    }
}
