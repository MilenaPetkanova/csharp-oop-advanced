namespace WildAnimalsVolunteers.Core.Controllers.Contracts
{
    public interface IVolunteersController
    {
        void AddVolunteerToCategory(string categoryName, IVolunteer volunteer);
        string DeleteVolunteer(IList<string> commandArgs);
    }
}
