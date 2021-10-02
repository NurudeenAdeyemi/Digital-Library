using Core.DTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public User GetUser(int id);

        public User GetUserByEmail(string email);

        public IList<User> GetUsers();

        public User AddUser(User user);

        public User UpdateUser(User user);

        public void Delete(int id);

        public bool ExistsAsync(int id);
    }
}
