using MySongs.Repository.Entities;
using System.Collections.Generic;

namespace MySongs.Repository.Interfaces
{
    public interface IListeningHistoryRepository
    {
        List<ListeningHistory> GetAll();
        void Add(ListeningHistory history);
    }
}