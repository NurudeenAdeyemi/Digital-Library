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
        public User GetUser(int id);

        public User GetUserByEmail(string email);

        public User RegisterUser(User user);

        public User UpdateUser(int id, UserUpdateDTO model);

        public void Delete(int id);

        public User RegisterLibrarian(User user);

        public IList<User> GetUsers();

        public User Login(string email, string password);

    }
}
