using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;

using Seido.Utilities.SeedGenerator;
using Configuration;
using Models;
using Models.DTO;


namespace WapiModels
{
    public class csArtistWapi: csArtist, ISeed<csArtistWapi>
    {
        #region correcting the Navigation properties migration error caused by using interfaces
        public new List<csMusicGroupWapi> MusicGroups { get; set; }

        #endregion
        
        #region Constructors
        public csArtistWapi()
        {
        }
        public csArtistWapi(csArtistCUdto _dto)
        {
            ArtistId = Guid.NewGuid();
            UpdateFromDTO(_dto);
        }
        #endregion

        #region Update from DTO
        public csArtistWapi UpdateFromDTO(csArtistCUdto _dto)
        {
            this.FirstName = _dto.FirstName;
            this.LastName = _dto.LastName;
            this.BirthDay = _dto.BirthDay;

            return this;
        }
        #endregion

        #region randomly seed this instance
        public override csArtistWapi Seed(csSeedGenerator sgen)
        {
            base.Seed(sgen);
            return this;
        }
        #endregion
    }
}

