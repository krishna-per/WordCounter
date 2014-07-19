using System;
using System.Linq;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using TextUtil.Di;
using TextUtil.Interfaces;

namespace TextUtil.Tests
{
    // This test class shows the flow of TDD process. 
    
    // 1. First create TextUtil.Tests project and this TDD_WordCounterTests class
    // 2. Then create TextUtil project where the word counting classes will be created
    // 3. Then TDD as shown in this test class

    [TestFixture]
    public  class WordCounterTest
    {
        private IWordCounter _wordCounter;

        [TestFixtureSetUp]
        public void Setup()
        {
            // Not using any mocking frameworks in this project, so lets use our own mock object

            var textSplitter = new TextSplitterMock();

            _wordCounter = DiUnity.Container.Resolve<IWordCounter>(new DependencyOverride<ITextSplitter>(textSplitter));
        }

        [Test]
        public void ShouldCreateWordCounter()
        {
            // First we need to create an object that does the word counting.
            // First line of code in this project was this -> var wordCounter = new WordCounter(); 
            // But later this line got refactored to push the actual object creation to derived classes (possibly later by Dependency Injection framework)

            // WordCounter object should have been created
            Assert.IsNotNull(_wordCounter);

            // DEV: Add an empty class WordCounter now 
            //public class WordCounter
            //{
            //}

            // TEST: Run the test after DEV change, it should pass.
        }

        // We need a method on the WordCounter object that does word counting.
        // This method will take in a sentence and will return a list of word-counts.
        // Return type could be a list of KeyValuePairs or Tuples, but let's use a new type WordCount for better readability/clarity
        // DEV: Add class WordCount now
        [Test]
        public void ShouldBeZeroCountForEmptyText()
        {
            // pass an empty string, get an empty list of WordCounts
            var wordCounts = _wordCounter.GetWordCounts(string.Empty);

            Assert.AreEqual(0, wordCounts.Count());

            // DEV: Add GetWordCounts method that does nothing, but return empty list of WordCounts
            //public IEnumerable<WordCount> GetWordCounts(string text)
            //{
            //    return new List<WordCount>();
            //}

            // TEST: Run the test, it should pass.
        }

        [Test]
        [ExpectedException(typeof (ArgumentNullException))]
        public void ShouldThrowExceptionForNullText()
        {
            _wordCounter.GetWordCounts(null);
            
            // DEV: Add param check and throw exception in the method
            
            // TEST: Run the test, it should pass.
        }

        // Let's test and dev the method for a single word sentence
        [Test]
        public void ShouldBeOneCountForSingleWord()
        {
            var wordCounts = _wordCounter.GetWordCounts("Hello").ToArray();

            // There should be only one count for the word.
            Assert.AreEqual(1, wordCounts.Count());
            Assert.AreEqual("hello", wordCounts.First().Word);
            Assert.AreEqual(1, wordCounts.First().Count);

            // TEST: Run the test, it will fail. 
            
            // DEV: One word doesn't need an actual word-count logic, so change the method to return one WordCount for the passed-in word
            // DEV: Make sure the above test for empty sentence also passes by checking for empty sentence and handling it separately
            //public IEnumerable<WordCount> GetWordCounts(string text)
            //{
            //    ...
            //    var wordCounts = new List<WordCount>();
            //    if (!string.IsNullOrEmpty(text))
            //    {
            //        wordCounts.Add(new WordCount(text, 1));
            //    }
            //    return  wordCounts;
            //}

            // TEST: Run this and all the above tests after this DEV change, all should pass
        }

        // Lets test and dev the method for two different words
        [Test]
        public void ShouldBeTwoCountsForTwoDifferentWords()
        {
            var wordCounts = _wordCounter.GetWordCounts("Hello Counter").ToArray();

            // There should be one count for each word.
            Assert.AreEqual(2, wordCounts.Count());
            Assert.AreEqual("hello", wordCounts.First().Word);
            Assert.AreEqual(1, wordCounts.First().Count);
            Assert.AreEqual("counter", wordCounts.ElementAt(1).Word);
            Assert.AreEqual(1, wordCounts.ElementAt(1).Count);

            // TEST: Run the test, it will fail

            // DEV: Change the method to simply return the number of words in the sentence (i.e. without repetition check). Make sure empty sentence test also would pass.
            //public IEnumerable<WordCount> GetWordCounts(string text)
            //{
            //    ...
            //    var wordCounts = new List<WordCount>();
            //    var words = text.Split(new []{ ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //    wordCounts.AddRange(words.Select(word => new WordCount(word, 1)));
            //    return  wordCounts;
            //}

            // TEST: Run this and all the above tests after this DEV change, all should pass
        }

