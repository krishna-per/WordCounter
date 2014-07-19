using System.Collections.Generic;

namespace TextUtil.Interfaces
{
    public interface ITextSplitter
    {
        IEnumerable<string> GetWords(string text, char[] separators);
    }
}