using System.Collections.Generic;

public class ShowTotalItemsSumCommand : Command
{
    public ShowTotalItemsSumCommand(IList<string> arguments, IManager manager) : base(arguments, manager)
    {
    }

    public override string Execute() => this.Manager.ShowTotalItemsSum(this.Arguments);
}