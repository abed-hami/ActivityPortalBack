using Portal.Core.Interfaces;
using Portal.Core.Models;
using Portal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Services
{
    public class GuideEventService : IGuideEventService
    {
        private readonly IGuideEventRepository _guideEventRepository;

        public GuideEventService(IGuideEventRepository guideEventRepository)
        {
            _guideEventRepository = guideEventRepository;
        }

        public IEnumerable<GuidesEvent> GetAllGuideEvents()
        {
            return _guideEventRepository.GetAllGuideEvents(); // Corrected method name
        }

        public GuidesEvent GetGuideEventById(int id)
        {
            return _guideEventRepository.GetGuideEventById(id); // Corrected method name
        }

        public String AddGuideEvent(GuidesEvent product)
        {
            if (ValidateEvent(product))
            {
                return _guideEventRepository.AddGuideEvent(product); // Corrected method name
            }
            else
            {
                throw new ArgumentException("Invalid event data");
            }
        }

        public IEnumerable<dynamic> GetAssignedGuides()
        {
            return _guideEventRepository.GetAssignedGuides();
        }

        public void UpdateGuideEvent(GuidesEvent product)
        {
            if (ValidateEvent(product))
            {
                _guideEventRepository.UpdateGuideEvent(product); // Corrected method name
            }
            else
            {
                throw new ArgumentException("Invalid event data");
            }
        }

        public void DeleteGuideEvent(int id)
        {
            _guideEventRepository.DeleteGuideEvent(id); // Corrected method name
        }

        private bool ValidateEvent(GuidesEvent product)
        {
            // Perform validation logic here
            // For example, check if required fields are set and if the date is valid

            if (product.GuideId ==0)
            {
                return false;
            }

            return true;
        }
    }
}
