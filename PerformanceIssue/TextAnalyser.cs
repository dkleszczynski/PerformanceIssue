using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PerformanceIssue
{
    class TextAnalyser
    {
        public int Solution(string text)
        {
            if (!ValidateInput(text))
            {
                return -1;
            }

            int uniqueCount = GetUniqueLettersCount(text);
            List<string> substrings = GetAllSubstrings(text);

            for (int i = 0; i < substrings.Count; i++)
            {
                uniqueCount += GetUniqueLettersCount(substrings[i]);
            }

            return uniqueCount;
        }

        private int GetUniqueLettersCount(string S)
        {
            char[] chars = S.ToCharArray();
            HashSet<char> unique = new HashSet<char>();
            HashSet<char> duplicates = new HashSet<char>();

            for (int i = 0; i < chars.Length; i++)
            {
                if (duplicates.Contains(chars[i]))
                {
                    continue;
                }

                if (unique.Contains(chars[i]))
                {
                    duplicates.Add(chars[i]);
                    unique.Remove(chars[i]);
                    continue;
                }

                unique.Add(chars[i]);
            }

            return unique.Count;
        }

        private List<string> GetAllSubstrings(string text)
        {
            List<string> substrings = new List<string>();

            for (int length = 1; length < text.Length; length++)
            {
                for (int start = 0; start <= text.Length - length; start++)
                {
                    string substring = text.Substring(start, length);
                    substrings.Add(substring);
                }
            }

            return substrings;
        }

        private bool ValidateInput(string S)
        {
            if (S == null || S.Length < 4 || S.Length > 100000 ||
                !Regex.IsMatch(S, "^[A-Z]+$"))
            {
                return false;
            }

            return true;
        }
    }
}
