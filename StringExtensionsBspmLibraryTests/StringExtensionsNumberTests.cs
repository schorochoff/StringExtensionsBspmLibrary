using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringExtensionsBspmLibrary;
using System.Globalization;
using System.Linq;

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
        public void StringExtensions_Number_TryParseToInt()
        {
            Assert.AreEqual(42, "42".TryParseToInt());
            Assert.AreEqual(0, "0".TryParseToInt());
            Assert.AreEqual(-55, "-55".TryParseToInt());
            Assert.AreEqual(42, "  42 ".TryParseToInt());
        }

        [TestMethod]
        public void StringExtensions_Number_TryParseToInt_InvalidValues()
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
        public void StringExtensions_Number_TryParseToInt_ChangeCulture()
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
        public void StringExtensions_Number_TryParseToLong()
        {
            Assert.AreEqual(42, "42".TryParseToLong());
            Assert.AreEqual(0, "0".TryParseToLong());
            Assert.AreEqual(-55, "-55".TryParseToLong());
            Assert.AreEqual(42, "  42 ".TryParseToLong());
            Assert.AreEqual(-9223372036854775808, "-9223372036854775808".TryParseToLong());
            Assert.AreEqual(9223372036854775807, "9223372036854775807".TryParseToLong());
        }

        [TestMethod]
        public void StringExtensions_Number_TryParseToLong_InvalidValues()
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
        public void StringExtensions_Number_TryParseToLong_ChangeCulture()
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
        public void StringExtensions_Number_TryParseToDecimal()
        {
            Assert.AreEqual(42m, "42".TryParseToDecimal());
            Assert.AreEqual(12.34m, "12,34".TryParseToDecimal());
            Assert.AreEqual(1234.56m, "1234,56".TryParseToDecimal());
            Assert.AreEqual(0m, "0".TryParseToDecimal());
            Assert.AreEqual(-55.5m, "-55,5".TryParseToDecimal());
            Assert.AreEqual(42.1m, "  42,1 ".TryParseToDecimal());
        }

        [TestMethod]
        public void StringExtensions_Number_TryParseToDecimal_InvalidValues()
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
        public void StringExtensions_Number_TryParseToDecimal_ChangeCulture()
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

        #region Extract Number

        [TestMethod]
        [DataRow("124")]
        [DataRow("ABD124")]
        [DataRow("AB D124hfkj")]
        [DataRow("A BD124hf kj15")]
        public void StringExtensions_Number_ExtractFirstInt(string? mockedString)
        {
            Assert.AreEqual(124, mockedString.ExtractFirstInt());
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("Fourteen")]
        [DataRow("ABD . cfbk . - ")]
        public void StringExtensions_Number_ExtractFirstInt_NoInt(string? mockedString)
        {
            Assert.AreEqual(null, mockedString.ExtractFirstInt());
        }


        [TestMethod]
        [DataRow("-124")]
        [DataRow("- 124")]
        [DataRow("ABD-124")]
        [DataRow("AB D-124hfkj")]
        [DataRow("A BD-124hf 3 kj-15")]
        public void StringExtensions_Number_ExtractFirstInt_Negative(string? mockedString)
        {
            Assert.AreEqual(-124, mockedString.ExtractFirstInt());
        }


        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("Fourteen")]
        [DataRow("ABD . cfbk . - ")]
        public void StringExtensions_Number_ExtractInts_Empty(string? mockedString)
        {
            Assert.AreEqual(0, mockedString.ExtractInts().Count());
        }

        [TestMethod]
        [DataRow("124")]
        [DataRow("ABD 124 coucou")]
        [DataRow("ABD124")]
        [DataRow("AB D124hfkj")]
        public void StringExtensions_Number_ExtractInts_OneIntPositive(string? mockedString)
        {
            Assert.AreEqual(124, mockedString.ExtractInts().FirstOrDefault());
        }

        [TestMethod]
        [DataRow("-124")]
        [DataRow("- 124")]
        [DataRow("ABD-124")]
        [DataRow("ABD - 124 F")]
        [DataRow("AB D-124hfkj")]
        public void StringExtensions_Number_ExtractInts_OneIntNegative(string? mockedString)
        {
            Assert.AreEqual(-124, mockedString.ExtractInts().FirstOrDefault());
        }

        [TestMethod]
        [DataRow("100 + 24 - 124 = 0")]
        [DataRow("100 + 24 -124 = 0")]
        [DataRow("100 et 24 et-124 égale 0.")]
        [DataRow("100.24-124,0")]
        public void StringExtensions_Number_ExtractInts_SeveralInt(string? mockedString)
        {
            var ints = mockedString.ExtractInts();
            Assert.AreEqual(4, ints.Count());
            Assert.IsTrue(ints.Contains(100), "100 not found");
            Assert.IsTrue(ints.Contains(24), "24 not found");
            Assert.IsTrue(ints.Contains(-124), "124 not found");
            Assert.IsTrue(ints.Contains(0), "0 not found");
        }

        #endregion

        [TestMethod]
        public void StringExtensions_Number_KeepDigitsOnly()
        {
            Assert.AreEqual("", "".KeepDigitsOnly());
            Assert.AreEqual("", "hello word!".KeepDigitsOnly());
            Assert.AreEqual("125", "125".KeepDigitsOnly());
            Assert.AreEqual("123456", "1a2b3c &é\"'(§è!çà)- DEF 456".KeepDigitsOnly());
        }


    }
}
