namespace WildAnimalsVolunteers.Entities.Categories
{
    using System.Collections.Generic;
    using WildAnimalsVolunteers.Entities.Categories.Contracts;
    using WildAnimalsVolunteers.Entities.Volunteers.Contracts;

    public class Transporters : Category
    {


        public override string Name => this.GetType().Name;
    }
}
