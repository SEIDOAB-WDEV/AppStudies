using System;
using Models;
using Models.DTO;

namespace Services
{
    public interface IMusicService
	{
        //Full set of async methods
        public Task<gstusrInfoAllDto> InfoAsync { get; }
        public Task<gstusrInfoAllDto> SeedAsync(loginUserSessionDto usr, int nrOfItems);
        public Task<gstusrInfoAllDto> RemoveSeedAsync(loginUserSessionDto usr, bool seeded);

        public Task<csRespPageDto<IMusicGroup>> ReadMusicGroupsAsync(loginUserSessionDto usr, bool seeded, bool flat, string filter, int pageNumber, int pageSize);
        public Task<IMusicGroup> ReadMusicGroupAsync(loginUserSessionDto usr, Guid id, bool flat);
        public Task<IMusicGroup> DeleteMusicGroupAsync(loginUserSessionDto usr, Guid id);
        public Task<IMusicGroup> UpdateMusicGroupAsync(loginUserSessionDto usr, csMusicGroupCUdto item);
        public Task<IMusicGroup> CreateMusicGroupAsync(loginUserSessionDto usr, csMusicGroupCUdto item);

        public Task<csRespPageDto<IAlbum>> ReadAlbumsAsync(loginUserSessionDto usr, bool seeded, bool flat, string filter, int pageNumber, int pageSize);
        public Task<IAlbum> ReadAlbumAsync(loginUserSessionDto usr, Guid id, bool flat);
        public Task<IAlbum> DeleteAlbumAsync(loginUserSessionDto usr, Guid id);
        public Task<IAlbum> UpdateAlbumAsync(loginUserSessionDto usr, csAlbumCUdto item);
        public Task<IAlbum> CreateAlbumAsync(loginUserSessionDto usr, csAlbumCUdto item);

        public Task<csRespPageDto<IArtist>> ReadArtistsAsync(loginUserSessionDto usr, bool seeded, bool flat, string filter, int pageNumber, int pageSize);
        public Task<IArtist> ReadArtistAsync(loginUserSessionDto usr, Guid id, bool flat);
        public Task<IArtist> DeleteArtistAsync(loginUserSessionDto usr, Guid id);
        public Task<IArtist> UpdateArtistAsync(loginUserSessionDto usr, csArtistCUdto item);
        public Task<IArtist> CreateArtistAsync(loginUserSessionDto usr, csArtistCUdto item);
    }
}

