using System.Collections.Generic;


public abstract class Command : ICommand
{
    protected Command(IList<string> arguments, IManager manager)
    {
        this.Arguments = arguments;
        this.Manager = manager;
    }

    protected IList<string> Arguments { get; }

    protected IManager Manager { get; }

    public abstract string Execute();
}