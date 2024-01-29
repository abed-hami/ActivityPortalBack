using Portal.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Interfaces
{
    public interface IUserRepository 
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByEmail(string email, string pass);
        User GetUserByUsername(string email);
        void AddUser(User product);
        void UpdateUser(User product);
        void DeleteUser(int id);
    }
}
