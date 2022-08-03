using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringExtensionsBspmLibrary;
using System.Linq;

namespace StringExtensionsBspmLibraryTests
{
    [TestClass]
    public class StringExtensionsGeneralTests
    {
        #region Null, empty or white space

        [TestMethod]
        public void StrinExtensions_General_OrNullIfEmpty()
        {
            Assert.IsNull(((string?)null).OrNullIfEmpty());
            Assert.IsNull("".OrNullIfEmpty());
            Assert.AreEqual(" ", " ".OrNullIfEmpty());
            Assert.AreEqual("      ", "      ".OrNullIfEmpty());
            Assert.AreEqual("hello", "hello".OrNullIfEmpty());
            Assert.AreEqual("  _ ", "  _ ".OrNullIfEmpty());
        }

        [TestMethod]
        public void StrinExtensions_General_OrNullIfWhiteSpace()
        {
            Assert.AreEqual(null, ((string?)null).OrNullIfWhiteSpace());
            Assert.AreEqual(null, "".OrNullIfWhiteSpace());
            Assert.AreEqual(null, " ".OrNullIfWhiteSpace());
            Assert.AreEqual(null, "      ".OrNullIfWhiteSpace());
            Assert.AreEqual(null, " \t\n\r".OrNullIfWhiteSpace());
            Assert.AreEqual("hello", "hello".OrNullIfWhiteSpace());
            Assert.AreEqual("  _ ", "  _ ".OrNullIfWhiteSpace());
        }

        #endregion

        #region Manage string's length

        #region Truncate

        [TestMethod]
        public void StringExtensions_Left()
        {
            Assert.AreEqual("", "ABCDEF".Left(0));
            Assert.AreEqual("ABC", "ABCDEF".Left(3));
            Assert.AreEqual("ABCDE", "ABCDEF".Left(5));
            Assert.AreEqual("ABCDEF", "ABCDEF".Left(6));
            Assert.AreEqual("ABCDEF", "ABCDEF".Left(10));
        }

        [TestMethod]
        public void StringExtensions_Left_WithEllipsis()
        {
            Assert.AreEqual("A.", "ABCD".Left(2, withEllipsis: true));
            Assert.AreEqual("AB.", "ABCD".Left(3, withEllipsis: true));
            Assert.AreEqual("ABCD", "ABCD".Left(4, withEllipsis: true));
            Assert.AreEqual("ABCD", "ABCD".Left(10, withEllipsis: true));
        }

        [TestMethod]
        public void StringExtensions_Left_OutOfStringBoundaries()
        {
            // Length OK
            Assert.AreEqual("", "ABCDEF".Left(0));
            Assert.AreEqual(".", "ABCDEF".Left(1, withEllipsis: true));

            //Length To small
            //Assert.AreEqual("", "ABCDEF".Left(-1));
            //Assert.AreEqual(".", "ABCDEF".Left(-1, withEllipsis: true));
            //Assert.AreEqual(".", "ABCDEF".Left(0, withEllipsis: true));
        }

        [TestMethod]
        public void StringExtensions_Right()
        {
            //Assert.AreEqual("", "ABCDEF".Right(-1));
            Assert.AreEqual("", "ABCDEF".Right(0));
            Assert.AreEqual("DEF", "ABCDEF".Right(3));
            Assert.AreEqual("BCDEF", "ABCDEF".Right(5));
            Assert.AreEqual("ABCDEF", "ABCDEF".Right(6));
            Assert.AreEqual("ABCDEF", "ABCDEF".Right(10));
        }

        [TestMethod]
        public void StringExtensions_Right_WithEllipsis()
        {
            Assert.AreEqual(".D", "ABCD".Right(2, withEllipsis: true));
            Assert.AreEqual(".CD", "ABCD".Right(3, withEllipsis: true));
            Assert.AreEqual("ABCD", "ABCD".Right(4, withEllipsis: true));
            Assert.AreEqual("ABCD", "ABCD".Right(10, withEllipsis: true));
        }

