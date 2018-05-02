namespace WildAnimalsVolunteers.Models.Volunteers.Transporters
{
    using System.Collections.Generic;
    using WildAnimalsVolunteers.Interfaces;

    public abstract class Transporter : Volunteer, ITransporter
    {
        public Transporter(IList<string> transporterData) 
            : base(transporterData)
        {
            this.StatusForTheDay = transporterData[2];
            this.FacebookProfile = transporterData[3];
            this.AreaToReactAt = transporterData[4];
            this.TransportType = transporterData[5];
            this.TimeDisposal = transporterData[6];
            this.AdditionalInfoAboutTransport = transporterData[7];
            this.AnotherUsefulSkills = transporterData[8];
        }

        public string StatusForTheDay { get; }

        public string FacebookProfile { get; }

        public virtual string AreaToReactAt { get; }
        
        public string TransportType { get; }

        public string TimeDisposal { get; }

        public string AdditionalInfoAboutTransport { get; }

        public string AnotherUsefulSkills { get;  }

    }
}
