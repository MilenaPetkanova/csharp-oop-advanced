using System;
using System.Collections.Generic;
using System.Text;
using WildAnimalsVolunteers.Commands;
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

