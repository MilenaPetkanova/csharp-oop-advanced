namespace WildAnimalsVolunteers.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using WildAnimalsVolunteers.Interfaces;

    public class CategoryFactory : ICategoryFactory
    {
        public ICategory CreateCategory(string categoryName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var categoryType = assembly.GetTypes().FirstOrDefault(c => c.Name.Equals(categoryName));

            var category = (ICategory)Activator.CreateInstance(categoryType, null);

            return category;
        }
    }
}
