namespace StringExtensionsBspmLibrary
{
    public static partial class StringExtensions
    {
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
