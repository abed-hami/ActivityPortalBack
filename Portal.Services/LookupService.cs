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
    public class LookupService : ILookupService
    {
        private readonly ILookupRepository _lookupRepository;

        public LookupService(ILookupRepository guideRepository)
        {
            _lookupRepository = guideRepository;
        }

        public IEnumerable<Lookup> GetAllLookups()
        {
            return _lookupRepository.GetAllLookups(); // Corrected method name
        }

        public Lookup GetLookupById(int id)
        {
            return _lookupRepository.GetLookupById(id); // Corrected method name
        }

        public void AddLookup(Lookup product)
        {
            if (ValidateEvent(product))
            {
                _lookupRepository.AddLookup(product); // Corrected method name
            }
            else
            {
                throw new ArgumentException("Invalid event data");
            }
        }

        public void UpdateLookup(Lookup product)
        {
            if (ValidateEvent(product))
            {
                _lookupRepository.UpdateLookup(product); // Corrected method name
            }
            else
            {
                throw new ArgumentException("Invalid event data");
            }
        }

        public void DeleteLookup(int id)
        {
            _lookupRepository.DeleteLookup(id); // Corrected method name
        }

        private bool ValidateEvent(Lookup product)
        {
            // Perform validation logic here
            // For example, check if required fields are set and if the date is valid

            if (product.Orders == "")
            {
                return false;
            }

            return true;
        }
    }
}
