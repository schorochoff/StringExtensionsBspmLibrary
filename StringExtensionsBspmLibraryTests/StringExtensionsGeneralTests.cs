using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringExtensionsBspmLibraryTests
{
    [TestClass]
    class StringExtensionsGeneralTests
    {
        //[TestMethod]
        //public void StringExtensions_KeepLettersOnly()
        //{
        //    Assert.AreEqual("", "".KeepLettersOnly());
        //    Assert.AreEqual("abcDEF", "1a2b3c &é\"'(§è!çà)- DEF 456".KeepLettersOnly());
        //}

        //[TestMethod]
        //public void StringExtensions_KeepLastLetterOnly()
        //{
        //    Assert.AreEqual("", "".KeepLastLetterOnly());
        //    Assert.AreEqual("n", "Romain".KeepLastLetterOnly());
        //}



        //[TestMethod]
        //public void StringExtensions_KeepLettersOrDigitsOnly()
        //{
        //    Assert.AreEqual("", "".KeepLettersOrDigitsOnly());
        //    Assert.AreEqual("1a2b3cDEF456", "1a2b3c &é\"'(§è!çà)- DEF 456".KeepLettersOrDigitsOnly());
        //}

        //[TestMethod]
        //public void StringExtensions_Left()
        //{
        //    Assert.AreEqual("", "ABCDEF".Left(-1));
        //    Assert.AreEqual("", "ABCDEF".Left(0));
        //    Assert.AreEqual("ABC", "ABCDEF".Left(3));
        //    Assert.AreEqual("ABCDE", "ABCDEF".Left(5));
        //    Assert.AreEqual("ABCDEF", "ABCDEF".Left(6));
        //    Assert.AreEqual("ABCDEF", "ABCDEF".Left(10));
        //}

        //[TestMethod]
        //public void StringExtensions_Left_WithEllipsis_AtFalse_KeepSameBehavior()
        //{
        //    Assert.AreEqual("", "ABCDEF".Left(-1, withEllipsis: false));
        //    Assert.AreEqual("", "ABCDEF".Left(0, withEllipsis: false));
        //    Assert.AreEqual("ABC", "ABCDEF".Left(3, withEllipsis: false));
        //    Assert.AreEqual("ABCDE", "ABCDEF".Left(5, withEllipsis: false));
        //    Assert.AreEqual("ABCDEF", "ABCDEF".Left(6, withEllipsis: false));
        //    Assert.AreEqual("ABCDEF", "ABCDEF".Left(10, withEllipsis: false));
        //}

        //[TestMethod]
        //public void StringExtensions_Left_WithEllipsis_AtTrue()
        //{
        //    Assert.AreEqual("A...", "ABCDEF".Left(4, withEllipsis: true));
        //    Assert.AreEqual("AB...", "ABCDEF".Left(5, withEllipsis: true));
        //    Assert.AreEqual("ABCDEF", "ABCDEF".Left(6, withEllipsis: true));
        //    Assert.AreEqual("ABCDEF", "ABCDEF".Left(10, withEllipsis: true));
        //}

        //[TestMethod]
        //public void StringExtensions_Left_WithEllipsis_AtTrue_OutOfStringBoundaries()
        //{
        //    Assert.AreEqual("...", "ABCDEF".Left(-1, withEllipsis: true));
        //    Assert.AreEqual("...", "ABCDEF".Left(0, withEllipsis: true));
        //    Assert.AreEqual("...", "ABCDEF".Left(3, withEllipsis: true));
        //}

        //[TestMethod]
        //public void StringExtensions_Right()
        //{
        //    Assert.AreEqual("", "ABCDEF".Right(-1));
        //    Assert.AreEqual("", "ABCDEF".Right(0));
        //    Assert.AreEqual("DEF", "ABCDEF".Right(3));
        //    Assert.AreEqual("BCDEF", "ABCDEF".Right(5));
        //    Assert.AreEqual("ABCDEF", "ABCDEF".Right(6));
        //    Assert.AreEqual("ABCDEF", "ABCDEF".Right(7));
        //    Assert.AreEqual("ABCDEF", "ABCDEF".Right(10));
        //}

        //[TestMethod]
        //public void StringExtensions_Repeat()
        //{
        //    Assert.AreEqual("", "A".Repeat(-1));
        //    Assert.AreEqual("", "A".Repeat(0));
        //    Assert.AreEqual("A", "A".Repeat(1));
        //    Assert.AreEqual("AAA", "A".Repeat(3));
        //}

        //[TestMethod]
        //public void StringExtensions_ContainsIgnoreSymbols_DefaultBehaviorIgnoreCase()
        //{
        //    // Normal use (without checking the case-sensitiveness)
        //    Assert.IsTrue("".ContainsIgnoreAccents(""));
        //    Assert.IsTrue("Romain".ContainsIgnoreAccents("Rom"));
        //    Assert.IsTrue("Romain".ContainsIgnoreAccents("oma"));
        //    Assert.IsTrue("Romain".ContainsIgnoreAccents("main"));

        //    // Source have special and lower/upper characters
        //    Assert.IsTrue("RômàÏn1234".ContainsIgnoreAccents(""));
        //    Assert.IsTrue("RômàÏn1234".ContainsIgnoreAccents("rom"));
        //    Assert.IsTrue("RômàÏn1234".ContainsIgnoreAccents("Rom"));
        //    Assert.IsTrue("RômàÏn1234".ContainsIgnoreAccents("main"));
        //    Assert.IsTrue("RômàÏn1234".ContainsIgnoreAccents("main12"));
        //    Assert.IsTrue("RômàÏn1234".ContainsIgnoreAccents("ROMAIN1234"));

        //    // Target have special and lower/upper characters
        //    Assert.IsTrue("ROMAIN1234".ContainsIgnoreAccents("Rôm"));
        //    Assert.IsTrue("ROMAIN1234".ContainsIgnoreAccents("àÏn"));
        //    Assert.IsTrue("ROMAIN1234".ContainsIgnoreAccents("Ïn1234"));
        //    Assert.IsTrue("ROMAIN1234".ContainsIgnoreAccents("RômàÏn1234"));

        //    // Some other tests
        //    Assert.IsFalse("".ContainsIgnoreAccents("roman"));
        //    Assert.IsFalse("Romain1234".ContainsIgnoreAccents("roman"));
        //    Assert.IsFalse("RômàÏn1234".ContainsIgnoreAccents("roman"));
        //    Assert.IsFalse("RômàÏn1234".ContainsIgnoreAccents("mn"));
        //}

        //[TestMethod]
        //[DataRow("MÂIN")]
        //[DataRow("maÏn")]
        //public void StringExtensions_ContainsIgnoreSymbols_IgnoreCase(string value)
        //{
        //    Assert.IsTrue("RomaÏn".ContainsIgnoreAccents(value, ignoreCase: true));
        //}

        //[TestMethod]
        //[DataRow("mâIn")]
        //[DataRow("Röm")]
        //public void StringExtensions_ContainsIgnoreSymbols_KeepCase(string value)
        //{
        //    Assert.IsTrue("RomaÏn".ContainsIgnoreAccents(value, ignoreCase: false));
        //}

        //[TestMethod]
        //public void StringExtensions_CapitalizeEachWord()
        //{
        //    var name = "A bord d'isques";
        //    Assert.AreEqual("A Bord D'isques", name.CapitalizeEachWord());
        //    name = "A B c D e";
        //    Assert.AreEqual("A B C D E", name.CapitalizeEachWord());
        //    name = "a";
        //    Assert.AreEqual("A", name.CapitalizeEachWord());
        //    name = "       ";
        //    Assert.AreEqual("       ", name.CapitalizeEachWord());
        //    name = "Nom Correctement Formaté";
        //    Assert.AreEqual("Nom Correctement Formaté", name.CapitalizeEachWord());
        //    name = "Nom avec   plusieurs      espaces";
        //    Assert.AreEqual("Nom Avec Plusieurs Espaces", name.CapitalizeEachWord());
        //    name = "";
        //    Assert.AreEqual("", name.CapitalizeEachWord());
        //}

        //[TestMethod]
        //public void StringExtensions_RemoveEmptyLines()
        //{
        //    const string crlf = "\r\n";

        //    var text = $"row1{crlf}row2{crlf}{crlf}row3{crlf}";
        //    Assert.AreEqual($"row1{crlf}row2{crlf}row3", text.RemoveEmptyLines());
        //}
    }
}
