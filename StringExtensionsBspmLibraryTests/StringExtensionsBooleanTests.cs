using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringExtensionsBspmLibrary;
using System;
using System.Globalization;

namespace StringExtensionsBspmLibraryTests
{
    [TestClass]
    public class StringExtensionsBooleanTests
    {
        [TestMethod]
        [DataRow("true")]
        [DataRow("True")]
        [DataRow("TRUE")]
        [DataRow("YES")]
        [DataRow("yes")]
        [DataRow("yeS")]
        [DataRow("Ok")]
        [DataRow("ok")]
        [DataRow("1")]
        [DataRow("y")]
        public void TimeSpanExtensions_Boolean_IsTrue_True(string mockedValue)
        {
            Assert.IsTrue(mockedValue.IsTrue());
        }

        [TestMethod]
        [DataRow("false")]
        [DataRow("False")]
        [DataRow("False")]
        [DataRow("No")]
        [DataRow("n")]
        [DataRow("-1")]
        [DataRow("0")]
        [DataRow("2")]
        [DataRow("azerty")]
        public void TimeSpanExtensions_Boolean_IsTrue_False(string mockedValue)
        {
            Assert.IsFalse(mockedValue.IsTrue());
        }
    }
}
