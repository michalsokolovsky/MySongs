using MySongs.Repository.Entities;
using System.Collections.Generic;

namespace MySongs.Repository.Interfaces
{
    public interface ITagRepository
    {
        List<Tag> GetAll();
        void Add(Tag tag);
    }
}