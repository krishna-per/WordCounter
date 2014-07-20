using System;
using System.Collections.Generic;
using TextUtil.Interfaces;

namespace TextUtil.Tests
{
    // Not using any mocking frameworks (Rhino Mocks, Moq or NMock) in this project.
    // So we will use our own mock class which will use simple string.split method for splitting.

    // This is to keep the WordCounterTest independent of actual Splitter implementations which have separate tests.

    public class TextSplitterMock : ITextSplitter
    {
        public IEnumerable<string> GetWords(string text, char[] separators)
        {
            return text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}