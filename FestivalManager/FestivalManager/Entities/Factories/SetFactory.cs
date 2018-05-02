namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class SetFactory : ISetFactory
	{
        public ISet CreateSet(string name, string type)
        {
            var assembly = Assembly.GetCallingAssembly();
            var setType = assembly.GetTypes()
                .First(x => x.Name.Equals(type));

            if (setType == null)
            {
                throw new ArgumentException("Set wasn't created correctly!");
            }

            else if (!typeof(ISet).IsAssignableFrom(setType))
            {
                throw new InvalidOperationException("Created set isn't of the correct type!");
            }

            var set = (ISet)Activator.CreateInstance(setType, new object[] { name });
            return set;
        }
    }
}
