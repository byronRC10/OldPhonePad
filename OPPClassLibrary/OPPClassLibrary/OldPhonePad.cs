using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPPClassLibrary
{
    public class OldPhonePad
    {
            public static string ProcessOldPhonePad(string input)
            {
                if (input == null)
                    throw new ArgumentNullException(nameof(input), "Input cannot be null.");

                // Normalize input: remove unexpected characters
                input = input.Trim();

                List<string> resultList = ProcessInputToList(input);
                List<char> translated = TranslateToLetters(resultList);
                string finalString = JoinTranslatedLetters(translated);
                return finalString;
            }

            private static List<string> ProcessInputToList(string input)
            {
                List<string> list = new List<string>();
                string current = "";

                foreach (char c in input)
                {
                    switch (c)
                    {
                        case '#':
                            // ignore
                            break;

                        case ' ':
                            if (!string.IsNullOrEmpty(current))
                            {
                                list.Add(current);
                                current = "";
                            }
                            break;

                        case '*':
                            // clear current sequence
                            current = "";
                            break;

                        default:
                            if (!char.IsDigit(c))
                                throw new ArgumentException($"Invalid character '{c}' in input. Only digits 0-9, '*', '#', and space are allowed.");

                            if (current.Length > 0 && current[current.Length - 1] != c)
                            {
                                list.Add(current);
                                current = c.ToString();
                            }
                            else
                            {
                                current += c;
                            }
                            break;
                    }
                }

                if (!string.IsNullOrEmpty(current))
                {
                    list.Add(current);
                }

                return list;
            }

            public static List<char> TranslateToLetters(List<string> inputList)
            {
                if (inputList == null)
                    throw new ArgumentNullException(nameof(inputList), "Input list cannot be null.");

                List<char> letters = new List<char>();

                foreach (string s in inputList)
                {
                    if (string.IsNullOrEmpty(s))
                        continue;

                    char key = s[0];
                    int presses = s.Length;

                    // Adjust presses for keys with limited characters
                    if (!Data.Keys.ContainsKey(key))
                        throw new ArgumentException($"Invalid key '{key}' in sequence '{s}'.");

                    int maxPresses = Data.Keys[key].Length;
                    if (presses > maxPresses)
                        presses = maxPresses; // wrap or cap at max available character

                    char translated = Data.GetCharAt(key, presses - 1);
                    letters.Add(translated);
                }

                return letters;
            }

            public static string JoinTranslatedLetters(List<char> letters)
            {
                if (letters == null)
                    throw new ArgumentNullException(nameof(letters), "Letters list cannot be null.");

                return string.Concat(letters);
            }

    }// class

}// namespace
