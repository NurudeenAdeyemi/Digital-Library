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
        public UserModel GetUser(int id)
        {
            var user = _userRepository.GetUser(id);
            return new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Status = user.Status,
                UserType = user.UserType,
                Country = user.Country,
                LibrarianIdentificationNumber = user.LibrarianIdentificationNumber,
                LibraryIdentificationNumber = user.LibraryIdentificationNumber,
                PhoneNumber = user.PhoneNumber,
                University = user.University
            };
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

        public BaseResponse RegisterUser(CreateUserRequestModel model)
        {
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Country = model.Country,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Status = AccountStatus.ACTIVE,
                UserType = UserType.LibraryUser,
                LibraryIdentificationNumber = Guid.NewGuid().ToString().Substring(0, 5).ToUpper(),
                University = model.University,
                PasswordHash = model.PasswordHash
            };
            
            _userRepository.AddUser(user);
            return new BaseResponse
            {
                Status = true,
                Message = "User successfully registered"
            };
        }

        public User RegisterLibrarian(User user)
        {

            user.LibrarianIdentificationNumber = Guid.NewGuid().ToString().Substring(0, 5).ToUpper();
            return _userRepository.AddUser(user);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public BaseResponse UpgrageLibraryUser(int id, UpgradeLibraryUserRequestModel model)
        {
            var user = _userRepository.GetUser(id);

            user.UserType = model.UserType;
            _userRepository.UpdateUser(user);
            return new BaseResponse
            {
                Status = true,
                Message = "Succesfully updated"
            };
        }

        public BaseResponse UpdateUserStatus(int id, UpdateUserStatusRequestModel model)
        {
            var user = _userRepository.GetUser(id);
            user.Status = model.Status;
            _userRepository.UpdateUser(user);
            return new BaseResponse
            {
                Status = true,
                Message = "Succesfully updated"
            };
        }
       /* public BaseResponse UpdateUser(int id, UserUpdateDTO model)
        {
            var user = _userRepository.GetUser(id);
            user.Status = model.Status;
            user.UserType = model.UserType;
            _userRepository.UpdateUser(user);
            return new BaseResponse
            {
                Status = true,
                Message = "Succesfully updated"
            };
        }*/
    }

}
