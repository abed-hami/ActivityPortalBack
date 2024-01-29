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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository guideRepository)
        {
            _userRepository = guideRepository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers(); // Corrected method name
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id); // Corrected method name
        }

        public User GetUserByEmail(string email, string pass)
        {
            return _userRepository.GetUserByEmail(email,pass); // Corrected method name
        }

        public User GetUserByUsername(string email)
        {
            return _userRepository.GetUserByUsername(email); // Corrected method name
        }

        public void AddUser(User product)
        {
            if (ValidateEvent(product))
            {
                _userRepository.AddUser(product); // Corrected method name
            }
            else
            {
                throw new ArgumentException("Invalid event data");
            }
        }

        public void UpdateUser(User product)
        {
            if (ValidateEvent(product))
            {
                _userRepository.UpdateUser(product); // Corrected method name
            }
            else
            {
                throw new ArgumentException("Invalid event data");
            }
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id); // Corrected method name
        }

        private bool ValidateEvent(User product)
        {
            // Perform validation logic here
            // For example, check if required fields are set and if the date is valid

            if (product.FisrtName == "")
            {
                return false;
            }

            return true;
        }
    }
}
