using System;
using System.Collections.Generic;
using System.Linq;
using TextUtil.Interfaces;

namespace TextUtil
{
    public class WordCounter : IWordCounter
    {
        private readonly ITextSplitter _splitter;

        public static readonly char[] WordSeparators = { '.', '?', '!', ' ', ';', ':', ',', '\r', '\n' };
        
        public WordCounter(ITextSplitter splitter)
        {
            _splitter = splitter;
        }

        public IEnumerable<WordCount> GetWordCounts(string text)
        {
            // Use our internal list of word separators

            return GetWordCounts(text, WordSeparators);
        }
        
        public IEnumerable<WordCount> GetWordCounts(string text, char[] separators)
        {
            // This overload method allows users to pass their own separator list (eg. they can add symbols also as word separators)

            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            // splitter just splits a sentence into words

            var words = _splitter.GetWords(text, separators);

            var wordGroups = words.GroupBy(t => t.ToLowerInvariant());

            return wordGroups.Select(wordGroup => new WordCount(wordGroup.Key, wordGroup.Count()));
        }
    }
}
