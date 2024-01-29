using Azure.Identity;
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
    public class EventRepository : IEventRepository
    {
        private readonly ActivityPortalContext _dbContext;

        public EventRepository(ActivityPortalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _dbContext.Set<Event>().ToList();
        }

        public Event GetEventById(int id)
        {
            return _dbContext.Set<Event>().Find(id);
        }

        public void AddEvent(Event product)
        {
            _dbContext.Set<Event>().Add(product);
            _dbContext.SaveChanges();
        }

        public void UpdateEvent(Event product)
        {
            
                
                var existingEntity = _dbContext.Set<Event>().Local.FirstOrDefault(e => e.Id == product.Id);
                if (existingEntity != null)
                {
                    _dbContext.Entry(existingEntity).State = EntityState.Detached;
                }

                // Attach the modified entity
                _dbContext.Entry(product).State = EntityState.Modified;

                _dbContext.SaveChanges();
            

        }

        
        public void DeleteEvent(int id)
        {
            var product = _dbContext.Set<Event>().Find(id);
            if (product != null)
            {
                _dbContext.Set<Event>().Remove(product);
                _dbContext.SaveChanges();
            }
        }

        
    }
}
