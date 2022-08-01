using System;
using System.Text.RegularExpressions;

namespace StringExtensionsBspmLibrary
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Parse string with represent a race time into Time span. The string must have one of the following format:
        ///         - m:s.f       ex: 1:23.45     for 1 minutes 23 seconds and 450 milliseconds
        ///         - m:s:f       ex: 1:23:45     for 1 minutes 23 seconds and 450 milliseconds
        ///         - m.s.f       ex: 1.23.45     for 1 minutes 23 seconds and 450 milliseconds
        ///         - m's''f      ex: 1'23''45    for 1 minutes 23 seconds and 450 milliseconds
        ///         - m's"f       ex: 10'2"3      for 10 minutes 2 seconds and 300 milliseconds
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static TimeSpan? ToTimeSpan(this string? text)
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
        ///// Try to parse the value to a DateTime.
        ///// Returns the provided default value if an error occured.
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static DateTime TryParseToDateTime(this string? value, DateTime defaultValue)

        //{
        //    if (value == null)
        //    {
        //        return defaultValue;
        //    }
        //    else
        //    {
        //        var success = DateTime.TryParse(value, out DateTime result);
        //        return success ? result : defaultValue;
        //    }
        //}




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



        ///// <summary>
        ///// Parse the <paramref name="value"/> and returns a <see cref="TimeSpan"/> object.
        ///// Returns null if the format of <paramref name="value"/> param is incorrect ("hh:mm").
        ///// </summary>
        //public static TimeSpan? AsTimeSpan(this string value)
        //{
        //    if (TimeSpan.TryParse(value, out TimeSpan timespan))
        //        return timespan;

        //    return null;
        //}
    }
}
