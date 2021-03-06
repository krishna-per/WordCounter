using Microsoft.Practices.Unity;
using NUnit.Framework;
using TextUtil.Factory;
using TextUtil.Interfaces;
using TextUtil.TextSplitters;

namespace TextUtil.Tests.SplitterTests
{
    [TestFixture]
    public class StringSplitterTest : SplitterTest
    {
        protected override ITextSplitter CreateSplitter()
        {
            return Unity.Container.Resolve<ITextSplitter>("StringSplitter");

            //return new StringSplitter();
        }

        // Make sure what we resolved is really a StringSplitter
        [Test]
        public void ShouldBeStringSplitter()
        {
            Assert.IsInstanceOf(typeof(StringSplitter), TextSplitter);
        }
    }
}