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
    public class UsersRoleRepository : IUserRoleRepository
    {
        private readonly ActivityPortalContext _dbContext;

        public UsersRoleRepository(ActivityPortalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<UsersRole> GetAllUserRoles()
        {
            return _dbContext.Set<UsersRole>().ToList();
        }

        public UsersRole GetUserRoleById(int id)
        {
            return _dbContext.Set<UsersRole>().Find(id);
        }

        public void AddUserRole(UsersRole product)
        {
            _dbContext.Set<UsersRole>().Add(product);
            _dbContext.SaveChanges();
        }

        public void UpdateUserRole(UsersRole product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteUserRole(int id)
        {
            var product = _dbContext.Set<UsersRole>().Find(id);
            if (product != null)
            {
                _dbContext.Set<UsersRole>().Remove(product);
                _dbContext.SaveChanges();
            }
        }
    }
}
