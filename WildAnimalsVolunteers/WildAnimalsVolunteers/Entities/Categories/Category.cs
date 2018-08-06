namespace WildAnimalsVolunteers.Entities.Categories
{
    using System.Collections.Generic;
    using WildAnimalsVolunteers.Entities.Categories.Contracts;
    using WildAnimalsVolunteers.Entities.Volunteers.Contracts;

    public abstract class Category : ICategory
    {
        public Category()
        {
            this.Volunteers = new List<IVolunteer>();
        }

        public abstract string Name { get; }

        public IList<IVolunteer> Volunteers { get; protected set; }
    }
}
