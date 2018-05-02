using System.Collections.Generic;
using WildAnimalsVolunteers.Interfaces;

namespace WildAnimalsVolunteers.Core
{
    public interface ICommandFactory
    {
        IExecutable CreateCommand(string commandName, IList<string> args, IVolunteersController volunteerController);
    }
}