using MySongs.Common.DTOs;
using System.Collections.Generic;

namespace MySongs.Services.Interfaces
{
    public interface IUserService
    {
        List<UserDto> GetAll();
        UserDto GetById(int id);
        void Add(UserDto user);
        void Update(UserDto user);
        void Delete(int id);
    }
}