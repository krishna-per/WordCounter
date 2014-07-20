using System;
using System.Linq;
using Microsoft.Practices.Unity;
using TextUtil.Factory;
using TextUtil.Interfaces;

namespace TextUtil.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var splitter = Unity.Container.Resolve<ITextSplitter>("StringSplitter");

            var wordCounter = Unity.Container.Resolve<IWordCounter>(new DependencyOverride<ITextSplitter>(splitter));

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Enter a sentence (enter 'exit' to exit):");
                var sentence = Console.ReadLine();

                if (sentence == null || sentence.ToLower() == "exit") break;

                var wordCounts = wordCounter.GetWordCounts(sentence).ToArray();

                Console.WriteLine("Total distinct words: " + wordCounts.Count());

                foreach (var word in wordCounts)
                {
                    Console.WriteLine("{0} - {1}", word.Word, word.Count);
                }
            }
        }
    }
}
