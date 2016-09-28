using System.Collections.Generic;

namespace WordsCounter
{
    public interface IStringPreparator
    {
        string MakeLower(string text);
        string Trim(string text);
        string RemoveSpecialChars(string text);
        Dictionary<string, int> CalculateWordsCount(string sentence);
        Dictionary<string, int> SortByCount(Dictionary<string, int> wordsCounts);
    }
}
