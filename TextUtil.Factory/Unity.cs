using Microsoft.Practices.Unity;

namespace TextUtil.Factory
{
    // We will register types for unity in code as below

    public class Unity
    {
        private static IUnityContainer _container;

        public static IUnityContainer Container
        {
            get { return _container ?? (_container = Register()); }
        }

        public static IUnityContainer Register()
        {
            var container = new UnityContainer();

            // Register types in TextUtilModule
            container.AddExtension(new TextUtilModule());

            return container;
        }
    }
}
