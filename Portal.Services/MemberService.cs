using Portal.Core.Interfaces;
using Portal.Core.Models;
using Portal.Core.Repositories;
using Portal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository guideRepository)
        {
            _memberRepository = guideRepository;
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return _memberRepository.GetAllMembers(); // Corrected method name
        }

        public Member GetMemberById(int id)
        {
            return _memberRepository.GetMemberById(id); // Corrected method name
        }

        public void AddMember(Member product)
        {
            if (ValidateEvent(product))
            {
                _memberRepository.AddMember(product); // Corrected method name
            }
            else
            {
                throw new ArgumentException("Invalid event data");
            }
        }

        public void UpdateMember(Member product)
        {
            if (ValidateEvent(product))
            {
                _memberRepository.UpdateMember(product); // Corrected method name
            }
            else
            {
                throw new ArgumentException("Invalid event data");
            }
        }

        public void DeleteMember(int id)
        {
            _memberRepository.DeleteMember(id); // Corrected method name
        }

        public Member GetMemberByEmail(string email, string pass)
        {
            return _memberRepository.GetMemberByEmail(email, pass); // Corrected method name
        }

        public Member GetMemberByUsername(string email)
        {
            return _memberRepository.GetMemberByUsername(email); // Corrected method name
        }

        private bool ValidateEvent(Member product)
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
