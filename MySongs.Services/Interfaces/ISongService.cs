using MySongs.Common.DTOs;
using System.Collections.Generic;

namespace MySongs.Services.Interfaces
{
    public interface ISongService
    {
        List<SongDto> GetAll();
        SongDto GetById(int id);
        void Add(SongDto song);
        void Update(SongDto song);
        void Delete(int id);
    }
}