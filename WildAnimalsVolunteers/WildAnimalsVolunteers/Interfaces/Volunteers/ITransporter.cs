namespace WildAnimalsVolunteers.Interfaces
{
    public interface ITransporter
    {
        string StatusForTheDay { get; }

        string FacebookProfile { get; }

        string TransportType { get; }

        string TimeDisposal { get; }

        string AdditionalInfoAboutTransport { get; }

        string AnotherUsefulSkills { get; }
    }
}