        [TestMethod]
        public void StringExtensions_Right_OutOfStringBoundaries()
        {
            // Length OK
            Assert.AreEqual("", "ABCDEF".Right(0));
            Assert.AreEqual(".", "ABCDEF".Right(1, withEllipsis: true));

            //Length To small
            //Assert.AreEqual("", "ABCDEF".Right(-1));
            //Assert.AreEqual(".", "ABCDEF".Right(-1, withEllipsis: true));
            //Assert.AreEqual(".", "ABCDEF".Right(0, withEllipsis: true));
        }

        #endregion

        #endregion

        #region Rework string

        #region Space, \n

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("    ")]
        [DataRow("\t")]
        [DataRow("\r")]
        [DataRow("\t\r  \t  ")]
        public void StringExtensions_General_RemoveWhiteSpace_Empty(string mockedString)
        {
            Assert.AreEqual("", mockedString.RemoveWhiteSpace(), mockedString);
        }

        [TestMethod]
        [DataRow("HelloWorld")]
        [DataRow("Hello World")]
        [DataRow("  Hello  World    ")]
        [DataRow("Hello\tWorld")]
        [DataRow("Hello\rWorld")]
        [DataRow("\t\r Hello\rWorld \t  ")]
        public void StringExtensions_General_RemoveWhiteSpace_Text(string mockedString)
        {
            Assert.AreEqual("HelloWorld", mockedString.RemoveWhiteSpace(), mockedString);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("    ")]
        [DataRow("\t")]
        [DataRow("\r")]
        [DataRow("\t\r  \t  ")]
        public void StringExtensions_General_CleanWhiteSpace_Empty(string mockedString)
        {
            Assert.AreEqual("", mockedString.CleanWhiteSpace(), mockedString);
        }

        [TestMethod]
        [DataRow("Hello World !")]
        [DataRow("Hello World !")]
        [DataRow("  Hello  World    !")]
        [DataRow("Hello\tWorld\t!")]
        [DataRow("Hello\rWorld\r!")]
        [DataRow("\t\r Hello\rWorld \t!  ")]
        public void StringExtensions_General_CleanWhiteSpace_Text(string mockedString)
        {
            Assert.AreEqual("Hello World !", mockedString.CleanWhiteSpace(), mockedString);
        }

        [TestMethod]
        public void StringExtensions_General_RemoveEmptyLines()
        {
            const string crlf = "\r\n";

            var text = $"row1{crlf}row2{crlf}{crlf}row3{crlf}";
            Assert.AreEqual($"row1{crlf}row2{crlf}row3", text.RemoveEmptyLines());
        }

        #endregion

        #region Case

        #region CapitalizeAfterCharacters

        [TestMethod]
        [DataRow("A")]
        [DataRow("A B")]
        [DataRow("Abc def")]
        [DataRow("Abc Def")]
        [DataRow("Abc_def")]
        [DataRow("ABC DEF")]
        [DataRow("I w'nt change. \n NEVER!")]
        public void StringExtensions_General_CapitalizeAfterCharacters_NoTargetCharacters(string mockedValue)
        {
            Assert.AreEqual(mockedValue, mockedValue.CapitalizeAfterCharacters(Enumerable.Empty<char>()));
        }

        [TestMethod]
        public void StringExtensions_General_CapitalizeAfterCharacters_NoTargetCharacters_Minimize()
        {
            Assert.AreEqual("A", "A".CapitalizeAfterCharacters(Enumerable.Empty<char>(), minimizeOtherChar: true));
            Assert.AreEqual("A b", "A B".CapitalizeAfterCharacters(Enumerable.Empty<char>(), minimizeOtherChar: true));
            Assert.AreEqual("Abc def", "Abc def".CapitalizeAfterCharacters(Enumerable.Empty<char>(), minimizeOtherChar: true));
            Assert.AreEqual("Abc def", "Abc Def".CapitalizeAfterCharacters(Enumerable.Empty<char>(), minimizeOtherChar: true));
            Assert.AreEqual("Abc_def", "Abc_def".CapitalizeAfterCharacters(Enumerable.Empty<char>(), minimizeOtherChar: true));
            Assert.AreEqual("Abc def", "ABC DEF".CapitalizeAfterCharacters(Enumerable.Empty<char>(), minimizeOtherChar: true));
            Assert.AreEqual("I would change. \n yes!", "I would change. \n YES!".CapitalizeAfterCharacters(Enumerable.Empty<char>(), minimizeOtherChar: true));
        }

