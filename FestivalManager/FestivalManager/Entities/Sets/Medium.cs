namespace FestivalManager.Entities.Sets
{
	using System;

	public class Medium : Set
	{
        private const int MaxMinDuration = 40;

        public Medium(string name) 
			: base(name, new TimeSpan(0, MaxMinDuration, 0))
		{
        }
    }
}