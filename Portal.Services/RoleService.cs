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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository guideRepository)
        {
            _roleRepository = guideRepository;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _roleRepository.GetAllRoles(); // Corrected method name
        }

        public Role GetRoleById(int id)
        {
            return _roleRepository.GetRoleById(id); // Corrected method name
        }

        public void AddRole(Role product)
        {
            if (ValidateEvent(product))
            {
                _roleRepository.AddRole(product); // Corrected method name
            }
            else
            {
                throw new ArgumentException("Invalid event data");
            }
        }

        public void UpdateRole(Role product)
        {
            if (ValidateEvent(product))
            {
                _roleRepository.UpdateRole(product); // Corrected method name
            }
            else
            {
                throw new ArgumentException("Invalid event data");
            }
        }

        public void DeleteRole(int id)
        {
            _roleRepository.DeleteRole(id); // Corrected method name
        }

        private bool ValidateEvent(Role product)
        {
            // Perform validation logic here
            // For example, check if required fields are set and if the date is valid

            if (product.Name == "")
            {
                return false;
            }

            return true;
        }
    }
}
