namespace WildAnimalsVolunteers.Models.Volunteers
{
    using System.Collections.Generic;
    using WildAnimalsVolunteers.Interfaces.Volunteers;

    public class NonTransporter : Volunteer, INonTransporter
    {
        public NonTransporter(IList<string> transporterData) 
            : base(transporterData)
        {
            this.FacebookProfile = transporterData[2];
            this.ProposedHelp = transporterData[3];
            this.Area = transporterData[4];
            this.Notes = transporterData[5];
        }

        public string FacebookProfile { get; }

        public string ProposedHelp { get; }

        public string Area { get; }

        public string Notes { get; }
    }
}
