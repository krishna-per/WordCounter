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

            // TODO - Add our own word parsing logic here - by looping through the text and test each char 
            // To be done later, now the important thing is to show the usage of Strategy pattern.
            // Internal implementation can remain simple, for now we will use string.split.

            // Using this kind of parse split, we can add event based parsing to avoid storing all words in memory at once, 
            // which would help when dealing with large text. But that depends on the end usage of splitter. 

            return text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}