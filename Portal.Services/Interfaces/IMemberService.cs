using Portal.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Services.Interfaces
{
   public interface IMemberService
    {
        IEnumerable<Member> GetAllMembers();
        Member GetMemberById(int id);
        void AddMember(Member product);
        void UpdateMember(Member product);
        void DeleteMember(int id);
        Member GetMemberByEmail(string email, string pass);
        Member GetMemberByUsername(string email);
    }
}
