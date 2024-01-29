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
    public class LookupRepository : ILookupRepository
    {
        private readonly ActivityPortalContext _dbContext;

        public LookupRepository(ActivityPortalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Lookup> GetAllLookups()
        {
            return _dbContext.Set<Lookup>().ToList();
        }

        public Lookup GetLookupById(int id)
        {
            return _dbContext.Set<Lookup>().Find(id);
        }

        public void AddLookup(Lookup product)
        {
            _dbContext.Set<Lookup>().Add(product);
            _dbContext.SaveChanges();
        }

        public void UpdateLookup(Lookup product)
        {
            var existingEntity = _dbContext.Set<Lookup>().Local.FirstOrDefault(e => e.Id == product.Id);
            if (existingEntity != null)
            {
                _dbContext.Entry(existingEntity).State = EntityState.Detached;
            }

            // Attach the modified entity
            _dbContext.Entry(product).State = EntityState.Modified;

            _dbContext.SaveChanges();
        }

        public void DeleteLookup(int id)
        {
            var product = _dbContext.Set<Lookup>().Find(id);
            if (product != null)
            {
                _dbContext.Set<Lookup>().Remove(product);
                _dbContext.SaveChanges();
            }
        }
    }
}
