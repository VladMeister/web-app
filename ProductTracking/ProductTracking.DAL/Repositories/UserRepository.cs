using Microsoft.EntityFrameworkCore;
using ProductTracking.DAL.EF;
using ProductTracking.DAL.Entities;
using ProductTracking.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ProductTracking.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ProductTrackingContext _trackingContext;

        public UserRepository(ProductTrackingContext dbContext)
        {
            _trackingContext = dbContext;
        }

        public void Add(User user)
        {
            if (!_trackingContext.Users.Any(u => u.Login == user.Login) && user != null)
            {
                _trackingContext.Users.Add(user);
            }
        }

        public IEnumerable<User> GetAll()
        {
            if (_trackingContext.Users.Include(u => u.Role).Count() != 0)
            {
                return _trackingContext.Users.Include(u => u.Role).Where(u => u.Id != 1).AsNoTracking().ToList();
            }

            return Enumerable.Empty<User>();
        }

        public void Update(User user)
        {
            if (user != null)
            {
                _trackingContext.Entry(user).State = EntityState.Modified;
            }
        }

        public void Delete(User user)
        {
            var userToDelete = _trackingContext.Users.FirstOrDefault(u => u.Id == user.Id);

            if (userToDelete != null)
            {
                _trackingContext.Users.Remove(userToDelete);
            }
        }

        public bool Existing(string login, string password)
        {
            return _trackingContext.Users.Any(u => (u.Login == login) && (u.Password == password));
        }

        public string GetRole(string login)
        {
            User user = _trackingContext.Users.Include(u => u.Role).FirstOrDefault(u => u.Login == login);

            if (user != null && user.Role != null)
            {
                return user.Role.Name;
            }
            else
            {
                return "user";
            }
        }

        public User GetById(int? id)
        {
            return _trackingContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public User GetByLogin(string login)
        {
            return _trackingContext.Users.FirstOrDefault(u => u.Login.StartsWith(login));
        }
    }
}
