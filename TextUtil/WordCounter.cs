using System;
using System.Collections.Generic;
using System.Linq;
using TextUtil.Interfaces;

namespace TextUtil
{
    public class WordCounter : IWordCounter
    {
        private readonly ITextSplitter _splitter;

        private static readonly char[] Separators = { '.', '?', '!', ' ', ';', ':', ',', '\r', '\n' };
        
        public WordCounter(ITextSplitter splitter)
        {
            _splitter = splitter;
        }

        public IEnumerable<WordCount> GetWordCounts(string text)
        {
            return GetWordCounts(text, Separators);
        }

        public IEnumerable<WordCount> GetWordCounts(string text, char[] separators)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            var words = _splitter.GetWords(text, separators);

            var wordGroups = words.GroupBy(t => t.ToLowerInvariant());

            return wordGroups.Select(wordGroup => new WordCount(wordGroup.Key, wordGroup.Count()));
        }
    }
}
