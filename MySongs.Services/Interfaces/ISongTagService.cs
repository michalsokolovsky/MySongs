using MySongs.Common.DTOs;
using System.Collections.Generic;

namespace MySongs.Services.Interfaces
{
    public interface ISongTagService
    {
        List<SongTagDto> GetTagsBySongId(int songId);
        void Add(SongTagDto songTag);
        void Delete(int songId, int tagId);
    }
}