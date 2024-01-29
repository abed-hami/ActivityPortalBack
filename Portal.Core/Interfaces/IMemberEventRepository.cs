using Portal.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Interfaces
{
    public interface IMemberEventRepository 
    {
        IEnumerable<MembersEvent> GetAllMemberEvents();
        MembersEvent GetMemberEventById(int id);
        String AddMemberEvent(MembersEvent product);
        void UpdateMemberEvent(MembersEvent product);
        void DeleteMemberEvent(int id);
        IEnumerable<dynamic> GetName(string id);
        int GetCount();

    }
}
