namespace StringExtensionsBspmLibrary
{
    public static partial class StringExtensions
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


    }
}
