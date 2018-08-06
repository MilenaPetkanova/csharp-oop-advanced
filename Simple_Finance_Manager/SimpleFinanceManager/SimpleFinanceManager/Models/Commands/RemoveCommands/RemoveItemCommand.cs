using System.Collections.Generic;


public class RemoveItemCommand : Command
{
    public RemoveItemCommand(IList<string> arguments, IManager manager) : base(arguments, manager)
    {
    }

    public override string Execute() => this.Manager.RemoveItem(this.Arguments);
}