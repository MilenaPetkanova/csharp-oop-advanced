using System.Collections.Generic;


public class AddItemToCategoryCommand : Command
{
    public AddItemToCategoryCommand(IList<string> arguments, IManager manager) : base(arguments, manager)
    {
    }

    public override string Execute() => this.Manager.AddItemToCategory(this.Arguments);
}