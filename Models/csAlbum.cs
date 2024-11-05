using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.Linq;

using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Models
{
    public class csAlbum : ISeed<csAlbum>
    {
        public Guid AlbumId { get; set; }

        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public long CopiesSold { get; set; }

        //Navigation properties
        public csMusicGroup MusicGroup { get; set; } = null;

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

