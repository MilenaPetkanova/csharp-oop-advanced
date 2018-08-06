using System.Collections.Generic;

public class RemoveCategoryCommand : Command
{
    public RemoveCategoryCommand(IList<string> arguments, IManager manager) : base(arguments, manager)
    {
    }

    public override string Execute() => this.Manager.RemoveCategory(this.Arguments);
}