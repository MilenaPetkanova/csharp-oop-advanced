namespace WildAnimalsVolunteers.Entities.Categories
{
    using System.Collections.Generic;
    using WildAnimalsVolunteers.Entities.Categories.Contracts;
    using WildAnimalsVolunteers.Entities.Volunteers.Contracts;

    public class NonTransporters : ICategory
    {
        public NonTransporters()
        {
            this.Volunteers = new List<IVolunteer>();
        }

        public string Name => this.GetType().Name;

        public IList<IVolunteer> Volunteers { get; private set; }
    }
}
