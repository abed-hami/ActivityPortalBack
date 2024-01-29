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
    public class RoleRepository : IRoleRepository
    {
        private readonly ActivityPortalContext _dbContext;

        public RoleRepository(ActivityPortalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _dbContext.Set<Role>().ToList();
        }

        public Role GetRoleById(int id)
        {
            return _dbContext.Set<Role>().Find(id);
        }

        public void AddRole(Role product)
        {
            _dbContext.Set<Role>().Add(product);
            _dbContext.SaveChanges();
        }

        public void UpdateRole(Role product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteRole(int id)
        {
            var product = _dbContext.Set<Role>().Find(id);
            if (product != null)
            {
                _dbContext.Set<Role>().Remove(product);
                _dbContext.SaveChanges();
            }
        }
    }
}
