namespace WildAnimalsVolunteers.Entities.Volunteers
{
    using System.Collections.Generic;
    using WildAnimalsVolunteers.Entities.Volunteers.Contracts;

    public abstract class Volunteer : IVolunteer
    {
        protected Volunteer(IList<string> args)
        {
            this.Name = args[0];
            this.PhoneNumber = args[1];
        }

        public string Name { get; }

        public string PhoneNumber { get; }
    }
}
