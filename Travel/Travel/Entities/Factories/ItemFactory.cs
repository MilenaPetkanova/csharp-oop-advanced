namespace Travel.Entities.Factories
{
    using Contracts;
    using Items.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string type)
		{
            var assembly = Assembly.GetCallingAssembly();
            var itemType = assembly.GetTypes()
                .FirstOrDefault(x => x.Name.Equals(type));

            if (itemType == null)
            {
                throw new ArgumentException("There is no such item type!");
            }

            else if (!typeof(IItem).IsAssignableFrom(itemType))
            {
                throw new InvalidOperationException("Created item isn't assignable of the correct type!");
            }

            IItem item = (IItem)Activator.CreateInstance(itemType, new object[0] { });
            return item;
        }
	}
}
