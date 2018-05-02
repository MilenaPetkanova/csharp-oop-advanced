namespace WildAnimalsVolunteers.Interfaces
{
    using System.Collections.Generic;

    public interface ICategory
    {
        string Name { get; }

        IList<IVolunteer> Volunteers { get; }
    }
}
