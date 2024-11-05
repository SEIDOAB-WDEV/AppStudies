using System;
using Configuration;

namespace Models.DTO
{
    public class gstusrInfoDbDto
	{
        public int nrSeededMusicGroups { get; set; } = 0;
        public int nrUnseededMusicGroups { get; set; } = 0;

        public int nrSeededAlbums { get; set; } = 0;
        public int nrUnseededAlbums { get; set; } = 0;

        public int nrSeededArtists { get; set; } = 0;
        public int nrUnseededArtists { get; set; } = 0;
    }
    public class gstusrInfoAllDto
    {
        public gstusrInfoDbDto Db { get; set; } = null;
    }
}

