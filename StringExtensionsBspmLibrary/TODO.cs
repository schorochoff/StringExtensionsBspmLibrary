namespace StringExtensionsBspmLibrary
{
    public static partial class StringExtensions
    {
        //#region Trotting

        ///// <summary>
        ///// Returns true if the value is a valid e-mail address.
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static bool IsValidEmail(this string? value)
        //{
        //    if (value == null || string.IsNullOrEmpty(value))
        //        return false;

        //    var atCount = value.Count(c => c == '@');
        //    if (atCount != 1)
        //        return false;

        //    var parts = value.Split('@');
        //    if (!parts[1].Contains("."))
        //        return false;

        //    if (parts[0].Length == 0 || parts[1].Length <= 1)
        //        return false;

        //    return true;
        //}





        ///// <summary>
        ///// Serialize the <paramref name="value"/> to a XML document (encoding utf-8)
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="value"></param>
        ///// <param name="defaultNamespace"></param>
        ///// <returns></returns>
        //public static string SerializeToXml<T>(T value, string defaultNamespace)
        //{
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        var serializer = new XmlSerializer(typeof(T), defaultNamespace);

        //        serializer.UnknownAttribute += (sender, e) => { Debugger.Break(); };
        //        serializer.UnknownElement += (sender, e) => { Debugger.Break(); };
        //        serializer.UnknownNode += (sender, e) => { Debugger.Break(); };
        //        serializer.UnreferencedObject += (sender, e) => { Debugger.Break(); };

        //        var settings = new XmlWriterSettings()
        //        {
        //            Indent = true,
        //            Encoding = System.Text.Encoding.UTF8,
        //        };

        //        using (var xmlWriter = XmlWriter.Create(memoryStream, settings))
        //        {
        //            serializer.Serialize(xmlWriter, value);
        //            return System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
        //        }
        //    }
        //}



        //public static string FormatBreakLinesToBrHtml(this string value) => value.Replace("\n", "<br>");

        ///// <summary>
        ///// Returns the string value that can be rendered as markup such as HTML.
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static string ToHtml(this string value)
        //{
        //    var html = System.Web.HttpUtility.HtmlEncode(value);
        //    html = html.Replace("\n", "<br />");
        //    return html;
        //}



        ////File Info 
        ///// <summary/>
        //public static string RemoveInvalidChars(this string name)
        //{
        //    if (String.IsNullOrEmpty(name))
        //        return String.Empty;

        //    // https://docs.microsoft.com/en-us/windows/win32/fileio/naming-a-file
        //    return name.Replace('<', ' ')
        //               .Replace('>', ' ')
        //               .Replace(':', ' ')
        //               .Replace('"', ' ')
        //               .Replace('/', ' ')
        //               .Replace('\\', ' ')
        //               .Replace('|', ' ')
        //               .Replace('?', ' ')
        //               .Replace('*', ' ');
        //}




        /////// <summary />
        ////public static bool IsSameXml(this string expected, string actual)
        ////{
        ////    string[] linesOfExpected = expected.Split('\n', '\r').Select(i => i.Trim()).Where(i => i != "").ToArray();
        ////    string[] linesOfActual = actual.Split('\n', '\r').Select(i => i.Trim()).Where(i => i != "").ToArray();
        ////    var invalidLines = new List<string>();
        ////    int nbOfLines = linesOfExpected.Length < linesOfActual.Length ? linesOfExpected.Length : linesOfActual.Length;

        ////    for (int i = 0; i < nbOfLines; i++)
        ////    {
        ////        if (linesOfExpected[i] != linesOfActual[i])
        ////        {
        ////            invalidLines.Add($"#Line {i} - Expected \"{linesOfExpected[i]}\", Actual \"{linesOfActual[i]}\"");
        ////        }
        ////    }

        ////    if (invalidLines.Count > 0)
        ////        throw new AssertFailedException(String.Join(Environment.NewLine, invalidLines));
        ////    return true;
        ////}

        //#endregion

        //#region UPM
        //#endregion

        //#region AllPersons


        //#endregion

        //#region SmartTime


        ///// <summary>
        ///// Parse a string and returns a dictionary.  
        ///// Key and value must be seperated by an equal sign (=).  
        ///// Parameters must be seperated by a semi-colon (;).  
        ///// I.E.: param1=value1;param2=value2
        ///// </summary>
        ///// <param name="value"></param>
        ///// <param name="IsCaseSensitive">
        ///// If true, keep the lower and upper cases of key/value.
        ///// If false, returns all key/value with lower cases.
        ///// Is true by default.
        ///// </param>
        //public static IDictionary<string, string> ToDictionary(this string? value, bool IsCaseSensitive = true)
        //{
        //    var result = new Dictionary<string, string>();

        //    if (!String.IsNullOrEmpty(value))
        //    {
        //        foreach (var item in value.Split(";", StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            var keyValue = item.SplitInParts("=", 2);
        //            var key = keyValue[0].Trim();

        //            if (!String.IsNullOrEmpty(key))
        //            {
        //                var val = String.IsNullOrEmpty(keyValue[1]) ? String.Empty : keyValue[1].Trim();

        //                if (IsCaseSensitive)
        //                    result.AddOrUpdate<string, string>(key, val);
        //                else
        //                    result.AddOrUpdate(key.ToLowerInvariant(), val.ToLowerInvariant());
        //            }
        //        }
        //    }

        //    return result;
        //}




        ///// <summary>
        ///// Returns true if the <paramref name="email"/> is a valid email.
        ///// </summary>
        ///// <param name="email"></param>
        ///// <returns></returns>
        //public static bool IsValidEmail2(this string? email)
        //{
        //    if (email?.Contains("<") == true ||
        //        email?.Contains(">") == true)
        //        return false;

        //    bool isValid = true;
        //    try
        //    {
        //        new System.Net.Mail.MailAddress(email);
        //    }
        //    catch (Exception ex) when (ex is ArgumentNullException ||
        //                               ex is ArgumentException ||
        //                               ex is FormatException)
        //    {
        //        isValid = false;
        //    }
        //    return isValid;
        //}


        //#endregion
    }
    //todo remove 

    /// <summary />
    //public static class DictionnaryExtensions
    //{
    //    /// <summary>
    //    /// Add or update the value of a given key.
    //    /// </summary>
    //    /// <typeparam name="TKey">Key</typeparam>
    //    /// <typeparam name="TValue">Value</typeparam>
    //    /// <param name="dictionnary">The IDictionnary to update</param>
    //    /// <param name="name"></param>
    //    /// <param name="value"></param>
    //    public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dictionnary, TKey name, TValue value) where TKey : notnull
    //    {
    //        if (dictionnary.ContainsKey(name))
    //            dictionnary[name] = value;
    //        else
    //            dictionnary.Add(name, value);
    //    }
    //}
}
