using Portal.Core.Interfaces;
using Portal.Core.Models;
using Portal.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Portal.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _eventRepository.GetAllEvents(); // Corrected method name
        }

        public Event GetEventById(int id)
        {
            return _eventRepository.GetEventById(id); // Corrected method name
        }

        public void AddEvent(Event product)
        {
            if (ValidateEvent(product))
            {
                _eventRepository.AddEvent(product); // Corrected method name
            }
            else
            {
                throw new ArgumentException("Invalid event data");
            }
        }

        public void UpdateEvent( Event product)
        {
            
            
                _eventRepository.UpdateEvent(product); // Corrected method name
           
        }

        public void DeleteEvent(int id)
        {
            _eventRepository.DeleteEvent(id); // Corrected method name
        }

      

        private bool ValidateEvent(Event product)
        {
            // Perform validation logic here
            // For example, check if required fields are set and if the date is valid

            if (string.IsNullOrWhiteSpace(product.Name))
            {
                return false;
            }

            return true;
        }
    }
}
