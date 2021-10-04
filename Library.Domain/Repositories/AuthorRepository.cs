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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext _libraryContext;

        public AuthorRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public Author GetAuthor(int id)
        {
            return _libraryContext.Authors.SingleOrDefault(a => a.Id == id);
        }

        public Author AddAuthor(Author author)
        {
            _libraryContext.Authors.Add(author);
            _libraryContext.SaveChanges();
            return author;
        }

        public void DeleteAuthor(int id)
        {
            var author = _libraryContext.Authors.SingleOrDefault(a => a.Id == id);
            if(author != null)
            {
                _libraryContext.Authors.Remove(author);
                _libraryContext.SaveChanges();
            }
        }

        public IList<Author> GetAuthors()
        {
            return _libraryContext.Authors.ToList();
        }

        public Author UpdateAuthor(Author author)
        {
            _libraryContext.Authors.Update(author);
            _libraryContext.SaveChanges();
            return author;
        }
    }
}
