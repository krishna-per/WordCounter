using System.Collections.Generic;

namespace TextUtil.Interfaces
{
    public interface IWordCounter
    {
        IEnumerable<WordCount> GetWordCounts(string text);

        IEnumerable<WordCount> GetWordCounts(string text, char[] separators);
    }
}