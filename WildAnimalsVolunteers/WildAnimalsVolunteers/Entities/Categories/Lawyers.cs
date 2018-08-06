namespace WildAnimalsVolunteers.Entities.Categories
{
    using System.Collections.Generic;
    using WildAnimalsVolunteers.Interfaces;

    public class Lawyers : ICategory
    {
        public Lawyers()
        {
            this.Volunteers = new List<IVolunteer>();
        }

        public string Name => this.GetType().Name;

        public IList<IVolunteer> Volunteers { get; private set; }
    }
}
