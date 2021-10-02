using Core.Enums;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IBookRepository
    {
        public Book GetBook(int id);

        public Book GetBook(string title);

        public IList<Book> GetBooks();

        public IList<Book> GetBooksByPublicationDate(DateTime publicationDate);

        public IList<Book> GetBooksByPublisher(string publisher);

        public IList<Book> GetBooksByAuthor(string author);

        public IList<Book> GetBooksByCategory(string category);

        public IList<Book> GetBooksByStatus(BookStatus status);

        public Book AddBook(Book book);

        public Book UpdateBook(Book book);

        public void RemoveBook(int id);
    }
}