        [TestMethod]
        [DataRow("A")]
        [DataRow("A B")]
        [DataRow("Abc def")]
        [DataRow("Abc Def")]
        [DataRow("Abc_def")]
        [DataRow("ABC DEF")]
        [DataRow("I w'nt change. \n NEVER!")]
        public void StringExtensions_General_CapitalizeAfterCharacters_OneTargetCharacters_Unused(string mockedValue)
        {
            Assert.AreEqual(mockedValue, mockedValue.CapitalizeAfterCharacters(new char[] { 'x' }));
        }

        [TestMethod]
        public void StringExtensions_General_CapitalizeAfterCharacters_OneTargetCharacters_Unused_Minimize()
        {
            Assert.AreEqual("A", "A".CapitalizeAfterCharacters(new char[] { 'x' }, minimizeOtherChar: true));
            Assert.AreEqual("A b", "A B".CapitalizeAfterCharacters(new char[] { 'x' }, minimizeOtherChar: true));
            Assert.AreEqual("Abc def", "Abc def".CapitalizeAfterCharacters(new char[] { 'x' }, minimizeOtherChar: true));
            Assert.AreEqual("Abc def", "Abc Def".CapitalizeAfterCharacters(new char[] { 'x' }, minimizeOtherChar: true));
            Assert.AreEqual("Abc_def", "Abc_def".CapitalizeAfterCharacters(new char[] { 'x' }, minimizeOtherChar: true));
            Assert.AreEqual("Abc def", "ABC DEF".CapitalizeAfterCharacters(new char[] { 'x' }, minimizeOtherChar: true));
            Assert.AreEqual("Abc def", "ABC DEF".CapitalizeAfterCharacters(new char[] { 'x' }, minimizeOtherChar: true));
            Assert.AreEqual("I would change. \n yes!", "I would change. \n YES!".CapitalizeAfterCharacters(new char[] { 'x' }, minimizeOtherChar: true));
        }

        [TestMethod]
        public void StringExtensions_General_CapitalizeAfterCharacters_OneTargetCharacters_Used()
        {
            Assert.AreEqual("A ", "A ".CapitalizeAfterCharacters(new char[] { ' ' }));
            Assert.AreEqual("HELLO ", "HELLO ".CapitalizeAfterCharacters(new char[] { ' ' }));
            Assert.AreEqual("A B", "A b".CapitalizeAfterCharacters(new char[] { ' ' }));
            Assert.AreEqual("Abc Def", "Abc def".CapitalizeAfterCharacters(new char[] { ' ' }));
            Assert.AreEqual("ABC DEF", "ABC DEF".CapitalizeAfterCharacters(new char[] { ' ' }));
            Assert.AreEqual("Abc_Def", "Abc_def".CapitalizeAfterCharacters(new char[] { '_' }));
            Assert.AreEqual("Abc_def-Ghi", "Abc_def-ghi".CapitalizeAfterCharacters(new char[] { '-' }));
            Assert.AreEqual("Abc-DEf-GhI", "Abc-dEf-ghI".CapitalizeAfterCharacters(new char[] { '-' }));
            Assert.AreEqual("Abc   Def   Ghi", "Abc   def   ghi".CapitalizeAfterCharacters(new char[] { ' ' }));
            Assert.AreEqual("I Would Change. \n YES!", "I would change. \n YES!".CapitalizeAfterCharacters(new char[] { ' ' }));
        }

