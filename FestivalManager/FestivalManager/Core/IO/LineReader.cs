namespace FestivalManager.Core.IO
{
    using FestivalManager.Core.IO.Contracts;
    using System;

	public class LineReader : IReader
	{
		public string ReadLine()
        {
            return Console.ReadLine();
        }
	}
}