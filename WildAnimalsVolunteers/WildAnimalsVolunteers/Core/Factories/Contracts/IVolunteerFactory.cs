using System;
using System.Collections.Generic;
using System.Text;

namespace WildAnimalsVolunteers.Core.Factories.Contracts
{
    public interface IVolunteerFactory
    {
        IVolunteer CreateVolunteer(IList<string> args);
    }
}
