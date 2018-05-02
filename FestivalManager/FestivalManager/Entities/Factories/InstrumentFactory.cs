namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
            var assembly = Assembly.GetCallingAssembly();
            var instrumentType = assembly.GetTypes()
                .FirstOrDefault(x => x.Name.Equals(type));

            if (instrumentType == null)
            {
                throw new ArgumentException("Instrument wasn't created correctly!");
            }

            else if (!typeof(IInstrument).IsAssignableFrom(instrumentType))
            {
                throw new InvalidOperationException("Created instrument isn't of the correct type!");
            }

            IInstrument instrument = (IInstrument)Activator.CreateInstance(instrumentType, new object[0] {});
            return instrument;
        }
	}
}