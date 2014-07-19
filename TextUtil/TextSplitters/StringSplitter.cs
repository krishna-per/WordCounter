using System;
using System.Collections.Generic;
using System.Linq;
using TextUtil.Interfaces;

namespace TextUtil.TextSplitters
{
    public class StringSplitter : ITextSplitter
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

            return text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}