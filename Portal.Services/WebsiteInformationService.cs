using ActivityPortal.API.Models;
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
    public class WebsiteInformationService: IWebInformationService
    {
        private readonly IWebsiteInformationRepository _infoRepository;

        public WebsiteInformationService(IWebsiteInformationRepository infoRepository)
        {
            _infoRepository = infoRepository;
        }

        public IEnumerable<WebsiteInformation> GetAllInformation()
        {
            return _infoRepository.GetAllInformation(); // Corrected method name
        }

        public WebsiteInformation GetInfoById(int id)
        {
            return _infoRepository.GetInfoById(id); // Corrected method name
        }

        public void AddInfo(WebsiteInformation product)
        {
            try
            {
                _infoRepository.AddInfo(product); 
            }
            catch(Exception ex)
            {
                throw(ex);
            }
               // Corrected method name
            
           
        }

        public void UpdateInfo(WebsiteInformation product)
        {


            _infoRepository.UpdateInfo(product); // Corrected method name

        }

        public void DeleteInfo(int id)
        {
            _infoRepository.DeleteInfo(id); // Corrected method name
        }



        private bool ValidateEvent(WebsiteInformation product)
        {
            // Perform validation logic here
            // For example, check if required fields are set and if the date is valid

            if (product.Id==0)
            {
                return false;
            }

            return true;
        }
    }
}

