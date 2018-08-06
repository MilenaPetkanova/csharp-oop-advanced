namespace WildAnimalsVolunteers.Core.Factories.Contracts
{
    public interface ICategoryFactory
    {
        ICategory CreateCategory(string categoryName);
    }
}
