using Core.DTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IUserService
    {
        public UserModel GetUser(int id);

        public User GetUserByEmail(string email);

        public BaseResponse RegisterUser(CreateUserRequestModel model);

        public BaseResponse UpdateUserStatus(int id, UpdateUserStatusRequestModel model);

        public BaseResponse UpgrageLibraryUser(int id, UpgradeLibraryUserRequestModel model);

        //public BaseResponse UpdateUser(int id, UserUpdateDTO model);

        public void Delete(int id);

        public User RegisterLibrarian(User user);

        public IList<User> GetUsers();

        public User Login(string email, string password);

    }
}
