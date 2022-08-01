using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace StringExtensionsBspmLibrary
{
    public static partial class StringExtensions
    {
        #region Try Parse Time

        /// <summary>
        /// Try to parse the value to a DateTime.
        /// Returns default value if <paramref name="value"/> can't be parsed into a DateTime.
        /// 
        /// </summary>
        /// <param name="value">String to Parse into DateTime</param>
        /// <param name="style">DateTimeStyles as define by DateTime.TryParse</param>
        /// <param name="provider">IFormatProvider as define by DateTime.TryParse</param>
        /// <returns></returns>
        public static DateTime? TryParseToDateTime(this string? value, DateTimeStyles? style = null, IFormatProvider? provider = null)
        {
            if (value == null)
            {
                return default;
            }
            else
            {
                bool isSuccess;
                DateTime result;
                if (style != null)
                {
                    isSuccess = DateTime.TryParse(value, provider, style.Value, out result);
                }
                else
                {
                    isSuccess = DateTime.TryParse(value, out result);
                }
                return isSuccess ? result : (DateTime?)null;
            }
        }

        /// <summary>
        /// Try to parse the value to a TimeSpan.
        /// Returns default value if <paramref name="value"/> can't be parsed into a TimeSpan.
        /// 
        /// </summary>
        /// <param name="value">String to Parse into TimeSpan</param>
        /// <param name="provider">IFormatProvider as define by TimeSpan.TryParse</param>
        /// <returns></returns>
        public static TimeSpan? TryParseToTimeSpan(this string? value, IFormatProvider? provider = null)
        {
            if (value == null)
            {
                return default;
            }
            else
            {
                bool isSuccess = TimeSpan.TryParse(value, provider, out TimeSpan result);

                return isSuccess ? result : (TimeSpan?)null;
            }
        }

        /// <summary>
        /// Try to parse the value to a DateTime.
        /// Returns default value if <paramref name="value"/> can't be parsed into a DateTime.
        /// 
        /// </summary>
        /// <param name="value">String to Parse into TimeSpan</param>
        /// <param name="formats">Formats of the string Ex : ["g", "G", "%h"]</param>
        /// <param name="style">TimeSpanStyles as define by TimeSpan.TryParseExact</param>
        /// <param name="provider">IFormatProvider as define by TimeSpan.TryParse</param>
        /// <returns></returns>
        public static TimeSpan? TryParseToTimeSpan(this string? value, string[] formats, TimeSpanStyles? style = null, IFormatProvider? provider = null)
        {
            if (value == null)
            {
                return default;
            }
            else
            {
                bool isSuccess;
                TimeSpan result;
                if (style != null)
                {
                    isSuccess = TimeSpan.TryParseExact(value, formats, provider, style.Value, out result);
                }
                else
                {
                    isSuccess = TimeSpan.TryParseExact(value, formats, provider, out result);
                }
                return isSuccess ? result : (TimeSpan?)null;
            }
        }


        /// <summary>
        /// Try to parse the value to a DateTime.
        /// Returns default value if <paramref name="value"/> can't be parsed into a DateTime.
        /// 
        /// </summary>
        /// <param name="value">String to Parse into TimeSpan</param>
        /// <param name="format">Format of the string Ex : ["g", "G", "%h"]</param>
        /// <param name="style">TimeSpanStyles as define by TimeSpan.TryParseExact</param>
        /// <param name="provider">IFormatProvider as define by TimeSpan.TryParse</param>
        /// <returns></returns>
        public static TimeSpan? TryParseToTimeSpan(this string? value, string format, TimeSpanStyles? style = null, IFormatProvider? provider = null)
        {
            return TryParseToTimeSpan(value, new string[1] { format }, style, provider);
        }
        #endregion

        /// <summary>
        /// Convert a string containing minutes, seconds and milliseconds into time span. 
        /// The string must have one of the following format:
        ///         - m:s.f       ex: 1:23.45     for 1 minutes 23 seconds and 450 milliseconds
        ///         - m:s:f       ex: 1:23:45     for 1 minutes 23 seconds and 450 milliseconds
        ///         - m.s.f       ex: 1.23.45     for 1 minutes 23 seconds and 450 milliseconds
        ///         - m's''f      ex: 1'23''45    for 1 minutes 23 seconds and 450 milliseconds
        ///         - m's"f       ex: 10'2"3      for 10 minutes 2 seconds and 300 milliseconds
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static TimeSpan? ToTimeSpanSmallDuration(this string? text)
        {
            if (text == null)
                return null;

            TimeSpan time;
            Regex regex = new Regex("^(?<m>([0-9]+))(:|.|\')(?<s>([0-9]{1,2}))(\'\'|\"|:|.|,)(?<f>([0-9]+))$");
            if (regex.IsMatch(text))
            {
                text = regex.Replace(text, "0:0:${m}:${s}.${f}");
                var isValidTimeSpan = TimeSpan.TryParse(text, System.Globalization.CultureInfo.InvariantCulture, out time);
                if (isValidTimeSpan)
                    return time;
            }

            return null;
        }


        ///// <summary>
        ///// Converts a date to a culture invariant string, keeping only 
        ///// the date part of the DateTime object
        ///// </summary>
        ///// <param name="date"></param>
        ///// <returns></returns>
        //public static string ToInvariantString(this DateTime date, string format = "dd/MM/yyyy")
        //{
        //    return date.ToString(format, CultureInfo.InvariantCulture);
        //}

        ///// <summary>
        ///// Converts a date to a culture invariant string, keeping only 
        ///// the date part of the DateTime object
        ///// </summary>
        ///// <param name="date"></param>
        ///// <returns></returns>
        //public static string ToInvariantString(this DateTime? date, string format = "dd/MM/yyyy")
        //{
        //    if (date == null)
        //        return string.Empty;
        //    else
        //        return date.Value.ToInvariantString(format);
        //}
    }
}
