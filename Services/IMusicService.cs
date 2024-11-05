using System;
using Models;
using Models.DTO;

namespace Services
{
    public interface IMusicService
	{
        //Full set of async methods
        public Task<gstusrInfoAllDto> InfoAsync { get; }
        public Task<gstusrInfoAllDto> SeedAsync(int nrOfItems);
        public Task<gstusrInfoAllDto> RemoveSeedAsync(bool seeded);

        public Task<csRespPageDto<IMusicGroup>> ReadMusicGroupsAsync(bool seeded, bool flat, string filter, int pageNumber, int pageSize);
        public Task<IMusicGroup> ReadMusicGroupAsync(Guid id, bool flat);
        public Task<IMusicGroup> DeleteMusicGroupAsync(Guid id);
        public Task<IMusicGroup> UpdateMusicGroupAsync(csMusicGroupCUdto item);
        public Task<IMusicGroup> CreateMusicGroupAsync(csMusicGroupCUdto item);

        public Task<csRespPageDto<IAlbum>> ReadAlbumsAsync(bool seeded, bool flat, string filter, int pageNumber, int pageSize);
        public Task<IAlbum> ReadAlbumAsync(Guid id, bool flat);
        public Task<IAlbum> DeleteAlbumAsync(Guid id);
        public Task<IAlbum> UpdateAlbumAsync(csAlbumCUdto item);
        public Task<IAlbum> CreateAlbumAsync(csAlbumCUdto item);

        public Task<csRespPageDto<IArtist>> ReadArtistsAsync(bool seeded, bool flat, string filter, int pageNumber, int pageSize);
        public Task<IArtist> ReadArtistAsync(Guid id, bool flat);
        public Task<IArtist> DeleteArtistAsync(Guid id);
        public Task<IArtist> UpdateArtistAsync(csArtistCUdto item);
        public Task<IArtist> CreateArtistAsync(csArtistCUdto item);
        public Task<IArtist> UpsertArtistAsync(csArtistCUdto item);
    }
}

