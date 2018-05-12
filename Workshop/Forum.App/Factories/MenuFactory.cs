namespace Forum.App.Factories
{
    using Forum.App.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class MenuFactory : IMenuFactory
    {
        private IServiceProvider serviceProvider;

        public MenuFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IMenu CreateMenu(string menuName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var menuType = assembly.GetTypes()
                .FirstOrDefault(t => t.Name.Equals(menuName));

            ValidateMenuType(menuType);

            var ctorParams = menuType.GetConstructors().First().GetParameters();
            var args = new object[ctorParams.Length];

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = this.serviceProvider.GetService(ctorParams[i].ParameterType);
            }

            IMenu menu = (IMenu)Activator.CreateInstance(menuType, args);

            return menu;
        }

        private static void ValidateMenuType(Type menuType)
        {
            if (menuType == null)
            {
                throw new ArgumentException("Menu not found!");
            }

            if (!typeof(IMenu).IsAssignableFrom(menuType))
            {
                throw new InvalidOperationException($"{menuType} is not a menu!");
            }
        }
    }
}
