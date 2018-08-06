using System.Collections.Generic;

public class ShowCurrentBalanceCommand : Command
{
    public ShowCurrentBalanceCommand(IList<string> arguments, IManager manager) : base(arguments, manager)
    {
    }

    public override string Execute() => this.Manager.ShowCurrentBalance(this.Arguments);
}