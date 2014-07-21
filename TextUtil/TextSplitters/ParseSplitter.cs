using System;
using System.Collections.Generic;
using System.Linq;
using TextUtil.Interfaces;

namespace TextUtil.TextSplitters
{
    public class ParseSplitter : ITextSplitter
    {
        public IEnumerable<string> GetWords(string text, char[] separators)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            if (separators == null)
            {
                throw new ArgumentNullException("separators");
            }

            if (separators.Count() == 0)
            {
                throw new InvalidOperationException("Atleast one separator must be specified");
            }

            var words = new List<string>();
            var start = 0;
            for (var n = 0; n < text.Length; n++)
            {
                if (separators.Contains(text[n]))
                {
                    if (n > start)
                    {
                        words.Add(text.Substring(start, n - start));
                    }

                    start = n + 1;
                }

                if (n == text.Length - 1) // end of text
                {
                    if (n > start)
                    {
                        words.Add(text.Substring(start, n - start + 1));
                    }
                }
            }

            // Using this kind of parse split, we can add event based parsing to avoid storing all words in memory at once, 
            // which would help when dealing with large text. But that depends on the end usage of splitter. 

            return words;
        }
    }
}