using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.Linq;

using Seido.Utilities.SeedGenerator;
using Configuration;
using Models;
using Models.DTO;


namespace WapiModels
{
    public class csAlbumWapi : csAlbum, ISeed<csAlbumWapi>
    {
        #region correcting the Navigation properties migration error caused by using interfaces
        public new csMusicGroupWapi MusicGroup { get => (csMusicGroupWapi) base.MusicGroup; set => base.MusicGroup = value; }
        #endregion

        #region Constructors
        public csAlbumWapi() {}
        public csAlbumWapi(csAlbumCUdto _dto)
        {
            AlbumId = Guid.NewGuid();
            UpdateFromDTO(_dto);
        }
        #endregion

        #region Update from DTO
        public csAlbumWapi UpdateFromDTO(csAlbumCUdto _dto)
        {
            Name = _dto.Name;
            ReleaseYear = _dto.ReleaseYear;
            CopiesSold = _dto.CopiesSold;

            return this;
        }
        #endregion

        #region randomly seed this instance
        public override csAlbumWapi Seed(csSeedGenerator sgen)
        {
            base.Seed(sgen);
            return this;
        }
        #endregion
    }
}

