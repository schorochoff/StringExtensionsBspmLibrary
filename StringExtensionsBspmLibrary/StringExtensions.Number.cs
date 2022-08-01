using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringExtensionsBspmLibrary
{
    public static partial class StringExtensions
    {
        #region Try Parse Numbers

        /// <summary>
        /// Try to parse the value to an integer.
        /// Returns default value if <paramref name="value"/> can't be parsed into a int.
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="style">NumberStyle as define by int.TryParse</param>
        /// <param name="provider">IFormatProvider as define by int.TryParse</param>
        /// <returns></returns>
        public static int? TryParseToInt(this string? value, NumberStyles? style = null, IFormatProvider? provider = null)
        {
            if (value == null)
            {
                return default;
            }
            else
            {
                bool isSuccess;
                int result;
                if (style != null)
                {
                    isSuccess = int.TryParse(value, style.Value, provider, out result);
                }
                else
                {
                    isSuccess = int.TryParse(value, out result);
                }
                return isSuccess ? result : (int?)null;
            }
        }

        /// <summary>
        /// Try to parse the value to a long.
        /// Returns default value if <paramref name="value"/> can't be parsed into a long.
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="style">NumberStyle as define by long.TryParse</param>
        /// <param name="provider">IFormatProvider as define by long.TryParse</param>
        /// <returns></returns>
        public static long? TryParseToLong(this string? value, NumberStyles? style = null, IFormatProvider? provider = null)
        {
            if (value == null)
            {
                return default;
            }
            else
            {
                bool isSuccess;
                long result;
                if (style != null)
                {
                    isSuccess = long.TryParse(value, style.Value, provider, out result);
                }
                else
                {
                    isSuccess = long.TryParse(value, out result);
                }
                return isSuccess ? result : (long?)null;
            }
        }

        /// <summary>
        /// Try to parse the value to a decimal.
        /// Returns default value if <paramref name="value"/> can't be parsed into a decimal.
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="style">NumberStyle as define by decimal.TryParse</param>
        /// <param name="provider">IFormatProvider as define by decimal.TryParse</param>
        /// <returns></returns>
        public static decimal? TryParseToDecimal(this string? value, NumberStyles? style = null, IFormatProvider? provider = null)
        {
            if (value == null)
            {
                return default;
            }
            else
            {
                bool isSuccess;
                decimal result;
                if (style != null)
                {
                    isSuccess = decimal.TryParse(value, style.Value, provider, out result);
                }
                else
                {
                    isSuccess = decimal.TryParse(value, out result);
                }
                return isSuccess ? result : (decimal?)null;
            }
        }



        #endregion

        #region Extract Number

        /// <summary>
        /// Return the first integer found in the string <paramref name="value"/>
        /// Integers can be positive or negative
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int? ExtractFirstInt(this string? value)
        {
            if (value == null)
                return null;
            var firstInt = Regex.Match(value, @"-?( )?\d+").Value.Replace(" ", "");
            return firstInt.TryParseToInt();
        }

        /// <summary>
        /// Return the integers contained in <paramref name="value"/>
        /// Integers can be positive or negative
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IEnumerable<int> ExtractInts(this string? value)
        {
            if (value == null)
                return Enumerable.Empty<int>();
            return Regex.Matches(value, @"-?( )?\d+").Select(i => int.Parse(i.Value.Replace(" ", "")));
        }


        ///// <summary>
        ///// Return the decimal contained in <paramref name="value"/>
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static decimal? ExtractDecimal(this string? value)
        //{
        //    var valueCleaned = Regex.Replace(value, "[^0-9.,]", "").Replace(".", ",");
        //    decimal result;
        //    if (decimal.TryParse(valueCleaned, out result))
        //        return result;
        //    else
        //        return null;
        //}

        #endregion

        /// <summary>
        /// Return a string containing the digits of the given string <param name="value">
        /// "ABC-12.3" => "123"
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string KeepDigitsOnly(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            return Regex.Replace(value, @"[^0-9]", string.Empty);
        }
    }
}
