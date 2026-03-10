using MySongs.Common.DTOs;
using MySongs.Repository.Interfaces;
using MySongs.Repository.Entities;
using MySongs.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MySongs.Services.Services
{
    public class ListeningHistoryService : IListeningHistoryService
    {
        private readonly IListeningHistoryRepository _repository;

        public ListeningHistoryService(IListeningHistoryRepository repository)
        {
            _repository = repository;
        }

        public List<ListeningHistoryDto> GetAll()
        {
            return _repository.GetAll()
                .Select(h => new ListeningHistoryDto
                {
                    HistoryId = h.HistoryId,
                    UserId = h.UserId,
                    SongId = h.SongId,
                    ListenDate = h.ListenDate,
                    Duration = h.Duration
                }).ToList();
        }

        public void Add(ListeningHistoryDto history)
        {
            _repository.Add(new ListeningHistory
            {
                UserId = history.UserId,
                SongId = history.SongId,
                ListenDate = history.ListenDate,
                Duration = history.Duration
            });
        }
    }
}