        [TestMethod]
        public void StringExtensions_General_CapitalizeAfterCharacters_OneTargetCharacters_Used_Minimize()
        {
            Assert.AreEqual("A", "A".CapitalizeAfterCharacters(new char[] { ' ' }, minimizeOtherChar: true));
            Assert.AreEqual("Hello ", "HELLO ".CapitalizeAfterCharacters(new char[] { ' ' }, minimizeOtherChar: true));
            Assert.AreEqual("A B", "A b".CapitalizeAfterCharacters(new char[] { ' ' }, minimizeOtherChar: true));
            Assert.AreEqual("Abc Def", "Abc Def".CapitalizeAfterCharacters(new char[] { ' ' }, minimizeOtherChar: true));
            Assert.AreEqual("Abc Def", "ABC DEF".CapitalizeAfterCharacters(new char[] { ' ' }, minimizeOtherChar: true));
            Assert.AreEqual("Abc_Def", "Abc_def".CapitalizeAfterCharacters(new char[] { '_' }, minimizeOtherChar: true));
            Assert.AreEqual("Abc def-Ghi", "Abc def-ghi".CapitalizeAfterCharacters(new char[] { '-' }, minimizeOtherChar: true));
            Assert.AreEqual("Abc-Def-Ghi", "Abc-dEf-ghI".CapitalizeAfterCharacters(new char[] { '-' }, minimizeOtherChar: true));
            Assert.AreEqual("Abc   Def   Ghi", "Abc   def   ghi".CapitalizeAfterCharacters(new char[] { ' ' }, minimizeOtherChar: true));
            Assert.AreEqual("I Would Change. \n Yes!", "I would change. \n YES!".CapitalizeAfterCharacters(new char[] { ' ' }, minimizeOtherChar: true));
        }

        [TestMethod]
        public void StringExtensions_General_CapitalizeAfterCharacters_SeveralTargetCharacters()
        {
            Assert.AreEqual("A", "a".CapitalizeAfterCharacters(new char[] { '-', '+' }));
            Assert.AreEqual("A", "A".CapitalizeAfterCharacters(new char[] { '-', '+' }));
            Assert.AreEqual("A+", "a+".CapitalizeAfterCharacters(new char[] { '-', '+' }));
            Assert.AreEqual("A+", "A+".CapitalizeAfterCharacters(new char[] { '-', '+' }));
            Assert.AreEqual("A-", "a-".CapitalizeAfterCharacters(new char[] { '-', '+' }));
            Assert.AreEqual("A++", "a++".CapitalizeAfterCharacters(new char[] { '-', '+' }));
            Assert.AreEqual("A--", "a--".CapitalizeAfterCharacters(new char[] { '-', '+' }));
            Assert.AreEqual("A+-", "a+-".CapitalizeAfterCharacters(new char[] { '-', '+' }));
            Assert.AreEqual("+A", "+a".CapitalizeAfterCharacters(new char[] { '-', '+' }));
            Assert.AreEqual("++A", "++a".CapitalizeAfterCharacters(new char[] { '-', '+' }));
            Assert.AreEqual("++A++", "++a++".CapitalizeAfterCharacters(new char[] { '-', '+' }));
            Assert.AreEqual("Hello", "hello".CapitalizeAfterCharacters(new char[] { '-', '+' }));
            Assert.AreEqual("HELLO", "HELLO".CapitalizeAfterCharacters(new char[] { '-', '+' }));
            Assert.AreEqual("Hello-Hi-World-!", "hello-hi-world-!".CapitalizeAfterCharacters(new char[] { '-', '+' }));
            Assert.AreEqual("Hello-Hi+World-!", "hello-hi+world-!".CapitalizeAfterCharacters(new char[] { '-', '+' }));
            Assert.AreEqual("HELLO-Hi+World-!", "hELLO-hi+world-!".CapitalizeAfterCharacters(new char[] { '-', '+' }));
            Assert.AreEqual("Hello---Hi++++World-!", "hello---hi++++world-!".CapitalizeAfterCharacters(new char[] { '-', '+' }));
            Assert.AreEqual("Hello---Hi++++World-!", "hello---hi++++world-!".CapitalizeAfterCharacters(new char[] { '-', '+' }));
            Assert.AreEqual("HELLO---HI++++World-!", "hELLO---hI++++world-!".CapitalizeAfterCharacters(new char[] { '-', '+' }));
        }

