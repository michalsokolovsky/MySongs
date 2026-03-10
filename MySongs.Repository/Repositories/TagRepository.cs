using MySongs.Repository.Entities;
using MySongs.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MySongs.Repository.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly IContext _context;

        public TagRepository(IContext context)
        {
            _context = context;
        }

        public List<Tag> GetAll()
        {
            return _context.Tags.ToList();
        }

        public void Add(Tag tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
        }
    }
}