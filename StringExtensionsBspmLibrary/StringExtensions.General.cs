using System.Linq;
using System.Text.RegularExpressions;

namespace StringExtensionsBspmLibrary
{
    public static partial class StringExtensions
    {
        #region Null, empty or white space

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

        #endregion

        #region Manage string's length

        #region Truncate when Needed

        /// <summary>
        /// Truncate the end of <paramref name="value"/> to have maximum <paramref name="length"/> characters.
        /// </summary>
        /// <param name="value">String that will be eventually truncated</param>
        /// <param name="length">Maximum lenght of the returned string</param>
        /// <param name="withEllipsis">Indicate if truncated strings should ends with a dot</param>
        /// <returns>The first <paramref name="length"/> characters of <paramref name="value"/></returns>
        public static string? Left(this string? value, int length, bool withEllipsis = false)
        {
            // TODO manage bad length
            if (value == null)
                return null;
            else if (value.Length <= length)
                return value;
            else
            {
                if (withEllipsis)
                    return value.Substring(0, length - 1) + ".";
                else
                    return value.Substring(0, length);
            }
        }



        /// <summary>
        /// Truncate the start of <paramref name="value"/> to have maximum <paramref name="length"/> characters.
        /// </summary>
        /// <param name="value">String that will be eventually truncated</param>
        /// <param name="length">Maximum lenght of the returned string</param>
        /// <param name="withEllipsis">Indicate if truncated strings shouldstarts with a dot</param>
        /// <returns>The last <paramref name="length"/> characters of <paramref name="value"/></returns>
        public static string? Right(this string value, int length, bool withEllipsis = false)
        {
            // TODO manage bad length
            if (value == null)
                return null;
            else if (value.Length <= length)
                return value;
            else
            {
                if (withEllipsis)
                    return "." + value.Substring(value.Length - length + 1);
                else
                    return value.Substring(value.Length - length);
            }
        }

        #endregion

        ///// <summary>
        ///// Returns the <paramref name="count"/> first characters or the <paramref name="value"/> string filled with extra <paramref name="paddingChar"/> AFTER the value, to have a lenght of <paramref name="count"/>.
        ///// </summary>
        ///// <param name="value"></param>
        ///// <param name="count">Number of characters to returns</param>
        ///// <param name="paddingChar">A Unicode padding character.</param>
        ///// <returns></returns>
        //public static string LeftOrPadRight(this string value, int count, char paddingChar = ' ')
        //{
        //    if (!string.IsNullOrEmpty(value))
        //    {
        //        if (value.Length > count)
        //            return value.Substring(0, count);
        //        else
        //            return value.PadRight(count, paddingChar);
        //    }
        //    else
        //    {
        //        return new string(paddingChar, count);
        //    }
        //}

        ///// <summary>
        ///// Returns the <paramref name="count"/> first characters or the <paramref name="value"/> string filled with extra <paramref name="paddingChar"/> BEFORE the value, to have a lenght of <paramref name="count"/>.
        ///// </summary>
        ///// <param name="value"></param>
        ///// <param name="count">Number of characters to returns</param>
        ///// <param name="paddingChar">A Unicode padding character.</param>
        ///// <returns></returns>
        //public static string LeftOrPadLeft(this string value, int count, char paddingChar = ' ')
        //{
        //    if (!string.IsNullOrEmpty(value))
        //    {
        //        if (value.Length > count)
        //            return value.Substring(0, count);
        //        else
        //            return value.PadLeft(count, paddingChar);
        //    }
        //    else
        //    {
        //        return new string(paddingChar, count);
        //    }
        //}

        #endregion

        #region  Rework string

        #region Space, \n

        /// <summary>
        /// Returns a string without any whitespace 
        /// </summary>
        /// <param name="input"></param>
        /// <returns>A string with no whitespaces left</returns>
        public static string RemoveWhiteSpace(this string input)
        {
            return new string(input.ToCharArray()
                                   .Where(c => !char.IsWhiteSpace(c))
                                   .ToArray());

        }

        /// <summary>
        /// Returns a string where words are never separed by more than one white space.
        /// Remove starting and ending space.
        /// 
        /// Ex :    I like space    between        words.  -> I like space between words.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>A string with no whitespaces left</returns>
        public static string CleanWhiteSpace(this string input)
        {
            var stringWithSpaces = new string(input.Trim().ToCharArray()
                                   .Select(c => char.IsWhiteSpace(c) ? ' ' : c)
                                   .ToArray());
            while (stringWithSpaces.Contains("  "))
                stringWithSpaces = stringWithSpaces.Replace("  ", " ");
            return stringWithSpaces;
        }

        /// <summary />
        public static string RemoveEmptyLines(this string value)
        {
            return Regex.Replace(value, @"^\s*$[\r\n]*", string.Empty, RegexOptions.Multiline).Trim('\r', '\n');
        }

        //todo clean space

        #endregion

        #region Case

        ///// <summary>
        ///// Returns a correctly formatted horse name : 
        /////     - each first letter of a word capitalized
        /////     - all the other letters minimized
        ///// </summary>
        ///// <param name="horseName"></param>
        ///// <returns></returns>
        //public static string CapitalizeEachWord(this string horseName)
        //{
        //    return CapitalizeAfterCharachter(horseName, ' ');
        //}


        ///// <summary>
        ///// Returns string where : 
        /////     - each first letter of a line is capitalized
        /////     - all the other letters minimized
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static string CapitalizeEachLine(this string value)
        //{
        //    return CapitalizeAfterCharachter(value, '\n');
        //}

