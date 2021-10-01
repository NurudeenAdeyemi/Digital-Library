using Core.DTOs;
using Core.Enums;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User GetUser(int id)
        {
            return _userRepository.GetUser(id);
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public User Login(string email, string password)
        {
            var user = _userRepository.GetUserByEmail(email);
            if (user != null && user.PasswordHash == password)
            {
                return user;
            }
            return null;
        }

        public IList<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public User RegisterUser(User user)
        {
            user.Status = AccountStatus.ACTIVE;
            user.LibraryIdentificationNumber = new Guid().ToString();
            user.UserType = UserType.LibraryUser;
            return _userRepository.AddUser(user);
        }

        public User RegisterLibrarian(User user)
        {

            user.LibrarianIdentificationNumber = new Guid().ToString();
            return _userRepository.AddUser(user);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public User UpdateUser(int id, UserUpdateDTO model)
        {
            var user = _userRepository.GetUser(id);
            user.Status = model.Status;
            user.UserType = model.UserType;
            return _userRepository.UpdateUser(user);
        }
    }

}
