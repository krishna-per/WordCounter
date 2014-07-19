namespace TextUtil.Interfaces
{
    public class WordCount
    {
        public WordCount(string word, int count)
        {
            Word = word;
            Count = count;
        }

        public string Word { get; private set; }

        public int Count { get; private set; }
    }
}