        [TestMethod]
        public void StringExtensions_General_CapitalizeAfterCharacters_SeveralTargetCharacters_Minimize()
        {
            Assert.AreEqual("Hello", "hello".CapitalizeAfterCharacters(new char[] { '-', '+' }, minimizeOtherChar: true));
            Assert.AreEqual("Hello", "HELLO".CapitalizeAfterCharacters(new char[] { '-', '+' }, minimizeOtherChar: true));
            Assert.AreEqual("Hello-Hi-World-!", "hello-hi-world-!".CapitalizeAfterCharacters(new char[] { '-', '+' }, minimizeOtherChar: true));
            Assert.AreEqual("Hello-Hi+World-!", "hello-hi+world-!".CapitalizeAfterCharacters(new char[] { '-', '+' }, minimizeOtherChar: true));
            Assert.AreEqual("Hello-Hi+World-!", "hELLO-hi+world-!".CapitalizeAfterCharacters(new char[] { '-', '+' }, minimizeOtherChar: true));
            Assert.AreEqual("Hello---Hi++++World-!", "hello---hi++++world-!".CapitalizeAfterCharacters(new char[] { '-', '+' }, minimizeOtherChar: true));
            Assert.AreEqual("Hello---Hi++++World-!", "hello---hi++++world-!".CapitalizeAfterCharacters(new char[] { '-', '+' }, minimizeOtherChar: true));
            Assert.AreEqual("Hello---Hi++++World-!", "hELLO---hI++++world-!".CapitalizeAfterCharacters(new char[] { '-', '+' }, minimizeOtherChar: true));
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("\t")]
        [DataRow("             ")]
        [DataRow("     $ !-- +   )")]
        public void StringExtensions_General_CapitalizeAfterCharacters_StringWithoutLetters(string mockedValue)
        {

            var targetCharactersSets = new char[][]
            {
                new char[] {' '},
                new char[] {'-'},
                new char[] {'\t'},
                new char[] {'-', ' ' , 'a', '\t' },
                new char[] {' ', ' '}
            };
            foreach (var set in targetCharactersSets)
            {
                Assert.AreEqual(mockedValue, mockedValue.CapitalizeAfterCharacters(set), $"String : {mockedValue}, Set : {set}");
            }
        }

        #endregion

        #region CapitalizeAfterCharacter

        [TestMethod]

        [DataRow("")]
        [DataRow(" ")]
        [DataRow("A")]
        [DataRow("A B")]
        [DataRow("Abc def")]
        [DataRow("Abc Def")]
        [DataRow("Abc_def")]
        [DataRow("ABC DEF")]
        [DataRow("I w'nt change. \n NEVER!")]
        public void StringExtensions_General_CapitalizeAfterCharacter_TargetCharacterUnused(string mockedValue)
        {
            Assert.AreEqual(mockedValue, mockedValue.CapitalizeAfterCharacter('x'));
        }

        [TestMethod]
        public void StringExtensions_General_CapitalizeAfterCharacter_OneTargetCharacters_Unused_Minimize()
        {
            Assert.AreEqual("A", "A".CapitalizeAfterCharacter('x', minimizeOtherChar: true));
            Assert.AreEqual("A b", "A B".CapitalizeAfterCharacter('x', minimizeOtherChar: true));
            Assert.AreEqual("Abc def", "Abc def".CapitalizeAfterCharacter('x', minimizeOtherChar: true));
            Assert.AreEqual("Abc def", "Abc Def".CapitalizeAfterCharacter('x', minimizeOtherChar: true));
            Assert.AreEqual("Abc_def", "Abc_def".CapitalizeAfterCharacter('x', minimizeOtherChar: true));
            Assert.AreEqual("Abc def", "ABC DEF".CapitalizeAfterCharacter('x', minimizeOtherChar: true));
            Assert.AreEqual("Abc def", "ABC DEF".CapitalizeAfterCharacter('x', minimizeOtherChar: true));
            Assert.AreEqual("I would change. \n yes!", "I would change. \n YES!".CapitalizeAfterCharacter('x', minimizeOtherChar: true));
        }

