namespace WildAnimalsVolunteers.Entities.Volunteers.Contracts
{
    public interface ITransporter
    {
        string RegionToReactAt { get; }

        string VehicleType { get; }

        string TimeDisposal { get; }

        string VehicleAdditionalInfo { get; }

        string AnotherUsefulSkills { get; }

        string StatusForTheDay { get; }
    }
}
