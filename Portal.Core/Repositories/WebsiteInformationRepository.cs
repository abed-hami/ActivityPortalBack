using ActivityPortal.API.Models;
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
    public class WebsiteInformationRepository: IWebsiteInformationRepository
    {
        private readonly ActivityPortalContext _dbContext;

        public WebsiteInformationRepository(ActivityPortalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<WebsiteInformation> GetAllInformation()
        {
            return _dbContext.Set<WebsiteInformation>().ToList();
        }

        public WebsiteInformation GetInfoById(int id)
        {
            return _dbContext.Set<WebsiteInformation>().Find(id);
        }

        public void AddInfo(WebsiteInformation product)
        {
            _dbContext.Set<WebsiteInformation>().Add(product);
            _dbContext.SaveChanges();
        }

        public void UpdateInfo(WebsiteInformation product)
        {


            var existingEntity = _dbContext.Set<WebsiteInformation>().Local.FirstOrDefault(e => e.Id == product.Id);
            if (existingEntity != null)
            {
                _dbContext.Entry(existingEntity).State = EntityState.Detached;
            }

            // Attach the modified entity
            _dbContext.Entry(product).State = EntityState.Modified;

            _dbContext.SaveChanges();


        }


        public void DeleteInfo(int id)
        {
            var product = _dbContext.Set<WebsiteInformation>().Find(id);
            if (product != null)
            {
                _dbContext.Set<WebsiteInformation>().Remove(product);
                _dbContext.SaveChanges();
            }
        }


    }
}

