using System.Collections.Generic;
using WildAnimalsVolunteers.Interfaces;

namespace WildAnimalsVolunteers.Models.Volunteers.Transporters
{
    public class SofiaTransporter : Transporter, ISofiaTransporter
    {
        public SofiaTransporter(IList<string> transporterData) 
            : base(transporterData)
        {
        }

        public string NeighborhoodToReactAt => base.AreaToReactAt;
    }
}
