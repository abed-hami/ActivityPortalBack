using ActivityPortal.API.Models;
using Portal.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Interfaces
{
    public interface IWebsiteInformationRepository
    {
        IEnumerable<WebsiteInformation> GetAllInformation();
        WebsiteInformation GetInfoById(int id);
        void AddInfo(WebsiteInformation product);
        void UpdateInfo(WebsiteInformation product);
        void DeleteInfo(int id);
    }
}
