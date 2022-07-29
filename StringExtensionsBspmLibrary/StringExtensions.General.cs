namespace StringExtensionsBspmLibrary
{
    public static partial class StringExtensions
    {

        ///// <summary>
        ///// Trims a string and returns it. If the string is null, replace it with <paramref name="defaultReplacement"/>
        ///// or with string.Empty if no parameter is specified.
        ///// </summary>
        ///// <param name="value"></param>
        ///// <param name="defaultReplacement"></param>
        ///// <returns></returns>
        //public static string CleanWhitespaces(this string? value, string defaultReplacement = "")
        //{
        //    return value?.Trim() ?? defaultReplacement;
        //}

        ///// <summary>
        ///// Truncate a string with maximum <paramref name="length"/> characters if needed.
        ///// </summary>
        ///// <param name="item"></param>
        ///// <param name="length"></param>
        ///// <returns></returns>
        //public static string? Left(this string? item, int length)
        //{
        //    if (item == null)
        //        return null;
        //    if (item.Length > length)
        //        return item.Substring(0, length);
        //    else
        //        return item;
        //}

        ///// <summary>
        ///// Return null if <paramref name="value"/> is null or empty. Return <paramref name="value"/> otherwize
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static string? OrNullIfEmpty(this string? value)
        //{
        //    if (string.IsNullOrEmpty(value))
        //        return null;
        //    else
        //        return value;
        //}

        ///// <summary>
        ///// Return null if <paramref name="value"/> is null or empty or white space. Return <paramref name="value"/> otherwize
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static string? OrNullIfWhiteSpace(this string? value)
        //{
        //    if (string.IsNullOrWhiteSpace(value))
        //        return null;
        //    else
        //        return value;
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

        ///// <summary>
        ///// "ABC-123" => "ABC"
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static string KeepLettersOnly(this string value)
        //{
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





        ///// <summary>
        ///// Returns the last N characters.
        ///// </summary>
        ///// <param name="value"></param>
        ///// <param name="length"></param>
        ///// <returns></returns>
        //public static string Right(this string value, int length)
        //{
        //    if (value == null)
        //        return string.Empty;

        //    if (length <= 0)
        //        return string.Empty;
        //    if (length >= value.Length || value.Length - length <= 0)
        //        return value;
        //    else
        //        return value.Substring(value.Length - length);
        //}

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

        ///// <summary>
        ///// Returns a string with <paramref name="value"/> repeated n times.
        ///// Returns an empty string if n is negative.
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

        ///// <summary />
        //public static string RemoveEmptyLines(this string value)
        //{
        //    return Regex.Replace(value, @"^\s*$[\r\n]*", string.Empty, RegexOptions.Multiline).Trim('\r', '\n');
        //}

        ///// <summary>
        ///// Returns a string without any whitespace 
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns>A string with no whitespaces left</returns>
        //public static string RemoveWhiteSpace(this string input)
        //{
        //    return new string(input.ToCharArray()
        //        .Where(c => !char.IsWhiteSpace(c))
        //        .ToArray());
        //}


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

        ///// <summary>
        ///// Returns a space when the string is empty <paramref name="value"/> otherwise
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static string MakeEmptyToOneSpace(this string value)
        //{
        //    return string.IsNullOrEmpty(value) ? " " : value;
        //}

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



        ///// <summary />
        //public static string StringJoin(this IEnumerable<string> items, string separator)
        //{
        //    return String.Join(separator, items);
        //}

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
