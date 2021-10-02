using Core.DTOs;
using Core.Enums;
using Core.Interfaces.Repositories;
using Core.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected LibraryContext _libraryContext;

        public UserRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        public User AddUser(User user)
        {

            _libraryContext.Users.Add(user);
            _libraryContext.SaveChanges();
            return user;
        }

        public void Delete(int id)
        {
            var user = _libraryContext.Users.SingleOrDefault(u => u.Id == id);
            if (user != null)
            {
                _libraryContext.Users.Remove(user);
                _libraryContext.SaveChanges();
            }
        }

        public bool ExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            return  _libraryContext.Users.SingleOrDefault(u => u.Id == id);
           
        }

        public User GetUserByEmail(string email)
        {
            return _libraryContext.Users.FirstOrDefault(u => u.Email == email);
        }

        public IList<User> GetUsers()
        {
            return _libraryContext.Users.ToList();
        }

        public IList<User> GetUsersByUserType(UserType userType)
        {
            return _libraryContext.Users.Where(u => u.UserType == userType).ToList();
        }

        public User UpdateUser(User user)
        {
            
            _libraryContext.Users.Update(user);
            _libraryContext.SaveChanges();
            return user;
        }
    }
}
