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

        public Book GetBookByTitle(string title);

        public IList<Book> GetBooks();

        public IList<Book> GetBooksByPublicationDate(DateTime publicationDate);

        public IList<Book> GetBooksByPublisher(string publisher);

        public IList<Book> GetBooksByAuthor(int authorId);

        public IList<Book> GetBooksByCategory(int categoryId);

        public IList<Book> GetBooksByAvailabilityStatus(BookAvailabilityStatus status);

        public IList<Book> GetBooksByAccessibilityStatus(BookAccessibilityStatus status);

        public Book AddBook(Book book);

        public Book UpdateBook(Book book);

        public void RemoveBook(int id);
    }
}
