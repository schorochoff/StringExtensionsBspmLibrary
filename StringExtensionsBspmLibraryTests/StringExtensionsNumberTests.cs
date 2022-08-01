using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringExtensionsBspmLibrary;
using System.Globalization;

namespace StringExtensionsBspmLibraryTests
{
    [TestClass]
    public class StringExtensionsNumberTests
    {
        [TestInitialize]
        public void testInit()
        {
            CultureInfo.CurrentCulture = new CultureInfo("fr-CA");
        }

        #region Try Parse Numbers

        [TestMethod]
        public void StringExtensions_TryParseToInt()
        {
            Assert.AreEqual(42, "42".TryParseToInt());
            Assert.AreEqual(0, "0".TryParseToInt());
            Assert.AreEqual(-55, "-55".TryParseToInt());
            Assert.AreEqual(42, "  42 ".TryParseToInt());
        }

        [TestMethod]
        public void StringExtensions_TryParseToInt_InvalidValues()
        {
            Assert.AreEqual(null, "".TryParseToInt());
            Assert.AreEqual(null, " ".TryParseToInt());
            Assert.AreEqual(null, "     ".TryParseToInt());
            Assert.AreEqual(null, ((string?)null).TryParseToInt());
            Assert.AreEqual(null, "abc".TryParseToInt());
            Assert.AreEqual(null, "zzz123".TryParseToInt());
            Assert.AreEqual(null, "60A".TryParseToInt());
        }

        [TestMethod]
        public void StringExtensions_TryParseToInt_ChangeCulture()
        {
            var style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            // fr-CA
            Assert.AreEqual(1032, "1032".TryParseToInt());
            Assert.AreEqual(null, "$1,032".TryParseToInt());
            // en-GB
            Assert.AreEqual(2032, "2032".TryParseToInt(style, new CultureInfo("en-GB")));
            Assert.AreEqual(null, "$2,032".TryParseToInt(style, new CultureInfo("en-GB")));
            // en-US
            Assert.AreEqual(3032, "3032".TryParseToInt(style, new CultureInfo("en-US")));
            Assert.AreEqual(3032, "3,032".TryParseToInt(style, new CultureInfo("en-US")));

        }

        [TestMethod]
        public void StringExtensions_TryParseToLong()
        {
            Assert.AreEqual(42, "42".TryParseToLong());
            Assert.AreEqual(0, "0".TryParseToLong());
            Assert.AreEqual(-55, "-55".TryParseToLong());
            Assert.AreEqual(42, "  42 ".TryParseToLong());
            Assert.AreEqual(-9223372036854775808, "-9223372036854775808".TryParseToLong());
            Assert.AreEqual(9223372036854775807, "9223372036854775807".TryParseToLong());
        }

        [TestMethod]
        public void StringExtensions_TryParseToLong_InvalidValues()
        {
            Assert.AreEqual(null, "".TryParseToLong());
            Assert.AreEqual(null, " ".TryParseToLong());
            Assert.AreEqual(null, "     ".TryParseToLong());
            Assert.AreEqual(null, ((string?)null).TryParseToLong());
            Assert.AreEqual(null, "abc".TryParseToLong());
            Assert.AreEqual(null, "zzz123".TryParseToLong());
            Assert.AreEqual(null, "123zzz".TryParseToLong());
        }

        [TestMethod]
        public void StringExtensions_TryParseToLong_ChangeCulture()
        {
            var style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            // fr-CA
            Assert.AreEqual(1032, "1032".TryParseToLong());
            Assert.AreEqual(null, "$1,032".TryParseToLong());
            // en-GB
            Assert.AreEqual(2032, "2032".TryParseToLong(style, new CultureInfo("en-GB")));
            Assert.AreEqual(null, "$2,032".TryParseToLong(style, new CultureInfo("en-GB")));
            // en-US
            Assert.AreEqual(3032, "3032".TryParseToLong(style, new CultureInfo("en-US")));
            Assert.AreEqual(3032, "3,032".TryParseToLong(style, new CultureInfo("en-US")));

        }


        [TestMethod]
        public void StringExtensions_TryParseToDecimal()
        {
            Assert.AreEqual(42m, "42".TryParseToDecimal());
            Assert.AreEqual(12.34m, "12,34".TryParseToDecimal());
            Assert.AreEqual(1234.56m, "1234,56".TryParseToDecimal());
            Assert.AreEqual(0m, "0".TryParseToDecimal());
            Assert.AreEqual(-55.5m, "-55,5".TryParseToDecimal());
            Assert.AreEqual(42.1m, "  42,1 ".TryParseToDecimal());
        }

        [TestMethod]
        public void StringExtensions_TryParseToDecimal_InvalidValues()
        {
            Assert.AreEqual(null, "".TryParseToDecimal());
            Assert.AreEqual(null, " ".TryParseToDecimal());
            Assert.AreEqual(null, "     ".TryParseToDecimal());
            Assert.AreEqual(null, ((string?)null).TryParseToDecimal());
            Assert.AreEqual(null, "abc".TryParseToDecimal());
            Assert.AreEqual(null, "zzz123".TryParseToDecimal());
            Assert.AreEqual(null, "123zzz".TryParseToDecimal());
        }

        [TestMethod]
        public void StringExtensions_TryParseToDecimal_ChangeCulture()
        {
            var style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;

            // fr-CA
            Assert.AreEqual(1032.12m, "1 032,12".TryParseToDecimal());
            Assert.AreEqual(null, "1032.12".TryParseToDecimal());
            Assert.AreEqual(null, "$1,032.12".TryParseToDecimal());
            // en-GB
            Assert.AreEqual(null, "2 032,12".TryParseToDecimal(style, new CultureInfo("en-GB")));
            Assert.AreEqual(2032.12m, "2032.12".TryParseToDecimal(style, new CultureInfo("en-GB")));
            Assert.AreEqual(null, "$2,032.12".TryParseToDecimal(style, new CultureInfo("en-GB")));
            // en-US
            Assert.AreEqual(null, "3 032,12".TryParseToDecimal(style, new CultureInfo("en-US")));
            Assert.AreEqual(3032.12m, "3032.12".TryParseToDecimal(style, new CultureInfo("en-US")));
            Assert.AreEqual(3032.12m, "3,032.12".TryParseToDecimal(style, new CultureInfo("en-US")));

        }

        #endregion

        [TestMethod]
        public void StringExtensions_KeepDigitsOnly()
        {
            Assert.AreEqual("", "".KeepDigitsOnly());
            Assert.AreEqual("123456", "1a2b3c &é\"'(§è!çà)- DEF 456".KeepDigitsOnly());
        }


    }
}
