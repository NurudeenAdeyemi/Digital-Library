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

        public IList<User> GetUsers();

        public User Login(string email, string password);

    }
}
