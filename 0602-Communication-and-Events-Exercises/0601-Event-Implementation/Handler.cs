public class Handler
{
    IWriter writer;

    public Handler()
    {
        this.writer = new ConsoleWriter();
    }

    public void OnDispatcherNameChange(object sender, NameChangeEventArgs args)
    {
        this.writer.WriteLine($"Dispatcher's name changed to {args.Name}.");
    }
}

