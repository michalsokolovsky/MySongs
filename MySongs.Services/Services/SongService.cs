using MySongs.Common.DTOs;
using MySongs.Repository.Interfaces;
using MySongs.Repository.Entities;
using MySongs.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MySongs.Services.Services
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _repository;

        public SongService(ISongRepository repository)
        {
            _repository = repository;
        }

        public List<SongDto> GetAll()
        {
            return _repository.GetAll()
                .Select(s => new SongDto
                {
                    SongId = s.SongId,
                    Title = s.Title,
                    ArtistName = s.ArtistName,
                    Genre = s.Genre,
                    ReleaseDate = s.ReleaseDate,
                    LyricsSummary = s.LyricsSummary
                }).ToList();
        }

        public SongDto GetById(int id)
        {
            var s = _repository.GetById(id);
            if (s == null) return null;
            return new SongDto
            {
                SongId = s.SongId,
                Title = s.Title,
                ArtistName = s.ArtistName,
                Genre = s.Genre,
                ReleaseDate = s.ReleaseDate,
                LyricsSummary = s.LyricsSummary
            };
        }

        public void Add(SongDto song)
        {
            _repository.Add(new Songs
            {
                Title = song.Title,
                ArtistName = song.ArtistName,
                Genre = song.Genre,
                ReleaseDate = song.ReleaseDate,
                LyricsSummary = song.LyricsSummary
            });
        }

        public void Update(SongDto song)
        {
            _repository.Update(new Songs
            {
                SongId = song.SongId,
                Title = song.Title,
                ArtistName = song.ArtistName,
                Genre = song.Genre,
                ReleaseDate = song.ReleaseDate,
                LyricsSummary = song.LyricsSummary
            });
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}