        [TestMethod]
        public void StringExtensions_General_CapitalizeAfterCharacter_TargetCharactersUsed()
        {
            Assert.AreEqual(" ", " ".CapitalizeAfterCharacter(' '));
            Assert.AreEqual("A ", "A ".CapitalizeAfterCharacter(' '));
            Assert.AreEqual("HELLO ", "HELLO ".CapitalizeAfterCharacter(' '));
            Assert.AreEqual("A B", "A b".CapitalizeAfterCharacter(' '));
            Assert.AreEqual("Abc Def", "Abc def".CapitalizeAfterCharacter(' '));
            Assert.AreEqual("ABC DEF", "ABC DEF".CapitalizeAfterCharacter(' '));
            Assert.AreEqual("Abc_Def", "Abc_def".CapitalizeAfterCharacter('_'));
            Assert.AreEqual("Abc_def-Ghi", "Abc_def-ghi".CapitalizeAfterCharacter('-'));
            Assert.AreEqual("Abc-DEf-GhI", "Abc-dEf-ghI".CapitalizeAfterCharacter('-'));
            Assert.AreEqual("Abc   Def   Ghi", "Abc   def   ghi".CapitalizeAfterCharacter(' '));
            Assert.AreEqual("I Would Change. \n YES!", "I would change. \n YES!".CapitalizeAfterCharacter(' '));
        }

        [TestMethod]
        public void StringExtensions_General_CapitalizeAfterCharacter_TargetCharacterUsed_Minimize()
        {
            Assert.AreEqual("A", "A".CapitalizeAfterCharacter(' ', minimizeOtherChar: true));
            Assert.AreEqual("Hello ", "HELLO ".CapitalizeAfterCharacter(' ', minimizeOtherChar: true));
            Assert.AreEqual("A B", "A b".CapitalizeAfterCharacter(' ', minimizeOtherChar: true));
            Assert.AreEqual("Abc Def", "Abc Def".CapitalizeAfterCharacter(' ', minimizeOtherChar: true));
            Assert.AreEqual("Abc Def", "ABC DEF".CapitalizeAfterCharacter(' ', minimizeOtherChar: true));
            Assert.AreEqual("Abc_Def", "Abc_def".CapitalizeAfterCharacter('_', minimizeOtherChar: true));
            Assert.AreEqual("Abc def-Ghi", "Abc def-ghi".CapitalizeAfterCharacter('-', minimizeOtherChar: true));
            Assert.AreEqual("Abc-Def-Ghi", "Abc-dEf-ghI".CapitalizeAfterCharacter('-', minimizeOtherChar: true));
            Assert.AreEqual("Abc   Def   Ghi", "Abc   def   ghi".CapitalizeAfterCharacter(' ', minimizeOtherChar: true));
            Assert.AreEqual("I Would Change. \n Yes!", "I would change. \n YES!".CapitalizeAfterCharacter(' ', minimizeOtherChar: true));
        }

        #endregion


        [TestMethod]
        public void StringExtensions_General_CapitalizeEachWord()
        {
            Assert.AreEqual("", "".CapitalizeEachWord());
            Assert.AreEqual(" ", " ".CapitalizeEachWord());
            Assert.AreEqual("HELLO", "hELLO".CapitalizeEachWord(minimizeOtherChar: false));
            Assert.AreEqual("Hello", "hELLO".CapitalizeEachWord(minimizeOtherChar: true));
            Assert.AreEqual("I Would Change. \n YES!", "i would change. \n YES!".CapitalizeEachWord());
            Assert.AreEqual("I Would Change. \n Yes!", "i would change. \n YES!".CapitalizeEachWord(minimizeOtherChar: true));
            Assert.AreEqual("I-would\tChange. \n YES!", "i-would\tchange. \n YES!".CapitalizeEachWord());
        }

