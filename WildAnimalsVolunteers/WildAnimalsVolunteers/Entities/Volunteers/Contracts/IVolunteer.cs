namespace WildAnimalsVolunteers.Entities.Volunteers.Contracts
{
    public interface IVolunteer
    {
        string Name { get; }

        string PhoneNumber { get; }

        string Facebook { get; }

        string Email { get; }
    }
}