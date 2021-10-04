using Core.DTOs;
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
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public BaseResponse AddAuthor(CreateAuthorRequestModel model)
        {
            var author = new Author
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Biography = model.Biography
            };
            _authorRepository.AddAuthor(author);
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Added"
            };
        }

        public void DeleteAuthor(int id)
        {
            _authorRepository.DeleteAuthor(id);
        }

        public AuthorModel GetAuthor(int id)
        {
            var author = _authorRepository.GetAuthor(id);
            return new AuthorModel
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                Biography = author.Biography
            };
        }

        public IList<Author> GetAuthors()
        {
           return  _authorRepository.GetAuthors();
        }

        public BaseResponse UpdateAuthor(int id, UpdateAuthorRequestModel model)
        {
            var author = _authorRepository.GetAuthor(id);
            author.Biography = model.Biography;
            _authorRepository.UpdateAuthor(author);
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Updated"
            };
        }
    }
}
