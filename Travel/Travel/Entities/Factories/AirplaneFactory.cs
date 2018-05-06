namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;
    using System.Reflection;
    using System;
    using System.Linq;

    public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string type)
		{
            var assembly = Assembly.GetCallingAssembly();
            Type aiplaneType = assembly.GetTypes().FirstOrDefault(x => x.Name.Equals(type));

            if (aiplaneType == null)
            {
                throw new ArgumentException("There is no such airplane type!");
            }

            else if (!typeof(IAirplane).IsAssignableFrom(aiplaneType))
            {
                throw new InvalidOperationException("Created airplane isn't assignable of the correct type!");
            }

            IAirplane airplane = (IAirplane)Activator.CreateInstance(aiplaneType, new object[0] { });
            return airplane;
        }
	}
}