        ///// <summary>
        ///// Returns string where : 
        ///// - the first letter is capitalized
        ///// - each First letter after <paramref name="character"/> is capitalised
        ///// 
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //private static string CapitalizeAfterCharachter(this string value, char character)
        //{
        //    if (string.IsNullOrWhiteSpace(value))
        //        return value;

        //    var splitted = value.Split(new char[] { character }, options: StringSplitOptions.RemoveEmptyEntries);
        //    return string.Join(character.ToString(), splitted.Select(sentence => $"{char.ToUpper(sentence[0])}{sentence.Substring(1).ToLower()}"));
        //}

        #endregion

        #region Abreviations

        ///// <summary>
        ///// Return a string composed by the first letter of each word (words are separed by space or -).
        ///// Returned string is in lower case.
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static string GetFirstLetterOfEachWord(this string value)
        //{
        //    var separators = new[] { ' ', '-' };
        //    return GetFirstLetterOfEachWord(value, separators);
        //}

        ///// <summary>
        ///// Return a string composed by the first letter of each word 
        ///// (the characters indicating the separation between words are defined in <paramref name="separators"/>).
        ///// Returned string is in lower case.
        ///// </summary>
        ///// <param name="value"></param>
        ///// <param name="separators">The characters indicating the separation between words</param>
        ///// <returns></returns>
        //public static string GetFirstLetterOfEachWord(this string value, char[] separators)
        //{
        //    var words = value.Split(separators);
        //    var firstLetters = words.Where(word => word.Length > 0).Select(word => word[0]);
        //    return string.Join("", firstLetters).ToLower();
        //}

        #endregion

        #region Path

        ///// <summary>
        ///// Returns the string value with a trailing slash if none exists already.
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static string WithTrailingSlash(this string value)
        //{
        //    var slash = value.EndsWith("/") ? "" : "/";
        //    return $"{value}{slash}";
        //}

        #endregion

        ///// <summary>
        ///// Returns a string with <paramref name="value"/> repeated n times.
        ///// Returns an empty string if n is negative. TODO
        ///// </summary>
        ///// <param name="value"></param>
        ///// <param name="n"></param>
        ///// <returns></returns>
        //public static string Repeat(this string value, int n)
        //{
        //    if (n <= 0)
        //        return string.Empty;
        //    else
        //        return string.Concat(Enumerable.Repeat(value, n));
        //}

        ///// <summary>
        ///// "ABC-123" => "ABC"
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static string KeepLettersOnly(this string value)
        //{
        // Todo Accent
        //    return Regex.Replace(value, "[^a-zA-Z]", string.Empty);
        //}

        ///// <summary>
        ///// "ABC-123" => "C"
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static string KeepLastLetterOnly(this string value)
        //{
        //    value = value.KeepLettersOnly();
        //    if (value.Any() == false)
        //        return string.Empty;

        //    return value[value.Length - 1].ToString();
        //}



        ///// <summary>
        ///// "ABC-123" => "ABC123"
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static string KeepLettersOrDigitsOnly(this string value)
        //{
        //    if (string.IsNullOrEmpty(value))
        //        return string.Empty;

        //    return Regex.Replace(value, "[^0-9a-zA-Z]", string.Empty);
        //}

        #endregion


        ///// <summary />
        //public static string[] SplitInParts(this string value, string separator, int numberOfParts)
        //{
        //    if (value == null)
        //        return new string[numberOfParts];

        //    var parts = value.Split(separator);

        //    if (parts.Length == numberOfParts)
        //        return parts;

        //    else if (parts.Length > numberOfParts)
        //        return parts.Take(numberOfParts).ToArray();

        //    else
        //    {
        //        return parts.Concat(new string[numberOfParts - parts.Length]).ToArray();
        //    }
        //}

        ///// <summary />
        //public static Tuple<string, string, string, string> ToWbs(this string value)
        //{
        //    var parts = SplitInParts(value, ".", 4);
        //    return new Tuple<string, string, string, string>(parts[0], parts[1], parts[2], parts[3]);
        //}


        ///// <summary>
        ///// Returns a value indicating whether a specified substring occurs within this string.
        ///// </summary>
        ///// <param name="source"></param>
        ///// <param name="value">The string to seek.</param>
        ///// <returns>true if the value parameter occurs within this string, or if value is the empty string (""); otherwise, false.</returns>
        //public static bool ContainsIgnoreAccents(this string source, string value)
        //{
        //    return source.ContainsIgnoreAccents(value, ignoreCase: true);
        //}

        ///// <summary>
        ///// Returns a value indicating whether a specified substring occurs within this string.
        ///// </summary>
        ///// <param name="source"></param>
        ///// <param name="value">The string to seek.</param>
        ///// <param name="ignoreCase">The string to seek.</param>
        ///// <returns>true if the value parameter occurs within this string, or if value is the empty string (""); otherwise, false.</returns>
        //public static bool ContainsIgnoreAccents(this string source, string value, bool ignoreCase)
        //{
        //    var compareOptions = CompareOptions.IgnoreNonSpace;
        //    if (ignoreCase)
        //    {
        //        compareOptions |= CompareOptions.IgnoreCase;
        //    }
        //    return CultureInfo.InvariantCulture.CompareInfo.IndexOf(source, value, compareOptions) != -1;
        //}


        ///// <summary />
        //public static bool ContainsInvariant(this string source, string value)
        //{
        //    var compareInfo = CultureInfo.InvariantCulture.CompareInfo;
        //    var options = CompareOptions.IgnoreCase |
        //                  CompareOptions.IgnoreSymbols |
        //                  CompareOptions.IgnoreNonSpace;
        //    return compareInfo.IndexOf(source, value, options) >= 0;
        //}

        ///// <summary />
        //public static bool IsEqual(this string source, string value)
        //{
        //    return String.Compare(source, value, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0;
        //}
    }
}