        // Lets test and dev for two same words - i.e. for the actual repetition count logic
        [Test]
        public void ShouldBeOneCountForTwoSameWords()
        {
            var wordCounts = _wordCounter.GetWordCounts("Hello Hello").ToArray();

            // There should only one count for one word
            Assert.AreEqual(1, wordCounts.Count());
            Assert.AreEqual("hello", wordCounts.First().Word);
            Assert.AreEqual(2, wordCounts.First().Count); // but two occurances of the same word

            // TEST: Run the test, it will fail

            // DEV: Add actual word-count logic that checks for repetition as well
            //public IEnumerable<WordCount> GetWordCounts(string text)
            //{
            //    ...
            //    var words = text.Split(new []{ ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //    var wordGroups = words.GroupBy(t => t);
            //    return wordGroups.Select(wordGroup => new WordCount(wordGroup.Key, wordGroup.Count()));
            //}

            // TEST: Run this and all the above tests after this DEV change, all should pass
        }

        //Lets test and dev for case sensitivity
        [Test]
        public void ShouldIgnoreCase()
        {
            var wordCounts = _wordCounter.GetWordCounts("Hello hello hELlo").ToArray();
            
            Assert.AreEqual(1, wordCounts.Count());
            Assert.AreEqual("hello", wordCounts.First().Word);
            Assert.AreEqual(3, wordCounts.First().Count); // but two occurances of the same word

            // TEST: Run the test, it will fail

            // DEV: Fix word count logic to ignore cases
            //public IEnumerable<WordCount> GetWordCounts(string text)
            //{
            //    ...
            //    var words = text.Split(new []{ ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //    var wordGroups = words.GroupBy(t => t.ToLowerInvariant());
            //    return wordGroups.Select(wordGroup => new WordCount(wordGroup.Key, wordGroup.Count()));
            //}

            // TEST: After this change, most of the previous tests fail, because now the method retuns words in lower case. Fix the above test cases.

            // TEST: Run this and all the above tests after this DEV change, all should pass
        }

        // What if the words have punctuation letters? 
        // e.g. Hello! Hello, Hello? Hello: Hello. Hello; Hello - This should be taken as one word - seven occurances
        // Lets test and dev for words with punctuation chars.
        [Test]
        public void ShouldHanldePunctuations()
        {
            var wordCounts = _wordCounter.GetWordCounts("Hello! Hello, Hello? Hello: Hello. Hello; Hello").ToArray();

            Assert.AreEqual(1, wordCounts.Count());
            Assert.AreEqual("hello", wordCounts.First().Word);
            Assert.AreEqual(7, wordCounts.First().Count);

            // TEST: Run the test, it will fail

            // DEV: Add these puntuation chars as separators in addition to space.
            // var words = text.Split(new [] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

            // TEST: Run this and all the above tests after this DEV change, all should pass
        }

        // Lets test for new line chars in the sentence
        [Test]
        public void ShouldHanldeNewLineSeparators()
        {
            var wordCounts = _wordCounter.GetWordCounts("Hello\nHello\nHello\n").ToArray();

            Assert.AreEqual(1, wordCounts.Count());
            Assert.AreEqual("hello", wordCounts.First().Word);
            Assert.AreEqual(3, wordCounts.First().Count);

            // TEST: Run the test, it will fail

            // DEV: Add new line also as a separator.
            // var words = text.Split(new [] { '.', '?', '!', ' ', ';', ':', ',', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // TEST: Run this and all the above tests after this DEV change, all should pass
        }

        // So far users are restricted for WordCounter's internal list of separators only.
        // For custom situations that might arise with users, lets facilitate for user to pass his own list of separators.
        [Test]
        public void ShouldUseUserGivenSeparators()
        {
            var userSeparators = new [] { '.', '?', '!', ' ', ';', ':', ',', '\n' };

            var wordCounts = _wordCounter.GetWordCounts("Hello! Hello, Hello? Hello: Hello. Hello; Hello Hello\nHello\nHello\n", userSeparators).ToArray();

            Assert.AreEqual(1, wordCounts.Count());
            Assert.AreEqual("hello", wordCounts.First().Word);
            Assert.AreEqual(10, wordCounts.First().Count);

            // DEV: Add an overload method for GetWordCounts that takes an additional param for separators
            // DEV: Refactor the code so that both methods reuses the same common code section

            // TEST: Run this and all the above tests after this DEV change, all should pass
        }

        // Currently we use string.split method to parse the sentence into words.
        // But there are other efficient ways of doing this like using RegEx and our own loop-n-parse
        // Strategy pattern can be used for this - the WordCounter can use different strategies to split sentence into words.

        // DEV: Refactor the code. Separate the split part from WordCounter class and replace it with an abstraction/interface ITextSplitter
        // DEV: Add new WordCounter constructor that takes an ITextSplitter instance. Can use this for Dependency Injection.
        // DEV: Create new ITextSplitter interface and create three strategy classes that implements ITextSplitter.

        // TEST: Now the TDD flow (test and dev process) moves to the SplitterTests

        // TEST: Run all the tests after this DEV change, all should pass
    }
}
