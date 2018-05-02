namespace WildAnimalsVolunteers.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using WildAnimalsVolunteers.Interfaces;

    public class VolunteersController : IVolunteersController
    {
        private ICategoriesController categoriesController;

        public VolunteersController()
        {
            this.categoriesController = new CategoriesController();
        }

        public void AddVolunteerToCategory(string categoryName, IVolunteer volunteer)
        {
            ValidateCategory(categoryName);

            var category = this.categoriesController.Categories.First(c => c.GetType().Name == categoryName);
            category.Volunteers.Add(volunteer);
        }

        public string DeleteVolunteer(IList<string> commandArgs)
        {
            var category = this.categoriesController.Categories.First(c => c.GetType().Name == commandArgs[0]);
            var volunteerToRemove = category.Volunteers.FirstOrDefault(v => v.Name == commandArgs[1]);

            category.Volunteers.Remove(volunteerToRemove);

            return $"{volunteerToRemove.Name} was successfully deleted!";
        }



        private void ValidateCategory(string categoryName)
        {
            if (!Enum.IsDefined(typeof(Categories), categoryName))
            {
                throw new InvalidOperationException("Invalid category!");
            }
        }
    }
}
