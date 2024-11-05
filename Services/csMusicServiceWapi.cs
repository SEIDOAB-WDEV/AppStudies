using System;
using Microsoft.Extensions.Logging;
using Models;
using Models.DTO;
using Newtonsoft.Json;

namespace Services
{
    public class csMusicServiceWapi : IMusicService
    {
        private ILogger<csMusicServiceWapi> _logger = null;
        private HttpClient _httpClient = null;

        //To ensure Json deserializern is using the class implementations instead of the Interfaces 
        JsonSerializerSettings _jsonSettings = new JsonSerializerSettings
        {
            Converters = {
                new AbstractConverter<csMusicGroup, IMusicGroup>(),
                new AbstractConverter<csAlbum, IAlbum>(),
                new AbstractConverter<csArtist, IArtist>()
            },
        };

        #region constructors
        public csMusicServiceWapi(IHttpClientFactory httpClientFactory, ILogger<csMusicServiceWapi> logger)
        {
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient(name: "MusicWebApi");
        }
        #endregion

        #region Admin Services
        public Task<gstusrInfoAllDto> InfoAsync => throw new NotImplementedException();

        public Task<gstusrInfoAllDto> SeedAsync(int nrOfItems) 
        {
            throw new NotImplementedException();
        }
        public Task<gstusrInfoAllDto> RemoveSeedAsync(bool seeded)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region MusicGroup CRUD
        public Task<csRespPageDto<IMusicGroup>> ReadMusicGroupsAsync(bool seeded, bool flat, string filter, int pageNumber, int pageSize) 
        {
            throw new NotImplementedException();
        }
        public Task<IMusicGroup> ReadMusicGroupAsync(Guid id, bool flat)
        {
            throw new NotImplementedException();
        }
        public Task<IMusicGroup> DeleteMusicGroupAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<IMusicGroup> UpdateMusicGroupAsync(csMusicGroupCUdto item)
        {
            throw new NotImplementedException();
        }
        public Task<IMusicGroup> CreateMusicGroupAsync(csMusicGroupCUdto item)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Album CRUD      
        public async Task<csRespPageDto<IAlbum>> ReadAlbumsAsync(bool seeded, bool flat, string filter, int pageNumber, int pageSize)
        {
            string uri = $"csAlbum/Read?seeded=true&flat=false&pageNr=0&pageSize=10";

            //Send the HTTP Message and await the repsonse
            HttpResponseMessage response = await _httpClient.GetAsync(uri);

            //Throw an exception if the response is not successful
            response.EnsureSuccessStatusCode();

            //Get the resonse data
            string s = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<csRespPageDto<IAlbum>>(s, _jsonSettings);
            return resp;
        }
        public Task<IAlbum> ReadAlbumAsync(Guid id, bool flat)
        {
            throw new NotImplementedException();
        }
        public Task<IAlbum> DeleteAlbumAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<IAlbum> UpdateAlbumAsync(csAlbumCUdto item)
        {
            throw new NotImplementedException();
        }
        public Task<IAlbum> CreateAlbumAsync(csAlbumCUdto item)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Artist CRUD 
        public Task<csRespPageDto<IArtist>> ReadArtistsAsync(bool seeded, bool flat, string filter, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
        public Task<IArtist> ReadArtistAsync(Guid id, bool flat)
        {
            throw new NotImplementedException();
        }
        public Task<IArtist> DeleteArtistAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<IArtist> UpdateArtistAsync(csArtistCUdto item)
        {
            throw new NotImplementedException();
        }
        public Task<IArtist> CreateArtistAsync(csArtistCUdto item)
        {
            throw new NotImplementedException();
        }
        public Task<IArtist> UpsertArtistAsync(csArtistCUdto item)
        {
            throw new NotImplementedException();
        }
        #endregion
      
    }
public class AbstractConverter<TReal, TAbstract> 
    : JsonConverter where TReal : TAbstract
{
    public override Boolean CanConvert(Type objectType)
        => objectType == typeof(TAbstract);

    public override Object ReadJson(JsonReader reader, Type type, Object value, JsonSerializer jser)
        => jser.Deserialize<TReal>(reader);

    public override void WriteJson(JsonWriter writer, Object value, JsonSerializer jser)
        => jser.Serialize(writer, value);
}
}
