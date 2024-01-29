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
    public class GuideRepository : IGuideRepository
    {
        private readonly ActivityPortalContext _dbContext;

        public GuideRepository(ActivityPortalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Guide> GetAllGuides()
        {
            return _dbContext.Set<Guide>().ToList();
        }

        public Guide GetGuideById(int id)
        {
            return _dbContext.Set<Guide>().Find(id);
        }

        public void AddGuide(Guide product)
        {
            _dbContext.Set<Guide>().Add(product);
            _dbContext.SaveChanges();
        }

        public void UpdateGuide(Guide product)
        {
            var existingEntity = _dbContext.Set<Guide>().Local.FirstOrDefault(e => e.Id == product.Id);
            if (existingEntity != null)
            {
                _dbContext.Entry(existingEntity).State = EntityState.Detached;
            }

            // Attach the modified entity
            _dbContext.Entry(product).State = EntityState.Modified;

            _dbContext.SaveChanges();
           
        }

        public void DeleteGuide(int id)
        {
            var product = _dbContext.Set<Guide>().Find(id);
            if (product != null)
            {
                _dbContext.Set<Guide>().Remove(product);
                _dbContext.SaveChanges();
            }
        }
    }
}
