using MySongs.Repository.Entities;
using MySongs.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MySongs.Repository.Repositories
{
    public class SongTagRepository : ISongTagRepository
    {
        private readonly IContext _context;

        public SongTagRepository(IContext context)
        {
            _context = context;
        }

        public List<SongTag> GetTagsBySongId(int songId)
        {
            return _context.SongTags
                .Where(st => st.SongId == songId)
                .ToList();
        }

        public void Add(SongTag songTag)
        {
            _context.SongTags.Add(songTag);
            _context.SaveChanges();
        }

        public void Delete(int songId, int tagId)
        {
            var songTag = _context.SongTags
                .FirstOrDefault(st => st.SongId == songId && st.TagId == tagId);
            if (songTag != null)
            {
                _context.SongTags.Remove(songTag);
                _context.SaveChanges();
            }
        }
    }
}