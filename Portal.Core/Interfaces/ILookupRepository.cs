using Portal.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Interfaces
{
    public interface ILookupRepository
    {
        IEnumerable<Lookup> GetAllLookups();
        Lookup GetLookupById(int id);
        void AddLookup(Lookup product);
        void UpdateLookup(Lookup product);
        void DeleteLookup(int id);
    }
}
