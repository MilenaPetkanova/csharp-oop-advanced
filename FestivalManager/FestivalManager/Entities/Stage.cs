namespace FestivalManager.Entities
{
	using System.Collections.Generic;
	using Contracts;
    using System.Linq;

    public class Stage : IStage
    {
        private readonly List<ISet> sets;
        private readonly List<ISong> songs;
        private readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets;

        public IReadOnlyCollection<ISong> Songs => this.songs;

        public IReadOnlyCollection<IPerformer> Performers => this.performers;

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet set)
        {
            this.sets.Add(set);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            return (IPerformer)this.performers.First(p => p.Name.Equals(name));
        }

        public ISet GetSet(string name)
        {
            return (ISet)this.sets.First(s => s.Name.Equals(name));
        }

        public ISong GetSong(string name)
        {
            return (ISong)this.songs.First(s => s.Name.Equals(name));
        }

        public bool HasPerformer(string name)
        {
            return this.performers.Any(p => p.Name.Equals(name));
        }

        public bool HasSet(string name)
        {
            return this.sets.Any(s => s.Name.Equals(name));
        }

        public bool HasSong(string name)
        {
            return this.songs.Any(s => s.Name.Equals(name));
        }
    }
}
