using System;
using System.Collections.Generic;
using System.Text;
using WildAnimalsVolunteers.Interfaces.Volunteers;

namespace WildAnimalsVolunteers.Models.Volunteers
{
    public class Lawyer : Volunteer, ILawyer
    {
        public Lawyer(IList<string> transporterData) 
            : base(transporterData)
        {
            this.Qualification = transporterData[2];
            this.Description = transporterData[3];
        }

        public string Qualification { get; }

        public string Description { get; }
    }
}
