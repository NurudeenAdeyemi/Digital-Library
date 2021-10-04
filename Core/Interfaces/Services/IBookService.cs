using Core.DTOs;
using Core.Enums;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IBookService
    {
        public BookModel GetBook(int id);

        public BookModel GetBookByTitle(string title);

        public IList<BookModel> GetBooks();

        public IList<Book> GetBooksByPublicationDate(DateTime publicationDate);

        public IList<Book> GetBooksByPublisher(string publisher);

        public IList<Book> GetBooksByAuthor(int authorId);

        public IList<Book> GetBooksByCategory(int categoryId);

        public IList<Book> GetBooksByAvailabilityStatus(BookAvailabilityStatus status);

        public IList<Book> GetBooksByAccessibilityStatus(BookAccessibilityStatus status);

        public BaseResponse AddBook(CreateBookRequestModel model);

        public BaseResponse UpdateBook(int id, UpdateBookRequestModel model);

        public void RemoveBook(int id);
    }
}
