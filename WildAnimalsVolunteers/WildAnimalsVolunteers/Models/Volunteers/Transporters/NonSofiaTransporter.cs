using System.Collections.Generic;
using WildAnimalsVolunteers.Interfaces;

namespace WildAnimalsVolunteers.Models.Volunteers.Transporters
{
    public class NonSofiaTransporter : Transporter, INotSofiaTransporter
    {
        public NonSofiaTransporter(IList<string> transporterData)
            : base(transporterData)
        {
        }

        public string TownToReactAt => base.AreaToReactAt;
    }
}
