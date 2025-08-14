
namespace OldPhonePadC
{
    internal class Data
    {
        public static readonly Dictionary<char, char[]> Keys = new Dictionary<char, char[]>
        {
            { '1', new char[] { '&', '\'', '(', ')' } },
            { '2', new char[] { 'A', 'B', 'C' } },
            { '3', new char[] { 'D', 'E', 'F' } },
            { '4', new char[] { 'G', 'H', 'I' } },
            { '5', new char[] { 'J', 'K', 'L' } },
            { '6', new char[] { 'M', 'N', 'O' } },
            { '7', new char[] { 'P', 'Q', 'R', 'S' } },
            { '8', new char[] { 'T', 'U', 'V' } },
            { '9', new char[] { 'W', 'X', 'Y', 'Z' } },
            { '0', new char[] { ' ' } },
            { '*', new char[] { '*' } },
            { '#', new char[] { '#' } }
        }; // data for simulate 

        public static char[] GetKeyChars(char key)
        {
            if (Keys.ContainsKey(key))
                return Keys[key];
            return new char[0];
        }// get key

        public static char GetCharAt(char key, int index)
        {
            var chars = GetKeyChars(key);
            if (index >= 0 && index < chars.Length)
                return chars[index];
            return '\0'; 
        }// get char

    }// class

}// namesp
