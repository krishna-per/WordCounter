using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TextUtil.Interfaces;

namespace TextUtil.TextSplitters
{
    public class RegexSplitter : ITextSplitter
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

            // TODO - Use separators in regex pattern - to be done later. But currently \w pattern already supports most of the word separators.

            // var regex = new Regex(@"[A-Za-z0-9]+");

            var regex = new Regex("[\\w]+", RegexOptions.Multiline | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            
            return regex.Matches(text).Cast<object>().Select(m => m.ToString());
        }
    }
}