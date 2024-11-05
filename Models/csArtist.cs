using System;
using System.Diagnostics.Metrics;

using Seido.Utilities.SeedGenerator;
namespace Models
{
    public class csArtist : IArtist, ISeed<csArtist>
    {
        public virtual Guid ArtistId { get; set; }

        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public virtual DateTime? BirthDay { get; set; }

        //Navigation properties
        public virtual List<IMusicGroup> MusicGroups { get; set; } = new List<IMusicGroup>();

        public override string ToString() => $"{FirstName} {LastName}";

        #region Constructors
        public csArtist(){}
        public csArtist(csArtist org)
        {
            this.Seeded = org.Seeded;

            this.ArtistId = org.ArtistId;
            this.FirstName = org.FirstName;
            this.LastName = org.LastName;
            this.BirthDay = org.BirthDay;
        }
        #endregion

        #region randomly seed this instance
        public virtual bool Seeded { get; set; } = false;
        public virtual csArtist Seed(csSeedGenerator sgen)
        {
            Seeded = true;  
            ArtistId = Guid.NewGuid();

            FirstName = sgen.FirstName;
            LastName = sgen.LastName;
            BirthDay = (sgen.Bool) ? sgen.DateAndTime(1940, 1990) : null;

            return this;
        }
        #endregion
    }
}

