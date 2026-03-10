using MySongs.Repository.Entities;
using MySongs.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MySongs.Repository.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly IContext _context;

        public SongRepository(IContext context)
        {
            _context = context;
        }

        public List<Songs> GetAll()
        {
            return _context.Songs.ToList();
        }

        public Songs GetById(int id)
        {
            return _context.Songs.FirstOrDefault(s => s.SongId == id);
        }

        public void Add(Songs song)
        {
            _context.Songs.Add(song);
            _context.SaveChanges();
        }

        public void Update(Songs song)
        {
            _context.Songs.Update(song);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var song = _context.Songs.FirstOrDefault(s => s.SongId == id);
            if (song != null)
            {
                _context.Songs.Remove(song);
                _context.SaveChanges();
            }
        }
    }
}
