namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Entities.Contracts;
    using FestivalManager.Entities.Factories.Contracts;
    using FestivalManager.Entities.Factories;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";
        private const string AnotherTimeFormat = "{0:00}:{1:00}";
        private const string RegisteredSetMessage = "Registered {0} set";
        private const string RegisteredPerformerMessage = "Registered performer {0}";
        private const string RegisteredSongMessage = "Registered song {0} ({1:00}:{2:00})";
        private const string InvalidSetMessage = "Invalid set provided";
        private const string InvalidPerformerMessage = "Invalid performer provided";
        private const string InvalidSongMessage = "Invalid song provided";
        private const string AddedSongToSetMessage = "Added {0} ({1:00}:{2:00}) to {3}";

        private readonly IStage stage;
        private IInstrumentFactory instrumentFactory;
        private IPerformerFactory performerFactory;
        private ISetFactory setFactory;
        private ISongFactory songFactory;

        public FestivalController(IStage stage)
        {
            this.stage = stage;
            this.instrumentFactory = new InstrumentFactory();
            this.performerFactory = new PerformerFactory();
            this.setFactory = new SetFactory();
            this.songFactory = new SongFactory();
        }

        public string ProduceReport()
        {
            var sb = new StringBuilder();

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            sb.AppendLine($"Festival length: " +
                $"{string.Format(AnotherTimeFormat, totalFestivalLength.TotalMinutes, totalFestivalLength.Seconds)}");

            foreach (var set in this.stage.Sets)
            {
                sb.AppendLine($"--{set.Name} ({string.Format(Time, set.ActualDuration.TotalMinutes, set.ActualDuration.Seconds)}):");

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    sb.AppendLine($"---{performer.Name} ({instruments})");
                }

                if (!set.Songs.Any())
                {
                    sb.AppendLine("--No songs played");
                }
                else
                {
                    sb.AppendLine("--Songs played:");
                    foreach (var song in set.Songs)
                    {
                        sb.AppendLine($"----{song.Name} ({song.Duration.ToString(TimeFormat)})");
                    }
                }
            }

            return sb.ToString().Trim();
        }

        public string RegisterSet(string[] args)
        {
            var name = args[0];
            var type = args[1];

            var set = this.setFactory.CreateSet(name, type);
            this.stage.AddSet(set);

            return string.Format(RegisteredSet, type);
        }

        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);

            IPerformer performer = this.performerFactory.CreatePerformer(name, age);

            if (args.Length > 2)
            {
                var instrumentsNames = args.Skip(2).ToArray();
                var instruments = instrumentsNames
                    .Select(i => this.instrumentFactory.CreateInstrument(i))
                    .ToArray();

                foreach (var instrument in instruments)
                {
                    performer.AddInstrument(instrument);
                }
            }

            this.stage.AddPerformer(performer);

            return string.Format(RegisteredPerformer, performer.Name);
        }

        public string RegisterSong(string[] args)
        {
            var name = args[0];

            var time = "00:" + args[1];
            var duration = TimeSpan.Parse(time);

            var song = this.songFactory.CreateSong(name, duration);
            this.stage.AddSong(song);

            return string.Format(RegisteredSong, song.Name, song.Duration.TotalMinutes, song.Duration.Seconds);
        }

        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException(InvalidSet);
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException(InvalidSong);
            }

            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            return string.Format(AddedSongToSet, song.Name,
                song.Duration.TotalMinutes, song.Duration.Seconds, set.Name);
        }

        public string AddPerformerToSet(string[] args)
        {
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException(InvalidPerformer);
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException(InvalidSet);
            }

            var set = this.stage.GetSet(setName);
            var performer = this.stage.GetPerformer(performerName);

            set.AddPerformer(performer);

            return $"Added {performerName} to {set.Name}";
        }

        public string PerformerRegistration(string[] args)
        {
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException(InvalidPerformer);
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException(InvalidSet);
            }

            AddPerformerToSet(args);

            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performer.Name} to {set.Name}";
        }

        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }
    }
}