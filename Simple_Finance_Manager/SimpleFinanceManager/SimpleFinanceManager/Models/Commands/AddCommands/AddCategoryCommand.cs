using System.Collections.Generic;

public class AddCategoryCommand : Command
{
    public AddCategoryCommand(IList<string> arguments, IManager manager) : base(arguments, manager)
    {
    }

    public override string Execute() => base.Manager.AddCategory(this.Arguments);
}