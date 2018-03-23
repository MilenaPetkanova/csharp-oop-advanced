using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private ISteamable steamable;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(ISteamable steamResult)
        {
            this.steamable = steamResult;
        }

        public int CalculateCurrentPercent()
        {
            return (this.steamable.BytesSent * 100) / this.steamable.Length;
        }
    }
}
