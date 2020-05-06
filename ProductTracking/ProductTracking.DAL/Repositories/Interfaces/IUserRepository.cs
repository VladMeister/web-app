using ProductTracking.DAL.Entities;
using System.Collections.Generic;

namespace ProductTracking.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        void Delete(User user);
        bool Existing(string login, string password);
        IEnumerable<User> GetAll();
        User GetById(int? id);
        User GetByLogin(string login);
        string GetRole(string login);
        void Update(User user);
    }
}