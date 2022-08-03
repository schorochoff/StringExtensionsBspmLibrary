using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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

        /// <summary>
        /// Returns string where : 
        /// - the first letter is capitalized
        /// - each first letter after a character in <paramref name="targetCharacters"/> is capitalised
        /// 
        /// <paramref name="minimizeOtherChar"/> Indicate if the other character of the string should be minimised
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetCharacters"></param>
        /// <param name="minimizeOtherChar">Indicate if the other character of the string should be minimised</param>
        /// <returns></returns>
        public static string CapitalizeAfterCharacters(this string value, IEnumerable<char> targetCharacters, bool minimizeOtherChar = false)
        {
            var stringToCapitalize = value.ToCharArray();

            if (string.IsNullOrEmpty(value))
                return value;
            else if (!targetCharacters.Any() || !stringToCapitalize.Intersect(targetCharacters).Any())
            {
                var firstChar = value.Substring(0, 1).ToUpper();
                var otherChars = value.Substring(1, value.Length - 1);
                if (minimizeOtherChar)
                    otherChars = otherChars.ToLower();
                return firstChar + otherChars;
            }
            else
            {
                var stringCapitalized = new StringBuilder();
                var lastCharacter = targetCharacters.First();
                foreach (var character in stringToCapitalize)
                {

                    if (targetCharacters.Contains(lastCharacter))
                        stringCapitalized.Append(char.ToUpper(character));
                    else
                        stringCapitalized.Append(minimizeOtherChar ? char.ToLower(character) : character);

                    lastCharacter = character;
                }
                return stringCapitalized.ToString();
            }
        }

        /// <summary>
        /// Returns string where : 
        /// - the first letter is capitalized
        /// - each First letter after <paramref name="character"/> is capitalised
        /// 
        /// <paramref name="minimizeOtherChar"/> Indicate if the other character of the string should be minimised
        /// </summary>
        /// <param name="value"></param>
        /// <param name="character"></param>
        /// <param name="minimizeOtherChar">Indicate if the other character of the string should be minimised</param>
        /// <returns></returns>
        public static string CapitalizeAfterCharacter(this string value, char character, bool minimizeOtherChar = false)
        {
            return CapitalizeAfterCharacters(value, new[] { character }, minimizeOtherChar);
        }

        /// <summary>
        /// Returns string where : 
        ///     - first letter of each word is capitalized (word are separed by white space)
        ///     - all the other letters minimized
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string CapitalizeEachWord(this string value, bool minimizeOtherChar = false)
        {
            return CapitalizeAfterCharacters(value, new char[] { ' ', '\t', '\n', '\r' }, minimizeOtherChar);
        }


        /// <summary>
        /// Returns string where : 
        ///     - first character of each line is capitalized
        ///     - all the other letters minimized
        ///     - trim space at the begining  at the end of the sentence
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string CapitalizeEachLine(this string value, bool minimizeOtherChar = false)
        {
            var sentencesTrimmed = value.Split('\n').Select(sentence => sentence.Trim());
            var textTrimed = string.Join('\n', sentencesTrimmed);
            return CapitalizeAfterCharacter(textTrimed, '\n', minimizeOtherChar);
        }

        #endregion

        #region Abreviations

        /// <summary>
        /// Return a string composed by the first letter of each word (words are separed by space or -).
        /// Returned string is in lower case.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetFirstLetterOfEachWord(this string value)
        {
            var separators = new[] { ' ', '\t', '\n', '\r' };
            return GetFirstLetterAfterSeparators(value, separators);
        }

        /// <summary>
        /// Return a string composed by the first LETTER of each word. 
        /// (the characters indicating the separation between words are defined in <paramref name="separators"/>).
        /// </summary>
        /// <param name="value"></param>
        /// <param name="separators">The characters indicating the separation between words</param>
        /// <returns></returns>
        public static string GetFirstLetterAfterSeparators(this string value, char[] separators)
        {
            var firstLetters = value.Split(separators)
                                    .Select(word => word.KeepFirstLetterOnly());
            return string.Join("", firstLetters);
        }

        /// <summary>
        /// Return a string composed by the first characters present after a separator <paramref name="separators"/>
        /// 
        /// Ex : GetFirstCharachtersAfterSeparators("Hello world,I love you", new char[] {' ', ','}) -> HwIly
        /// </summary>
        /// <param name="value"></param>
        /// <param name="separators"></param>
        /// <returns></returns>
        public static string GetFirstCharactersAfterSeparators(this string value, char[] separators)
        {
            var words = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            var firstCharacters = words.Select(word => word[0]);
            return string.Join("", firstCharacters);
        }

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

        /// <summary>
        /// Remove accent from a text
        /// 
        /// Ex :Gaelle, ma cherie ! Ou va tu comme ca ? -> Gaëlle, ma chérie ! Où va tu comme ça ?
        /// 
        /// Source: http://archives.miloush.net/michkap/archive/2007/05/14/2629747.html
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveAccents(this string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder
                .ToString()
                .Normalize(NormalizationForm.FormC);

        }

        /// <summary>
        /// "ABC-123" => "ABC123"
        /// </summary>
        /// <param name="value"></param>
        /// <param name="withAccentedLetters">Indicate if letters with an accent should be keeped</param>
        /// <returns></returns>
        public static string KeepLettersOrDigitsOnly(this string value, bool withAccentedLetters = true)
        {
            if (withAccentedLetters)
                return Regex.Replace(value, @"[^\w]*[_]*", string.Empty);
            else
                return Regex.Replace(value, "[^0-9a-zA-Z]", string.Empty);
        }

        /// <summary>
        /// "ABC-123" => "ABC"
        /// </summary>
        /// <param name="value"></param>
        /// <param name="withAccentedLetters">Indicate if letters with an accent should be keeped</param>
        /// <returns></returns>
        public static string KeepLettersOnly(this string value, bool withAccentedLetters = true)
        {
            return Regex.Replace(value.KeepLettersOrDigitsOnly(withAccentedLetters), "[0-9]", string.Empty);
        }

        /// <summary>
        /// "123-ABC" => 'A'
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static char? KeepFirstLetterOnly(this string value)
        {
            var letters = value.KeepLettersOnly();
            if (string.IsNullOrEmpty(letters))
                return null;
            else
                return
                    letters.First();
        }

        /// <summary>
        /// "ABC-123" => 'C'
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static char? KeepLastLetterOnly(this string value)
        {
            var letters = value.KeepLettersOnly();
            if (string.IsNullOrEmpty(letters))
                return null;
            else
                return
                    letters.Last();
        }


        /// <summary>
        /// Returns a string with <paramref name="value"/> repeated <paramref name="n"/> times.
        /// Returns an null if <paramref name="n"/> is negative. 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string? Repeat(this string value, int n)
        {
            if (n < 0)
                return null;
            if (n == 0)
                return string.Empty;
            else
                return string.Concat(Enumerable.Repeat(value, n));
        }

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
