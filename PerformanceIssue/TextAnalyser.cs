using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;

namespace PerformanceIssue.Core
{
    public class TextAnalyser
    { 
        private object resourceLock = new object();
        
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

        public int SolutionImproved(string text)
        {
            if (!ValidateInput(text))
            {
                return -1;
            }

            int uniqueCount = GetUniqueLettersCount(text);
            List<string> substrings = null;

            for (int l = 1; l < text.Length; l++)
            {
                substrings = GetAllSubstrings(text, l);
                                
                for (int i = 0; i < substrings.Count; i++)
                {
                    uniqueCount += GetUniqueLettersCount(substrings[i]);
                }
            }

            return uniqueCount;
        }
        
        public int SolutionMultiThread(string text)
        {
            if (!ValidateInput(text))
            {
                return -1;
            }

            int totalCount = GetUniqueLettersCount(text);

            Parallel.For(1, text.Length, (length) =>
            {
                List<string> substrings = GetAllSubstrings(text, length);

                for (int i = 0; i < substrings.Count; i++)
                {
                    int count = GetUniqueLettersCount(substrings[i]);

                    lock (resourceLock)
                    {
                        totalCount += count;
                    }
                }
            });

            return totalCount;
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

        private List<string> GetAllSubstrings(string text, int substringLength)
        {
            List<string> substrings = new List<string>();

            for (int start = 0; start <= text.Length - substringLength; start++)
            {
                string substring = text.Substring(start, substringLength);
                substrings.Add(substring);
            }

            return substrings;
        }

        private bool ValidateInput(string input)
        {
            const int MinLength = 4;
            const int MaxLength = (int) 1E5;
            const string ValidationPattern = "^[A-Z]+$";

            if (input == null || input.Length < MinLength || input.Length > MaxLength ||
                !Regex.IsMatch(input, ValidationPattern))
            {
                return false;
            }

            return true;
        }
    }
}
