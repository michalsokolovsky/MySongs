using MySongs.Common.DTOs;
using System.Collections.Generic;

namespace MySongs.Services.Interfaces
{
    public interface IListeningHistoryService
    {
        List<ListeningHistoryDto> GetAll();
        void Add(ListeningHistoryDto history);
    }
}