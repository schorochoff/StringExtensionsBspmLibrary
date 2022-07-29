using System;
using System.Globalization;

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

        //#region Extract Number
        ///// <summary>
        ///// Return the integers contained in <paramref name="value"/>
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static int? ExtractInt(this string? value)
        //{
        //    var valueCleaned = Regex.Match(value, @"\d+").Value;
        //    int result;
        //    if (int.TryParse(valueCleaned, out result))
        //        return result;
        //    else
        //        return null;
        //}

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
        //#endregion


        ///// <summary>
        ///// "123"  = "123": true
        ///// "0123" = "123": true
        ///// " 123" = "123": true
        ///// "A123" = "123": false
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static bool IsDigitsEquals(this string source, string value)
        //{
        //    return Convert.ToInt64("0" + source.KeepDigitsOnly()) == Convert.ToInt64("0" + value.KeepDigitsOnly());
        //}


        ///// <summary>
        ///// "ABC-123" => "123"
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static string KeepDigitsOnly(this string value)
        //{
        //    if (String.IsNullOrEmpty(value))
        //        return string.Empty;

        //    return Regex.Replace(value, "[^0-9]", String.Empty);
        //}
    }
}
