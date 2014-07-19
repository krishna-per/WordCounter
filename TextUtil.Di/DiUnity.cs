using Microsoft.Practices.Unity;

namespace TextUtil.Di
{
    // We will register types for unity in code as below

    public class DiUnity
    {
        private static IUnityContainer _container;

        public static IUnityContainer Container
        {
            get { return _container ?? (_container = Register()); }
        }

        public static IUnityContainer Register()
        {
            var container = new UnityContainer();

            container.AddExtension(new TextUtilModule());

            return container;
        }
    }
}
