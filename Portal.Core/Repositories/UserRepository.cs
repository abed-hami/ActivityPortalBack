using Microsoft.EntityFrameworkCore;
using Portal.Core.Interfaces;
using Portal.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ActivityPortalContext _dbContext;

        public UserRepository(ActivityPortalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.Set<User>().ToList();
        }

        public User GetUserById(int id)
        {
            return _dbContext.Set<User>().Find(id);
        }

        public User GetUserByEmail(string email, string pass)
        {
            return _dbContext.Set<User>().FirstOrDefault(u => u.Email == email && u.Password==pass);
        }
        public User GetUserByUsername(string email)
        {
            return _dbContext.Set<User>().FirstOrDefault(u => u.Email == email);
        }
        public void AddUser(User product)
        {
            _dbContext.Set<User>().Add(product);
            _dbContext.SaveChanges();
        }

        public void UpdateUser(User product)
        {
            

            var existingEntity = _dbContext.Set<User>().Local.FirstOrDefault(e => e.Id == product.Id);
            if (existingEntity != null)
            {
                _dbContext.Entry(existingEntity).State = EntityState.Detached;
            }

            // Attach the modified entity
            _dbContext.Entry(product).State = EntityState.Modified;

            _dbContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var product = _dbContext.Set<User>().Find(id);
            if (product != null)
            {
                _dbContext.Set<User>().Remove(product);
                _dbContext.SaveChanges();
            }
        }
    }
}
