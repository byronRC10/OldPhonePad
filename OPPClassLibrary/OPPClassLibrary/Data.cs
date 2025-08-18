using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPPClassLibrary
{
    public class Data
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
            if (!Keys.ContainsKey(key))
                throw new ArgumentException($"The key '{key}' is not valid.");
            return Keys[key];
        }// getKeyChars

        public static char GetCharAt(char key, int index)
        {
            var chars = GetKeyChars(key); // throws exception if key is invalid

            if (index < 0 || index >= chars.Length)
                throw new IndexOutOfRangeException($"Index {index} is out of range for key '{key}'.");

            return chars[index];
        }// getCharAt

    }// class

}// namespace
