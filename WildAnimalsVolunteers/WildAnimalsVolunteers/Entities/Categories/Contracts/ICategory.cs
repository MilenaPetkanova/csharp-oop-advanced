namespace WildAnimalsVolunteers.Entities.Categories.Contracts
{
    using System.Collections.Generic;
    using WildAnimalsVolunteers.Entities.Volunteers.Contracts;

    public interface ICategory
    {
        string Name { get; }

        IList<IVolunteer> Volunteers { get; }
    }
}
