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
    public class csMusicGroupWapi : csMusicGroup, ISeed<csMusicGroupWapi>
    {
        #region correcting the Navigation properties migration error caused by using interfaces
        [JsonIgnore] 
        public override List<IAlbum> Albums { get => AlbumsWapi?.ToList<IAlbum>(); set => new NotImplementedException(); }

        public virtual List<csAlbumWapi> AlbumsWapi { get; set; } = null;
        
        [JsonIgnore] 
        public override List<IArtist> Artists { get => ArtistsWapi?.ToList<IArtist>(); set => new NotImplementedException(); }

        public virtual List<csArtistWapi> ArtistsWapi { get; set; } = null;
        #endregion
        
        #region Constructors
        public csMusicGroupWapi(){}
        public csMusicGroupWapi(csMusicGroupCUdto _dto)
        {
            MusicGroupId = Guid.NewGuid();
            UpdateFromDTO(_dto);
        }
        #endregion

        #region Update from DTO
        public csMusicGroupWapi UpdateFromDTO(csMusicGroupCUdto _dto)
        {
            Name = _dto.Name;
            EstablishedYear = _dto.EstablishedYear;
            Genre = _dto.Genre;

            return this;
        }
        #endregion

        #region randomly seed this instance
        public override csMusicGroupWapi Seed(csSeedGenerator sgen)
        {
            base.Seed(sgen);
            return this;
        }
        #endregion
    }
}

