namespace StringExtensionsBspmLibrary
{
    public static partial class StringExtensions
    {
        #region Try Parse

        ///// <summary>
        ///// Try to parse the value to an integer.
        ///// Returns default value if <paramref name="value"/> can't be parsed into a int.
        ///// 
        ///// Example
        ///// "42" -> 42
        ///// "" -> null
        ///// "Hello" ->  null
        ///// "60A" -> null
        ///// "  4 5 " -> ?
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static int? TryParseToInt(this string? value)
        //{
        //    if (value == null)
        //    {
        //        return default;
        //    }
        //    else
        //    {
        //        var success = int.TryParse(value, out int result);
        //        return success ? result : (int?)null;
        //    }
        //}


        ///// <summary>
        ///// Try to parse the value to a decimal.
        ///// Returns default value if an error occured.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static decimal? TryParseToDecimal(this string? value)
        //{
        //    if (value == null)
        //    {
        //        return default;
        //    }
        //    else
        //    {
        //        var success = decimal.TryParse(value, out decimal result);
        //        return success ? result : (decimal?)null;
        //    }
        //}

        ///// <summary>
        ///// Try to parse the value to a long.
        ///// Returns default value if an error occured.
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static long? TryParseToLong(this string? value)

        //{
        //    if (value == null)
        //    {
        //        return default;
        //    }
        //    else
        //    {
        //        var success = long.TryParse(value, out long result);
        //        return success ? result : (long?)null;
        //    }
        //}

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
