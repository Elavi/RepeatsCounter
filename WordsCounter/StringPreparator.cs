using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordsCounter
{
    public class StringPreparator : IStringPreparator
    {
        public Dictionary<string, int> CalculateWordsCount(string sentence)
        {
            var dictionary = new Dictionary<string, int>();
            sentence = this.MakeLower(sentence);
            sentence = this.Trim(sentence);
            sentence = this.RemoveSpecialChars(sentence);

            string[] words = sentence.Split(' ');
            foreach(var word in words)
            {
                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, 1);
                }
                else
                {
                    dictionary[word]++;
                }
            }
            dictionary = this.SortByCount(dictionary);
            return dictionary;
        }

        public string MakeLower(string text)
        {
            return text.ToLowerInvariant();
        }

        public string RemoveSpecialChars(string text)
        {
            var regex = @"[^\w\s]";
            var result = Regex.Replace(text, regex, "");
            var regex2 = @"(\r\n|\r|\n)";
            result = Regex.Replace(result, regex2, " ");
            var regex3 = @"[ ]{2,}";
            result = Regex.Replace(result, regex3, " ");
            return result;
        }

        public Dictionary<string, int> SortByCount(Dictionary<string, int> wordsCounts)
        {
            return wordsCounts.OrderByDescending(a => a.Value).ToDictionary( a => a.Key, b => b.Value);
        }
        
        public string Trim(string text)
        {
            return text.Trim();
        }
    }
}