        [TestMethod]
        public void StringExtensions_General_CapitalizeEachLine()
        {
            Assert.AreEqual("", "".CapitalizeEachLine());
            Assert.AreEqual("\n", "\n".CapitalizeEachLine());
            Assert.AreEqual("HELLO", "hELLO".CapitalizeEachLine(minimizeOtherChar: false));
            Assert.AreEqual("Hello", "hELLO".CapitalizeEachLine(minimizeOtherChar: true));
            Assert.AreEqual("I would change.\nYES!", "i would change.\nyES!".CapitalizeEachLine());
            Assert.AreEqual("I would change.\nYes!", "i would change.\nyES!".CapitalizeEachLine(minimizeOtherChar: true));
            Assert.AreEqual("I would change.\nYES!", "i would change. \n yES!".CapitalizeEachLine());
            Assert.AreEqual("I would change.\nYes!", "i would change. \n yES!".CapitalizeEachLine(minimizeOtherChar: true));
            Assert.AreEqual("I would change.\nYES!", " i would change.   \n    yES!".CapitalizeEachLine());
        }

        #endregion

        #region Abreviation

        #endregion

        #region Path

        #endregion

        [TestMethod]
        public void StringExtensions_General_RemoveAccents()
        {
            Assert.AreEqual("", "".RemoveAccents());
            Assert.AreEqual(" ", " ".RemoveAccents());
            Assert.AreEqual("e", "e".RemoveAccents());
            Assert.AreEqual("E", "E".RemoveAccents());
            Assert.AreEqual("e", "é".RemoveAccents());
            Assert.AreEqual("E", "É".RemoveAccents());
            Assert.AreEqual("e", "è".RemoveAccents());
            Assert.AreEqual("E", "È".RemoveAccents());
            Assert.AreEqual("e", "ê".RemoveAccents());
            Assert.AreEqual("E", "Ê".RemoveAccents());
            Assert.AreEqual("$@|µ", "$@|µ".RemoveAccents());
            Assert.AreEqual("Loic", "Loïc".RemoveAccents());
            Assert.AreEqual("Gaelle, ma cherie ! Ou va tu comme ca ?", "Gaëlle, ma chérie ! Où va tu comme ça ?".RemoveAccents());
        }

        [TestMethod]
        public void StringExtensions_General_KeepLettersOrDigitsOnly_WithAccent()
        {
            Assert.AreEqual("", "".KeepLettersOrDigitsOnly(withAccentedLetters: true));
            Assert.AreEqual("", " ".KeepLettersOrDigitsOnly(withAccentedLetters: true));
            Assert.AreEqual("Romain", "Romain".KeepLettersOrDigitsOnly(withAccentedLetters: true));
            Assert.AreEqual("Romain1218", "Romain 12-18".KeepLettersOrDigitsOnly(withAccentedLetters: true));
            Assert.AreEqual("Loïc", "Loïc".KeepLettersOrDigitsOnly(withAccentedLetters: true));
            Assert.AreEqual("Loïc1218", "Loïc 12-18".KeepLettersOrDigitsOnly(withAccentedLetters: true));
            Assert.AreEqual("1a2b3céèçàDEF456", "1a2b3c &é\"'(§è!çà)- DEF 456".KeepLettersOrDigitsOnly(withAccentedLetters: true));
        }

        [TestMethod]
        public void StringExtensions_General_KeepLettersOrDigitsOnly_WithoutAccent()
        {
            Assert.AreEqual("", "".KeepLettersOrDigitsOnly(withAccentedLetters: false));
            Assert.AreEqual("", " ".KeepLettersOrDigitsOnly(withAccentedLetters: false));
            Assert.AreEqual("Romain", "Romain".KeepLettersOrDigitsOnly(withAccentedLetters: false));
            Assert.AreEqual("Romain1218", "Romain 12-18".KeepLettersOrDigitsOnly(withAccentedLetters: false));
            Assert.AreEqual("Loc", "Loïc".KeepLettersOrDigitsOnly(withAccentedLetters: false));
            Assert.AreEqual("Loc1218", "Loïc 12-18".KeepLettersOrDigitsOnly(withAccentedLetters: false));
            Assert.AreEqual("1a2b3cDEF456", "1a2b3c &é\"'(§è!çà)- DEF 456".KeepLettersOrDigitsOnly(withAccentedLetters: false));
        }

