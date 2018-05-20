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

        // Sets
        public IReadOnlyCollection<ISet> Sets => this.sets;

        public void AddSet(ISet set) => this.sets.Add(set);

        public bool HasSet(string name) => this.sets.Any(s => s.Name.Equals(name));

        public ISet GetSet(string name) => this.sets.First(s => s.Name.Equals(name));

        // Songs 
        public IReadOnlyCollection<ISong> Songs => this.songs;

        public void AddSong(ISong song) => this.songs.Add(song);

        public bool HasSong(string name) => this.songs.Any(s => s.Name.Equals(name));

        public ISong GetSong(string name) => this.songs.First(s => s.Name.Equals(name));

        // Performers
        public IReadOnlyCollection<IPerformer> Performers => this.performers;

        public void AddPerformer(IPerformer performer) => this.performers.Add(performer);

        public bool HasPerformer(string name) => this.performers.Any(p => p.Name.Equals(name));

        public IPerformer GetPerformer(string name) => this.performers.First(p => p.Name.Equals(name));
    }
}
