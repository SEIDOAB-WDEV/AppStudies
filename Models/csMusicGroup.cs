using System;
using System.Diagnostics.Metrics;

using Seido.Utilities.SeedGenerator;

namespace Models
{
    public enum enMusicGenre {Rock, Blues, Jazz, Metall }
    public class csMusicGroup : ISeed<csMusicGroup>
    {
        public virtual Guid MusicGroupId { get; set; }
        public virtual string Name { get; set; }
        public virtual int EstablishedYear { get; set; }
        public virtual enMusicGenre Genre { get; set; }

        //Navigation properties
        public virtual List<csAlbum> Albums { get; set; } = new List<csAlbum>();
        public virtual List<csArtist> Artists { get; set; } = new List<csArtist>();

        public override string ToString() =>
             $"{Name} with {Artists.Count} members was esblished {EstablishedYear} and made {Albums.Count} great albums.";

        #region Constructors
        public csMusicGroup(){}
        public csMusicGroup(csMusicGroup org)
        {
            Seeded = org.Seeded;

            MusicGroupId = org.MusicGroupId;
            Name = org.Name;
            EstablishedYear = org.EstablishedYear;
            Genre = org.Genre;
        }
        #endregion

        #region randomly seed this instance
        public virtual bool Seeded { get; set; } = false;
        public virtual csMusicGroup Seed(csSeedGenerator sgen)
        {
            Seeded = true;
            MusicGroupId = Guid.NewGuid();

            Name = sgen.MusicGroupName;
            EstablishedYear = sgen.Next(1970, 2023);
            Genre = sgen.FromEnum<enMusicGenre>();
            return this;
        }
        #endregion
    }
}

