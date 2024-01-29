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
    public class  MemberEventService : IMemberEventService
    {
        private readonly IMemberEventRepository _memberEventRepository;

        public MemberEventService(IMemberEventRepository memberEventRepository)
        {
            _memberEventRepository = memberEventRepository;
        }

        public IEnumerable<MembersEvent> GetAllMemberEvents()
        {
            return _memberEventRepository.GetAllMemberEvents(); // Corrected method name
        }

        public IEnumerable<dynamic> GetName(string id)
        {
            return _memberEventRepository.GetName(id); // Corrected method name
        }

        public int GetCount()
        {
            return _memberEventRepository.GetCount();
        }

        public MembersEvent GetMemberEventById(int id)
        {
            return _memberEventRepository.GetMemberEventById(id); // Corrected method name
        }

        public String AddMemberEvent(MembersEvent product)
        {
            if (ValidateEvent(product))
            {
                return _memberEventRepository.AddMemberEvent(product);
               // Corrected method name
            }
            else
            {
                throw new ArgumentException("Invalid event data");
            }
        }

        

        public void UpdateMemberEvent(MembersEvent product)
        {
            if (ValidateEvent(product))
            {
                _memberEventRepository.UpdateMemberEvent(product); // Corrected method name
            }
            else
            {
                throw new ArgumentException("Invalid event data");
            }
        }

        public void DeleteMemberEvent(int id)
        {
            _memberEventRepository.DeleteMemberEvent(id); // Corrected method name
        }

        private bool ValidateEvent(MembersEvent product)
        {
            // Perform validation logic here
            // For example, check if required fields are set and if the date is valid

            if (product.MemberId == null)
            {
                return false;
            }

            return true;
        }
    }
}
