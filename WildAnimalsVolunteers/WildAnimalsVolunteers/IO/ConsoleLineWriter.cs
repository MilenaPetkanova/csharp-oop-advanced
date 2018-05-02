namespace WildAnimalsVolunteers.Core
{
    using System;

    public class ConsoleLineWriter : IOutputWriter
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}