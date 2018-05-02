namespace WildAnimalsVolunteers.Models.Volunteers.Factory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using WildAnimalsVolunteers.Interfaces;
    using WildAnimalsVolunteers.Interfaces.Volunteers;

    public class VolunteerFactory : IVolunteerFactory
    {
        public IVolunteer CreateVolunteer(IList<string> commandArgs)
        {
            var categoryName = commandArgs[0];
            var volunteerType = categoryName.Substring(0, categoryName.Length - 1); // removing plural

            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetTypes().FirstOrDefault(x => x.Name.Equals(volunteerType));

            var volunteerArgs = commandArgs.Skip(1).ToList();

            var volunteer = (IVolunteer)Activator.CreateInstance(type, volunteerArgs);
            return volunteer;
        }
    }
}
