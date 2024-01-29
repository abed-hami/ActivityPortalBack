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
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleService(IUserRoleRepository guideRepository)
        {
            _userRoleRepository = guideRepository;
        }

        public IEnumerable<UsersRole> GetAllUserRoles()
        {
            return _userRoleRepository.GetAllUserRoles(); // Corrected method name
        }

        public UsersRole GetUserRoleById(int id)
        {
            return _userRoleRepository.GetUserRoleById(id); // Corrected method name
        }

        public void AddUserRole(UsersRole product)
        {
            if (ValidateEvent(product))
            {
                _userRoleRepository.AddUserRole(product); // Corrected method name
            }
            else
            {
                throw new ArgumentException("Invalid event data");
            }
        }

        public void UpdateUserRole(UsersRole product)
        {
            if (ValidateEvent(product))
            {
                _userRoleRepository.UpdateUserRole(product); // Corrected method name
            }
            else
            {
                throw new ArgumentException("Invalid event data");
            }
        }

        public void DeleteUserRole(int id)
        {
            _userRoleRepository.DeleteUserRole(id); // Corrected method name
        }

        private bool ValidateEvent(UsersRole product)
        {
            // Perform validation logic here
            // For example, check if required fields are set and if the date is valid

            if (product.UserId == 0)
            {
                return false;
            }

            return true;
        }
    }
}