        [TestMethod]
        public void StringExtensions_General_KeepLettersOnly_WithAccent()
        {
            Assert.AreEqual("", "".KeepLettersOnly(withAccentedLetters: true));
            Assert.AreEqual("", " ".KeepLettersOnly(withAccentedLetters: true));
            Assert.AreEqual("Romain", "Romain".KeepLettersOnly(withAccentedLetters: true));
            Assert.AreEqual("Romain", "Romain 12-18".KeepLettersOnly(withAccentedLetters: true));
            Assert.AreEqual("Loïc", "Loïc".KeepLettersOnly(withAccentedLetters: true));
            Assert.AreEqual("Loïc", "Loïc 12-18".KeepLettersOnly(withAccentedLetters: true));
            Assert.AreEqual("abcéèçàDEF", "1a2b3c &é\"'(§è!çà)- DEF 456".KeepLettersOnly(withAccentedLetters: true));
        }

        [TestMethod]
        public void StringExtensions_General_KeepLettersOnly_WithoutAccent()
        {
            Assert.AreEqual("", "".KeepLettersOnly(withAccentedLetters: false));
            Assert.AreEqual("", " ".KeepLettersOnly(withAccentedLetters: false));
            Assert.AreEqual("Romain", "Romain".KeepLettersOnly(withAccentedLetters: false));
            Assert.AreEqual("Romain", "Romain 12-18".KeepLettersOnly(withAccentedLetters: false));
            Assert.AreEqual("Loc", "Loïc".KeepLettersOnly(withAccentedLetters: false));
            Assert.AreEqual("Loc", "Loïc 12-18".KeepLettersOnly(withAccentedLetters: false));
            Assert.AreEqual("abcDEF", "1a2b3c &é\"'(§è!çà)- DEF 456".KeepLettersOnly(withAccentedLetters: false));
        }

        [TestMethod]
        public void StringExtensions_General_KeepFirstLetterOnly()
        {
            Assert.AreEqual(null, "".KeepFirstLetterOnly());
            Assert.AreEqual(null, "125".KeepFirstLetterOnly());
            Assert.AreEqual('A', "A".KeepFirstLetterOnly());
            Assert.AreEqual('A', " A!".KeepFirstLetterOnly());
            Assert.AreEqual('R', "Romain".KeepFirstLetterOnly());
            Assert.AreEqual('G', "Gaëlle, ma chérie ! ".KeepFirstLetterOnly());
            Assert.AreEqual('À', "À demain".KeepFirstLetterOnly());
            Assert.AreEqual('s', "50% sur TOUT".KeepFirstLetterOnly());
        }

        [TestMethod]
        public void StringExtensions_General_KeepLastLetterOnly()
        {
            Assert.AreEqual(null, "".KeepLastLetterOnly());
            Assert.AreEqual(null, "125".KeepLastLetterOnly());
            Assert.AreEqual('A', "A".KeepLastLetterOnly());
            Assert.AreEqual('A', " A!".KeepLastLetterOnly());
            Assert.AreEqual('n', "Romain".KeepLastLetterOnly());
            Assert.AreEqual('e', "Gaëlle, ma chérie ! ".KeepLastLetterOnly());
            Assert.AreEqual('à', "C'est là ! ".KeepLastLetterOnly());
            Assert.AreEqual('à', "Soldes : tout à 50%".KeepLastLetterOnly());
        }




        [TestMethod]
        public void StringExtensions_General_Repeat()
        {
            Assert.AreEqual(null, "".Repeat(-1));
            Assert.AreEqual("", "".Repeat(0));

            Assert.AreEqual(null, "A".Repeat(-1));
            Assert.AreEqual("", "A".Repeat(0));
            Assert.AreEqual("A", "A".Repeat(1));
            Assert.AreEqual("AAA", "A".Repeat(3));

            Assert.AreEqual(null, "Hello world!".Repeat(-1));
            Assert.AreEqual("", "Hello world!".Repeat(0));
            Assert.AreEqual("Hello world!", "Hello world!".Repeat(1));
            Assert.AreEqual("Hello world!Hello world!Hello world!", "Hello world!".Repeat(3));
        }

        #endregion







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
    }
}
