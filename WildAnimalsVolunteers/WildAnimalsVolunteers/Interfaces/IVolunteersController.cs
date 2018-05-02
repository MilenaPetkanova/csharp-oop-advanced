using System.Collections;
using System.Collections.Generic;

namespace WildAnimalsVolunteers.Interfaces
{
    public interface IVolunteersController
    {
        void AddVolunteerToCategory(string categoryName, IVolunteer volunteer);
        string DeleteVolunteer(IList<string> commandArgs);
    }
}
