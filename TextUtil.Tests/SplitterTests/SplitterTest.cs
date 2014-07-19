using System;
using System.Linq;
using NUnit.Framework;
using TextUtil.Interfaces;

namespace TextUtil.Tests.SplitterTests
{
    public abstract class SplitterTest
    {
        protected ITextSplitter TextSplitter { get; set; }

        private static readonly char[] Separators = { '.', '?', '!', ' ', ';', ':', ',', '\n' };

        protected abstract ITextSplitter CreateSplitter();

        [TestFixtureSetUp]
        public void Setup()
        {
            TextSplitter = CreateSplitter();
        }

        [Test]
        public void ShouldBeZeroCountForEmptyText()
        {
            var words = TextSplitter.GetWords(string.Empty, Separators);

            Assert.AreEqual(0, words.Count());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionForNullText()
        {
            TextSplitter.GetWords(null, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionForNullSeparators()
        {
            TextSplitter.GetWords("hello", null);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldThrowExceptionForEmptySeparators()
        {
            TextSplitter.GetWords("hello", new char[]{});
        }

        [Test]
        public void ShouldBeOneCountForSingleWord()
        {
            var words = TextSplitter.GetWords("Hello", Separators).ToArray();

            Assert.AreEqual(1, words.Count());
            Assert.AreEqual("Hello", words[0]);
        }

        [Test]
        public void ShouldBeTwoCountsForTwoWords()
        {
            var words = TextSplitter.GetWords("Hello Splitter", Separators).ToArray();

            Assert.AreEqual(2, words.Count());
            Assert.AreEqual("Hello", words[0]);
            Assert.AreEqual("Splitter", words[1]);
        }

        [Test]
        public void ShouldBeTwoCountsForTwoSameWords()
        {
            var words = TextSplitter.GetWords("Hello Hello", Separators).ToArray();

            Assert.AreEqual(2, words.Count());
            Assert.AreEqual("Hello", words[0]);
            Assert.AreEqual("Hello", words[1]);
        }

        [Test]
        public void ShouldHanldePunctuations()
        {
            var words = TextSplitter.GetWords("Hello! Hello, Hello? Hello: Hello. Hello; Hello", Separators).ToArray();

            Assert.AreEqual(7, words.Count());
            foreach (var w in words)
            {
                Assert.AreEqual("Hello", w);
            }
        }

        [Test]
        public void ShouldHanldeNewLines()
        {
            var words = TextSplitter.GetWords("Hello\nHello\nHello\n", Separators).ToArray();

            Assert.AreEqual(3, words.Count());
            foreach (var w in words)
            {
                Assert.AreEqual("Hello", w);
            }
        }
    }
}