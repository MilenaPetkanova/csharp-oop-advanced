namespace WildAnimalsVolunteers.Core
{
    using System;
    using System.Collections.Generic;
    using WildAnimalsVolunteers.Interfaces;
    using WildAnimalsVolunteers.Models.Categories.Factory;

    public class CategoriesController : ICategoriesController
    {
        private ICategoryFactory categoryFactory;
        private readonly IList<ICategory> categories;

        public CategoriesController()
        {
            this.categoryFactory = new CategoryFactory();
            this.categories = new List<ICategory>();
            InitializeCategories();
        }

        public IList<ICategory> Categories => this.categories;

        protected void InitializeCategories()
        {
            foreach (var categoryType in Enum.GetValues(typeof(Categories)))
            {
                var category = this.categoryFactory.CreateCategory(categoryType.ToString());
                this.categories.Add(category);
            }
        }
    }
}
