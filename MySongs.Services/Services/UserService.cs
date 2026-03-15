using MySongs.Common.DTOs;
using MySongs.Repository.Interfaces;
using MySongs.Repository.Entities;
using MySongs.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MySongs.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public List<UserDto> GetAll()
        {
            return _repository.GetAll()
                .Select(u => new UserDto
                {
                    UserId = u.UserId,
                    Username = u.Username,
                    Email = u.Email,
                    CreatedAt = u.CreatedAt
                }).ToList();
        }

        public UserDto GetById(int id)
        {
            var u = _repository.GetById(id);
            if (u == null) return null;
            return new UserDto
            {
                UserId = u.UserId,
                Username = u.Username,
                Email = u.Email,
                CreatedAt = u.CreatedAt
            };
        }

        public void Add(UserDto user)
        {
            _repository.Add(new Users
            {
                Username = user.Username,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            });
        }

        public void Update(UserDto user)
        {
            _repository.Update(new Users
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            });
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}