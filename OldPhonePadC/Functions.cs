
namespace OldPhonePadC
{
    internal class Functions
    {
        public static string ProcessOldPhonePad(string input)
        {
            List<string> resultList = ProcessInputToList(input);
            List<char> translated = TranslateToLetters(resultList);
            string finalString = JoinTranslatedLetters(translated);
            return finalString;
        }// process main method

        private static List<string> ProcessInputToList(string input)
        {
            List<string> list = new List<string>();
            string current = "";

            foreach (char c in input)
            {
                if (c == '#')
                {
                    continue;
                }
                else if (c == ' ')
                {
                    if (!string.IsNullOrEmpty(current))
                    {
                        list.Add(current);
                        current = "";
                    }
                }
                else if (c == '*')
                {
                    current = "";
                }
                else
                {
                    if (current.Length > 0 && current[current.Length - 1] != c)
                    {
                        list.Add(current);
                        current = c.ToString();
                    }
                    else
                    {
                        current += c;
                    }
                }
            }
            if (!string.IsNullOrEmpty(current))
            {
                list.Add(current);
            }

            return list;
        }// process input

        public static List<char> TranslateToLetters(List<string> inputList)
        {
            List<char> letters = new List<char>();

            foreach (string s in inputList)
            {
                if (string.IsNullOrEmpty(s))
                    continue;

                char key = s[0];
                int presses = s.Length;

                char translated = Data.GetCharAt(key, presses - 1);
                letters.Add(translated);
            }

            return letters;
        }// translate

        public static string JoinTranslatedLetters(List<char> letters)
        {
            if (letters == null || letters.Count == 0)
                return "";

            return string.Concat(letters);
        }// join

    }// class

}// namespace..
