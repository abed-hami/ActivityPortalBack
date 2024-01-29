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
    public class MembersEventRepository : IMemberEventRepository
    {
        private readonly ActivityPortalContext _dbContext;

        public MembersEventRepository(ActivityPortalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<MembersEvent> GetAllMemberEvents()
        {
            return _dbContext.Set<MembersEvent>().ToList();
        }

        public MembersEvent GetMemberEventById(int id)
        {
            return _dbContext.Set<MembersEvent>().Find(id);
        }

        public int GetCount()
        {
            return _dbContext.Set<MembersEvent>().Count();
        }

        public String AddMemberEvent(MembersEvent product)
        {
            bool exists = _dbContext.Set<MembersEvent>().Any(e=> e.EventsId == product.EventsId && e.MemberId==product.MemberId);
            if (!exists)
            {
                _dbContext.Set<MembersEvent>().Add(product);
                _dbContext.SaveChanges();
                return "success";
            }
            return "error";
            
            
        }

        public void UpdateMemberEvent(MembersEvent product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteMemberEvent(int id)
        {
            var product = _dbContext.Set<MembersEvent>().Find(id);
            if (product != null)
            {
                _dbContext.Set<MembersEvent>().Remove(product);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<dynamic> GetName(string id)
        {
            var data = from me in _dbContext.MembersEvents
                       join ev in _dbContext.Events on me.EventsId equals ev.Id
                       join m in _dbContext.Members on me.MemberId equals m.Id
                       where m.Email == id
                       select new
                       {
                           ReservationId = me.Id,
                           EventId = ev.Id,
                           EventName = ev.Name,
                           MemberId = me.MemberId,
                           EventEndDate= ev.EndDate,
                           MemberFirstName=m.FirstName, 
                           MemberLastName=m.LastName,
                           Status= ev.Status
                          
                       };

            return data.ToList();

        }
    }
}
