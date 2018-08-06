using System.Collections.Generic;

public class AddLimitCommand : Command
{
    public AddLimitCommand(IList<string> arguments, IManager manager) : base(arguments, manager)
    {
    }

    public override string Execute() => this.Manager.AddLimit(this.Arguments);
}