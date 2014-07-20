using Microsoft.Practices.Unity;
using NUnit.Framework;
using TextUtil.Factory;
using TextUtil.Interfaces;
using TextUtil.TextSplitters;

namespace TextUtil.Tests.SplitterTests
{
    [TestFixture]
    public class RegexSplitterTest : SplitterTest
    {
        protected override ITextSplitter CreateSplitter()
        {
            return Unity.Container.Resolve<ITextSplitter>("RegexSplitter");

            //return new RegexSplitter();
        }

        // Make sure what we resolved is really a RegexSplitter
        [Test]
        public void ShouldBeRegexSplitter()
        {
            Assert.IsInstanceOf(typeof(RegexSplitter), TextSplitter);
        }
    }
}