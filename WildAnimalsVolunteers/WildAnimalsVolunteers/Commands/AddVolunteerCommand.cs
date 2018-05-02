namespace WildAnimalsVolunteers.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WildAnimalsVolunteers.Interfaces;
    using WildAnimalsVolunteers.Interfaces.Volunteers;
    using WildAnimalsVolunteers.Models.Volunteers.Factory;

    public class AddVolunteerCommand : BaseCommand
    {
        private IVolunteerFactory volunteerFactory;

        public AddVolunteerCommand(IList<string> commandArgs, IVolunteersController volunteersController)
            : base(commandArgs, volunteersController)
        {
            this.volunteerFactory = new VolunteerFactory();
        }

        public override string Execute()
        {
            var volunteer = this.volunteerFactory.CreateVolunteer(base.CommandArgs);

            var categoryName = base.CommandArgs[0];
            base.VolunteersController.AddVolunteerToCategory(categoryName, volunteer);

            return $"{volunteer.Name} is successfully added to {categoryName}.";
        }
    }
}
