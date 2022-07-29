using System.Text.RegularExpressions;

namespace StringExtensionsBspmLibrary
{
    public static partial class StringExtensions
    {
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
    }
}
