namespace Forum.App.Models.ViewsModels
{
    using Forum.App.Contracts;

    public class CategoryInfoViewModel : ICategoryInfoViewModel
    {
        public CategoryInfoViewModel(int id, string name, int postCount)
        {
            this.Id = id;
            this.Name = name;
            this.PostCount = postCount;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public int PostCount { get; private set; }
    }
}
