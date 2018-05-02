namespace WildAnimalsVolunteers.Models.Volunteers
{
    using System.Collections.Generic;
    using WildAnimalsVolunteers.Interfaces;

    public abstract class Volunteer : IVolunteer
    {
        public Volunteer(IList<string> transporterData)
        {
            this.Name = transporterData[0];
            this.PhoneNumber = transporterData[1];
        }

        public string Name { get; }

        public string PhoneNumber { get; }
    }
}
