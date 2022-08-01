using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringExtensionsBspmLibrary;
using System;
using System.Globalization;

namespace StringExtensionsBspmLibraryTests
{
    [TestClass]
    public class StringExtensionsTimeTests
    {
        #region Try Parse Time

        [TestInitialize]
        public void testInit()
        {
            CultureInfo.CurrentCulture = new CultureInfo("fr-BE");
        }

        [TestMethod]
        public void StringExtensions_Time_TryParseToDateTime()
        {
            Assert.AreEqual(new DateTime(2003, 2, 1), "01/02/2003".TryParseToDateTime());
            Assert.AreEqual(new DateTime(2003, 2, 1, 4, 5, 0), "01/02/2003 4:05".TryParseToDateTime());
            Assert.AreEqual(new DateTime(2003, 2, 1, 4, 5, 6), "01/02/2003 4:05:06".TryParseToDateTime());
            Assert.AreEqual(new DateTime(2003, 2, 1, 4, 5, 0), "01/02/2003 4:5".TryParseToDateTime());
            Assert.AreEqual(new DateTime(2003, 2, 1, 4, 5, 6), "01/02/2003 4:5:6".TryParseToDateTime());
        }

        [TestMethod]
        public void StringExtensions_Time_TryParseToDateTime_InvalidValues()
        {
            Assert.AreEqual(null, "".TryParseToDateTime());
            Assert.AreEqual(null, " ".TryParseToDateTime());
            Assert.AreEqual(null, "     ".TryParseToDateTime());
            Assert.AreEqual(null, ((string?)null).TryParseToDateTime());
            Assert.AreEqual(null, "abc".TryParseToDateTime());
            Assert.AreEqual(null, "zzz123".TryParseToDateTime());
            Assert.AreEqual(null, "60A".TryParseToDateTime());
            Assert.AreEqual(null, "164.32.25.854".TryParseToDateTime());
            Assert.AreEqual(null, "164:32:25:854".TryParseToDateTime());
            Assert.AreEqual(null, "14/32/25/54".TryParseToDateTime());
        }

        [TestMethod]
        public void StringExtensions_Time_TryParseToDateTime_ChangeCulture()
        {
            var style = DateTimeStyles.None;
            // fr-BE : date/month
            Assert.AreEqual(new DateTime(2003, 2, 1, 4, 5, 6), "01/02/2003 4:05:06".TryParseToDateTime());
            // en-US : month/date
            Assert.AreEqual(new DateTime(2003, 1, 2, 4, 5, 6), "01/02/2003 4:05:06".TryParseToDateTime(style, new CultureInfo("en-US")));

        }

        [TestMethod]
        public void StringExtensions_Time_TryParseToTimeSpan()
        {
            Assert.AreEqual(new TimeSpan(4, 5, 0), "4:05".TryParseToTimeSpan());
            Assert.AreEqual(new TimeSpan(4, 5, 6), "4:05:06".TryParseToTimeSpan());
            Assert.AreEqual(new TimeSpan(16, 15, 0), "16:15".TryParseToTimeSpan());
            Assert.AreEqual(new TimeSpan(4, 5, 0), "4:5".TryParseToTimeSpan());
            Assert.AreEqual(new TimeSpan(4, 5, 6), "4:5:6".TryParseToTimeSpan());
            Assert.AreEqual(new TimeSpan(0, 4, 5, 6, 7), "04:05:06,007".TryParseToTimeSpan());
        }

        [TestMethod]
        public void StringExtensions_Time_TryParseToTimeSpan_InvalidValues()
        {
            Assert.AreEqual(null, "".TryParseToTimeSpan());
            Assert.AreEqual(null, " ".TryParseToTimeSpan());
            Assert.AreEqual(null, "     ".TryParseToTimeSpan());
            Assert.AreEqual(null, ((string?)null).TryParseToTimeSpan());
            Assert.AreEqual(null, "abc".TryParseToTimeSpan());
            Assert.AreEqual(null, "zzz123".TryParseToTimeSpan());
            Assert.AreEqual(null, "60A".TryParseToTimeSpan());
            Assert.AreEqual(null, "164.32.25.854".TryParseToTimeSpan());
            Assert.AreEqual(null, "164:32:25:854".TryParseToTimeSpan());
            Assert.AreEqual(null, "14/32/25/54".TryParseToTimeSpan());
        }


