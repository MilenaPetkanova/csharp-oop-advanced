namespace WildAnimalsVolunteers.Core.Commands
{
    using System.Collections.Generic;
    using WildAnimalsVolunteers.Interfaces;

    public class DeleteVolunteerCommand : BaseCommand
    {
        public DeleteVolunteerCommand(IList<string> commandArgs, IVolunteersController volunteersController) 
            : base(commandArgs, volunteersController)
        {
        }

        public override string Execute()
        {
            return base.VolunteersController.DeleteVolunteer(base.CommandArgs);
        }
    }
}
