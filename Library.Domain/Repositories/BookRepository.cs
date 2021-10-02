using Core.Enums;
using Core.Interfaces.Repositories;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Repositories
{
    public class BookRepository : IBookRepository
    {
        public Book AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public Book GetBook(int id)
        {
            throw new NotImplementedException();
        }

        public Book GetBook(string title)
        {
            throw new NotImplementedException();
        }

        public IList<Book> GetBooks()
        {
            throw new NotImplementedException();
        }

        public IList<Book> GetBooksByAuthor(string author)
        {
            throw new NotImplementedException();
        }

        public IList<Book> GetBooksByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public IList<Book> GetBooksByPublicationDate(DateTime publicationDate)
        {
            throw new NotImplementedException();
        }

        public IList<Book> GetBooksByPublisher(string publisher)
        {
            throw new NotImplementedException();
        }

        public IList<Book> GetBooksByStatus(BookStatus status)
        {
            throw new NotImplementedException();
        }

        public void RemoveBook(int id)
        {
            throw new NotImplementedException();
        }

        public Book UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
