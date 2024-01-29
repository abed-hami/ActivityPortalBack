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
    public class GuideService : IGuideService
    {
        private readonly IGuideRepository _guideRepository;

        public GuideService(IGuideRepository guideRepository)
        {
            _guideRepository = guideRepository;
        }

        public IEnumerable<Guide> GetAllGuides()
        {
            return _guideRepository.GetAllGuides(); // Corrected method name
        }

        public Guide GetGuideById(int id)
        {
            return _guideRepository.GetGuideById(id); // Corrected method name
        }

        public void AddGuide(Guide product)
        {
            if (ValidateEvent(product))
            {
                _guideRepository.AddGuide(product); // Corrected method name
            }
            else
            {
                throw new ArgumentException("Invalid event data");
            }
        }

        public void UpdateGuide(Guide product)
        {
            if (ValidateEvent(product))
            {
                _guideRepository.UpdateGuide(product); // Corrected method name
            }
            else
            {
                throw new ArgumentException("Invalid event data");
            }
        }

        public void DeleteGuide(int id)
        {
            _guideRepository.DeleteGuide(id); // Corrected method name
        }

        private bool ValidateEvent(Guide product)
        {
            // Perform validation logic here
            // For example, check if required fields are set and if the date is valid

            if (product.FirstName == "")
            {
                return false;
            }

            return true;
        }
    }
}
