using Portal.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Services.Interfaces
{
    
        public interface IEventService
        {
            IEnumerable<Event> GetAllEvents();
            Event GetEventById(int id);
            void AddEvent(Event product);
            void UpdateEvent(Event product);
            void DeleteEvent(int id);
            
        }
    

}
