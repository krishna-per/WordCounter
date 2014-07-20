using Microsoft.Practices.Unity;
using NUnit.Framework;
using TextUtil.Factory;
using TextUtil.Interfaces;
using TextUtil.TextSplitters;

namespace TextUtil.Tests.SplitterTests
{
    [TestFixture]
    public class ParseSplitterTest : SplitterTest
    {
        protected override ITextSplitter CreateSplitter()
        {
            return Unity.Container.Resolve<ITextSplitter>("ParseSplitter");

            // return new ParseSplitter();
        }

        // Make sure what we resolved is really a ParseSplitter
        [Test]
        public void ShouldBeParseSplitter()
        {
            Assert.IsInstanceOf(typeof(ParseSplitter), TextSplitter);
        }
    }
}