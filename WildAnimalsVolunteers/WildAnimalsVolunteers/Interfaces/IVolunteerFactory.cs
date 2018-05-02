using System;
using System.Collections.Generic;
using System.Text;

namespace WildAnimalsVolunteers.Interfaces.Volunteers
{
    public interface IVolunteerFactory
    {
        IVolunteer CreateVolunteer(IList<string> args);
    }
}
