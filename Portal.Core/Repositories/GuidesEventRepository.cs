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
    public class GuidesEventRepository : IGuideEventRepository
    {
        private readonly ActivityPortalContext _dbContext;

        public GuidesEventRepository(ActivityPortalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<GuidesEvent> GetAllGuideEvents()
        {
            return _dbContext.Set<GuidesEvent>().ToList();
        }

        public GuidesEvent GetGuideEventById(int id)
        {
            return _dbContext.Set<GuidesEvent>().Find(id);
        }

        public String AddGuideEvent(GuidesEvent product)
        {
            bool exists = _dbContext.Set<GuidesEvent>().Any(e => e.EventId == product.EventId && e.GuideId == product.GuideId);
            if (!exists)
            {
                _dbContext.Set<GuidesEvent>().Add(product);
                _dbContext.SaveChanges();
                return "success";
            }
            return "error";
            
        }

        public void UpdateGuideEvent(GuidesEvent product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteGuideEvent(int id)
        {
            var product = _dbContext.Set<GuidesEvent>().Find(id);
            if (product != null)
            {
                _dbContext.Set<GuidesEvent>().Remove(product);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<dynamic> GetAssignedGuides()
        {
            var data = from ge in _dbContext.GuidesEvents
                       join ev in _dbContext.Events on ge.EventId equals ev.Id
                       join g in _dbContext.Guides on ge.GuideId equals g.Id
                       
                       select new
                       {
                           GuideEventId=ge.Id,
                           EventId = ev.Id,
                           EventName = ev.Name,
                           GuideId= g.Id,
                           GuideFirstName = g.FirstName,
                           GuideLastName =g.LastName,


                       };

            return data.ToList();

        }
    }
}
