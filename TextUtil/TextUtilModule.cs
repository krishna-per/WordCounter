using Microsoft.Practices.Unity;
using TextUtil.Interfaces;
using TextUtil.TextSplitters;

namespace TextUtil
{
    public class TextUtilModule : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Register(Container);
        }

        public void Register(IUnityContainer container)
        {
            // Since ITextSplitter is implemented by three classes, let's register types with names
            // Creator will use the name to resolve appropriate splitter
            container.RegisterType<ITextSplitter, StringSplitter>("StringSplitter");
            container.RegisterType<ITextSplitter, RegexSplitter>("RegexSplitter");
            container.RegisterType<ITextSplitter, ParseSplitter>("ParseSplitter");

            // When resolving WordCounter, creator will pass the splitter in DependencyOverride based on the selected strategy
            container.RegisterType<IWordCounter, WordCounter>();
        }
    }
}