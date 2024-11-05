using System;
using System.Diagnostics.Metrics;

using Seido.Utilities.SeedGenerator;

namespace Models
{
    public class csAlbum : IAlbum, ISeed<csAlbum>
    {
        public virtual Guid AlbumId { get; set; }
 
        public virtual string Name { get; set; }
        public virtual int ReleaseYear { get; set; }
        public virtual long CopiesSold { get; set; }

        //Navigation properties
        public virtual IMusicGroup MusicGroup { get; set; } = null;

        #region Constructors
        public csAlbum(){}
        public csAlbum(csAlbum org)
        {
            this.Seeded = org.Seeded;

            this.AlbumId = org.AlbumId;
            this.Name = org.Name;
            this.ReleaseYear = org.ReleaseYear;
            this.CopiesSold = org.CopiesSold;
        }
        #endregion

        #region randomly seed this instance
        public virtual bool Seeded { get; set; } = false;
        public virtual csAlbum Seed(csSeedGenerator sgen)
        {
            Seeded = true;
            AlbumId = Guid.NewGuid();

            Name = sgen.MusicAlbumName;
            CopiesSold = sgen.Next(1_000, 1_000_000);
            ReleaseYear = sgen.Next(1970, 2023);

            return this;
        }
        #endregion
    }
}

