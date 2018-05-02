namespace WildAnimalsVolunteers.Core
{
    using System;

    public class ConsoleLineReader : IInputReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}