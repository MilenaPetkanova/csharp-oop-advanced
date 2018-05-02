namespace WildAnimalsVolunteers.Interfaces
{
    using System.Collections.Generic;

    public interface ICategoriesController
    {
        IList<ICategory> Categories { get; }
    }
}
