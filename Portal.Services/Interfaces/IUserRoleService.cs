using Portal.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Services.Interfaces
{
    public interface IUserRoleService
    {
        IEnumerable<UsersRole> GetAllUserRoles();
        UsersRole GetUserRoleById(int id);
        void AddUserRole(UsersRole product);
        void UpdateUserRole(UsersRole product);
        void DeleteUserRole(int id);
    }
}
