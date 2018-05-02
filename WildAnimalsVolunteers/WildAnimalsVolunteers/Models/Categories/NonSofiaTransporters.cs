namespace WildAnimalsVolunteers.Models.Categories
{
    using System.Collections.Generic;
    using WildAnimalsVolunteers.Interfaces;

    public class NonSofiaTransporters : ICategory
    {
        public NonSofiaTransporters()
        {
            this.Volunteers = new List<IVolunteer>();
        }
        public string Name => this.GetType().Name;

        public IList<IVolunteer> Volunteers { get; private set; }
    }
}