        [TestMethod]
        public void StringExtensions_Time_TryParseToTimeSpan_Format()
        {
            Assert.AreEqual(new TimeSpan(12, 30, 15), "12:30:15".TryParseToTimeSpan(@"hh\:mm\:ss"));
            Assert.AreEqual(new TimeSpan(12, 30, 0), "12:30".TryParseToTimeSpan(@"hh\:mm"));
            Assert.AreEqual(new TimeSpan(0, 12, 30), "12:30".TryParseToTimeSpan(@"mm\:ss"));
            Assert.AreEqual(new TimeSpan(0, 0, 15), "15".TryParseToTimeSpan("%s"));
        }

        [TestMethod]
        public void StringExtensions_Time_TryParseToTimeSpan_Formats()
        {

            Assert.AreEqual(new TimeSpan(0, 0, 15), "15".TryParseToTimeSpan(new string[] { "%s", @"mm\:ss", @"hh\:mm\:ss", }));
            Assert.AreEqual(new TimeSpan(0, 12, 30), "12:30".TryParseToTimeSpan(new string[] { "%s", @"mm\:ss", @"hh\:mm\:ss", }));
            Assert.AreEqual(new TimeSpan(12, 30, 15), "12:30:15".TryParseToTimeSpan(new string[] { "%s", @"mm\:ss", @"hh\:mm\:ss", }));
        }

        [TestMethod]
        public void StringExtensions_Time_TryParseToTimeSpan_Style()
        {
            Assert.AreEqual(new TimeSpan(4, 5, 6), "04:05:06".TryParseToTimeSpan(@"hh\:mm\:ss", TimeSpanStyles.None));
            Assert.AreEqual(new TimeSpan(-4, -5, -6), "04:05:06".TryParseToTimeSpan(@"hh\:mm\:ss", TimeSpanStyles.AssumeNegative));
        }

        #endregion

        [TestMethod]
        public void TimeSpanExtensions_Time_ToTimeSpanSmallDuration()
        {
            Assert.AreEqual(new TimeSpan(0, 0, 12, 34, 567), "12:34.567".ToTimeSpanSmallDuration());
            Assert.AreEqual(new TimeSpan(0, 0, 12, 34, 567), "12:34:567".ToTimeSpanSmallDuration());
            Assert.AreEqual(new TimeSpan(0, 0, 12, 34, 567), "12:34,567".ToTimeSpanSmallDuration());
            Assert.AreEqual(new TimeSpan(0, 0, 12, 34, 567), "12.34.567".ToTimeSpanSmallDuration());
            Assert.AreEqual(new TimeSpan(0, 0, 12, 34, 567), "12\'34\"567".ToTimeSpanSmallDuration());
            Assert.AreEqual(new TimeSpan(0, 0, 12, 34, 567), $"12'34''567".ToTimeSpanSmallDuration());
            Assert.AreEqual(new TimeSpan(0, 0, 1, 2, 3), "1:02.003".ToTimeSpanSmallDuration());
            Assert.AreEqual(new TimeSpan(0, 0, 1, 2, 3), $"1\'02''003".ToTimeSpanSmallDuration());
            Assert.AreEqual(new TimeSpan(0, 0, 1, 2, 345), "1:2.345".ToTimeSpanSmallDuration());
            Assert.AreEqual(new TimeSpan(0, 0, 1, 2, 0), "1:2.0".ToTimeSpanSmallDuration());
            Assert.AreEqual(new TimeSpan(0, 0, 1, 2, 0), $"1\'2''0".ToTimeSpanSmallDuration());
            Assert.AreEqual(new TimeSpan(0, 0, 12, 34, 500), "12:34.5".ToTimeSpanSmallDuration());
            Assert.AreEqual(new TimeSpan(0, 0, 12, 34, 560), "12\'34\'\'56".ToTimeSpanSmallDuration());
        }

        [TestMethod]
        public void TimeSpanExtensions_Time_ToTimeSpanSmallDuration_NoTimeStamp()
        {
            Assert.AreEqual(null, "123\'00\'\'00".ToTimeSpanSmallDuration());
            Assert.AreEqual(null, "32".ToTimeSpanSmallDuration());
            Assert.AreEqual(null, "".ToTimeSpanSmallDuration());
            Assert.AreEqual(null, "Azerty34".ToTimeSpanSmallDuration());
            Assert.AreEqual(null, ((string?)null).ToTimeSpanSmallDuration());
        }

        //[TestMethod]
        //public void StringExtensions_ToInvariantCulture()
        //{
        //    var date = DateTime.Parse("2021-05-31", new CultureInfo("nl-NL"));
        //    Assert.AreEqual("31/05/2021", date.ToInvariantString());
        //}
    }
}
