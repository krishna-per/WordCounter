using System;
using System.Collections.Generic;
using System.Globalization;
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

            // Make regex pattern with the separators
            var separatorStrings = separators.Select(c => c.ToString(CultureInfo.InvariantCulture)).ToArray();
            var pattern = "(" + string.Join("|", separatorStrings.Select(Regex.Escape)) + ")";

            // regex split result includes the separators as well, remove them and empty strings and then rerun
            return Regex.Split(text, pattern).Where(s => !separatorStrings.Contains(s) && s.Length > 0);
            
            //var regex = new Regex("[\\w]+", RegexOptions.Multiline | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            //return regex.Matches(text).Cast<object>().Select(m => m.ToString());
        }
    }
}