namespace WildAnimalsVolunteers.Core.Commands
{
    using System.Collections.Generic;
    using WildAnimalsVolunteers.Interfaces;

    public class EditVolunteerCommand : BaseCommand
    {
        public EditVolunteerCommand(IList<string> commandArgs, IVolunteersController volunteersController)
            : base(commandArgs, volunteersController)
        {
        }

        public override string Execute()
        {
            //return this.VolunteersController.Edit
        }
    }
}
