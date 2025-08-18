using OPPClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OPPTestProject
{
    public class OPPExpT
    {
        [Fact]
        public void ProcessOldPhonePad_NullInput_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => OldPhonePad.ProcessOldPhonePad((string)null));
        }

        [Theory]
        [InlineData("A")]      // invalid letter
        [InlineData("!")]      // invalid symbol
        [InlineData("2B2")]    // invalid combination
        public void ProcessOldPhonePad_InvalidCharacter_ThrowsArgumentException(string input)
        {
            Assert.Throws<ArgumentException>(() => OldPhonePad.ProcessOldPhonePad(input));
        }

        [Fact]
        public void Data_GetCharAt_InvalidIndex_ThrowsIndexOutOfRangeException()
        {
            // '2' has 3 letters, index 3 is out of range
            Assert.Throws<IndexOutOfRangeException>(() => Data.GetCharAt('2', 3));
        }

        [Fact]
        public void Data_GetKeyChars_InvalidKey_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Data.GetKeyChars('X'));
        }

        [Fact]
        public void TranslateToLetters_NullList_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => OldPhonePad.TranslateToLetters((List<string>)null));
        }

        [Fact]
        public void JoinTranslatedLetters_NullList_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => OldPhonePad.JoinTranslatedLetters((List<char>)null));
        }
    }
}
