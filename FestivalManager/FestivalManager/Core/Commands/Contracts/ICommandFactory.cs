using FestivalManager.Core.Controllers.Contracts;
using System.Collections.Generic;

public interface ICommandFactory
{
    ICommand CreateCommand(string[] arguments, IFestivalController festivalController, ISetController setController);
}