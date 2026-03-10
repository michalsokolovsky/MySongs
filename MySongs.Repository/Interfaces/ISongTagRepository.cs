using MySongs.Repository.Entities;
using System.Collections.Generic;

namespace MySongs.Repository.Interfaces
{
    public interface ISongTagRepository
    {
        List<SongTag> GetTagsBySongId(int songId);
        void Add(SongTag songTag);
        void Delete(int songId, int tagId);
    }
}