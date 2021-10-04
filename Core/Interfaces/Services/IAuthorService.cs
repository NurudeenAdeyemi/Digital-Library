using Core.DTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IAuthorService
    {
        public AuthorModel GetAuthor(int id);
        public IList<Author> GetAuthors();

        public BaseResponse UpdateAuthor(int id,UpdateAuthorRequestModel model);

        public BaseResponse AddAuthor(CreateAuthorRequestModel model);

        public void DeleteAuthor(int id);
    }
}
