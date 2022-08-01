using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringExtensionsBspmLibrary;
using System;

namespace StringExtensionsBspmLibraryTests
{
    [TestClass]
    public class StringExtensionsTimeTests
    {
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
