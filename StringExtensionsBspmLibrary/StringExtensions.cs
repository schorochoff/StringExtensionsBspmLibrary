namespace StringExtensionsBspmLibrary
{
    public static class StringExtensions
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
        /// Returns True if the value is "true", "True", "TRUE", "YES", "yes, "OK", "ok", 1, ...
        /// </summary>
        /// <param name="value">Value to test</param>
        /// <returns></returns>
        public static bool IsTrue(this string value)
        {
            return value.Trim() == "1" ||
                    string.Compare(value.Trim(), "true", ignoreCase: true) == 0 ||
                    string.Compare(value.Trim(), "yes", ignoreCase: true) == 0 ||
                    string.Compare(value.Trim(), "ok", ignoreCase: true) == 0 ||
                    string.Compare(value.Trim(), "ja", ignoreCase: true) == 0 ||
                    string.Compare(value.Trim(), "y", ignoreCase: true) == 0 ||
                    string.Compare(value.Trim(), "oui", ignoreCase: true) == 0;
        }
    }
}
