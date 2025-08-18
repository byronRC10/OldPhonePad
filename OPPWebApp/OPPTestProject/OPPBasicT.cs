using Xunit;
using OPPClassLibrary;

namespace OPPTestProject
{
    public class OPPBasicT
    {
        [Theory]
        // Key 1
        [InlineData("1", "&")]
        [InlineData("11", "'")]
        [InlineData("111", "(")]
        [InlineData("1111", ")")]

        // Key 2
        [InlineData("2", "A")]
        [InlineData("22", "B")]
        [InlineData("222", "C")]

        // Key 3
        [InlineData("3", "D")]
        [InlineData("33", "E")]
        [InlineData("333", "F")]

        // Key 4
        [InlineData("4", "G")]
        [InlineData("44", "H")]
        [InlineData("444", "I")]

        // Key 5
        [InlineData("5", "J")]
        [InlineData("55", "K")]
        [InlineData("555", "L")]

        // Key 6
        [InlineData("6", "M")]
        [InlineData("66", "N")]
        [InlineData("666", "O")]

        // Key 7
        [InlineData("7", "P")]
        [InlineData("77", "Q")]
        [InlineData("777", "R")]
        [InlineData("7777", "S")]

        // Key 8
        [InlineData("8", "T")]
        [InlineData("88", "U")]
        [InlineData("888", "V")]

        // Key 9
        [InlineData("9", "W")]
        [InlineData("99", "X")]
        [InlineData("999", "Y")]
        [InlineData("9999", "Z")]

        // Key 0 and space
        [InlineData("0", " ")]

        // Combined sequences
        [InlineData("33#", "E")]                 // '#' ignored
        [InlineData("227*#", "B")]               // '*' clears sequence
        [InlineData("4433555 555666#", "HELLO")] // mixed spaces and '#'
        [InlineData("8 88777444666*664#", "TURING")] // complex sequence with '*', '#'

        public void ProcessOldPhonePad_ValidInputs_ReturnsExpected(string input, string expected)
        {
            // Act
            string result = OldPhonePad.ProcessOldPhonePad(input);

            // Assert
            Assert.Equal(expected, result);
        }

    }// class

}// namespace