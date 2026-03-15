using MySongs.Repository.Entities;
using MySongs.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MySongs.Repository.Repositories
{
    public class ListeningHistoryRepository : IListeningHistoryRepository
    {
        private readonly IContext _context;

        public ListeningHistoryRepository(IContext context)
        {
            _context = context;
        }

        public List<ListeningHistory> GetAll()
        {
            return _context.ListeningHistorys.ToList();
        }

        public void Add(ListeningHistory history)
        {
            _context.ListeningHistorys.Add(history);
            _context.SaveChanges();
        }
    }
}