using MySongs.Common.DTOs;
using MySongs.Repository.Interfaces;
using MySongs.Repository.Entities;
using MySongs.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MySongs.Services.Services
{
    public class SongTagService : ISongTagService
    {
        private readonly ISongTagRepository _repository;

        public SongTagService(ISongTagRepository repository)
        {
            _repository = repository;
        }

        public List<SongTagDto> GetTagsBySongId(int songId)
        {
            return _repository.GetTagsBySongId(songId)
                .Select(st => new SongTagDto
                {
                    SongId = st.SongId,
                    TagId = st.TagId
                }).ToList();
        }

        public void Add(SongTagDto songTag)
        {
            _repository.Add(new SongTag
            {
                SongId = songTag.SongId,
                TagId = songTag.TagId
            });
        }

        public void Delete(int songId, int tagId)
        {
            _repository.Delete(songId, tagId);
        }
    }
}