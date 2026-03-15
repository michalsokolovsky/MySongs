using MySongs.Repository.Entities;
using System.Collections.Generic;

namespace MySongs.Repository.Interfaces
{
    public interface IUserRepository
    {
        List<Users> GetAll();
        Users GetById(int id);
        void Add(Users user);
        void Update(Users user);
        void Delete(int id);
    }
}