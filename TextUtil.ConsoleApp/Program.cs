using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using TextUtil.Di;
using TextUtil.Interfaces;

namespace TextUtil.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var splitter = DiUnity.Container.Resolve<ITextSplitter>("StringSplitter");

            var wordCounter = DiUnity.Container.Resolve<IWordCounter>(new DependencyOverride<ITextSplitter>(splitter));

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Enter a sentence (enter 'exit' to exit):");
                var sentence = Console.ReadLine();

                if (sentence != null)
                {
                    if(sentence.ToLower() == "exit") break;

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
}
