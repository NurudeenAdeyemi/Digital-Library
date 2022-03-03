using Core.DTOs;
using Core.Enums;
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
    public class BookService : IBookService   
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
        }
        public BaseResponse AddBook(CreateBookRequestModel model)
        {
            var book = new Book

            {
                ISBN = model.ISBN,
                Language = model.Language,
                BookPDF = model.BookPDF,
                NumberOfPages = model.NumberOfPages,
                BookImage = model.BookImage,
                PublicationDate = model.PublicationDate,
                Publisher = model.Publisher,
                Price = model.Price,
                AvailabilityStatus = model.AvailabilityStatus,
                AccessibilityStatus = model.AccessibilityStatus,
                Subject = model.Subject,              
                Title = model.Title 
                
            };

            var authors = _authorRepository.GetSelectedAuthors(model.Authors);
            foreach (var author in authors)
            {
                var bookAuthor = new BookAuthor
                {
                    Book = book,
                    BookId = book.Id,
                    Author = author,
                    AuthorId = author.Id
                };

                book.BookAuthors.Add(bookAuthor);
            } 

            var categories = _categoryRepository.GetSelectedCategories(model.Categories);
            foreach(var category in categories)
            {
                var bookCategory = new BookCategory
                {
                    Book = book,
                    BookId = book.Id,
                    Category = category,
                    CategoryId = category.Id
                };
                book.BookCategories.Add(bookCategory);
            }

            _bookRepository.AddBook(book);
            return new BaseResponse
            {
                Status = true,
                Message = "Book successfully added"
            };
        }

        public BookModel GetBook(int id)
        { 
            var book = _bookRepository.GetBook(id);

            return new BookModel
            {
                Title = book.Title,
                ISBN = book.ISBN,     
                Subject = book.Subject,
                BookPDF = book.BookPDF,
                Language = book.Language,
                BookImage = book.BookImage,
                NumberOfPages = book.NumberOfPages,
                Price = book.Price,
                AccessibilityStatus = book.AccessibilityStatus,
                AvailabilityStatus = book.AvailabilityStatus,
                Publisher = book.Publisher,
                PublicationDate = book.PublicationDate,
                Authors = book.BookAuthors.Select(a => new AuthorModel()
                {
                    Id = a.AuthorId,
                    FirstName = a.Author.FirstName,
                    LastName = a.Author.LastName,
                    Biography = a.Author.Biography
                }).ToList(),
                BookCategories = book.BookCategories.Select(a => new CategoryModel()
                {
                    Id = a.CategoryId,
                    Name = a.Category.Name,
                }).ToList()
            };
        }

        public BookModel GetBookByTitle(string title)
        {
            var book = _bookRepository.GetBookByTitle(title);

            return new BookModel
            {
                Title = book.Title,
                ISBN = book.ISBN,
                
                Subject = book.Subject,
                BookPDF = book.BookPDF,
                Language = book.Language,
                BookImage = book.BookImage,
                NumberOfPages = book.NumberOfPages,
                Price = book.Price,
                AccessibilityStatus = book.AccessibilityStatus,
                AvailabilityStatus = book.AvailabilityStatus,
                Publisher = book.Publisher,
                PublicationDate = book.PublicationDate,
                Authors = book.BookAuthors.Select(a => new AuthorModel()
                {
                    FirstName = a.Author.FirstName,
                    LastName = a.Author.LastName,
                    Biography = a.Author.Biography
                }).ToList(),
                BookCategories = book.BookCategories.Select(a => new CategoryModel()
                {
                    Id = a.CategoryId,
                    Name = a.Category.Name,
                }).ToList()
            };
        }

        public IList<BookModel> GetBooks()
        {
            var books = _bookRepository.GetBooks().Select(b => new BookModel 
            {
                Id = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                Subject = b.Subject,
                BookPDF = b.BookPDF,
                Language = b.Language,
                BookImage = b.BookImage,
                NumberOfPages = b.NumberOfPages,
                Price = b.Price,
                AccessibilityStatus = b.AccessibilityStatus,
                AvailabilityStatus = b.AvailabilityStatus,
                Publisher = b.Publisher,
                PublicationDate = b.PublicationDate,
                Authors = b.BookAuthors.Select(a => new AuthorModel(){
                    FirstName = a.Author.FirstName,
                    LastName = a.Author.LastName,
                    Biography = a.Author.Biography
                }).ToList(),
                BookCategories = b.BookCategories.Select(a => new CategoryModel()
                {
                    Id = a.CategoryId,
                    Name = a.Category.Name,
                }).ToList()

            }).ToList();

            return books;    
        }

        public IList<Book> GetBooksByAuthor(int authorId)
        {
            return _bookRepository.GetBooksByAuthor(authorId);
        }

        public IList<Book> GetBooksByCategory(int categoryId)
        {
            return _bookRepository.GetBooksByCategory(categoryId);
        }

        public IList<Book> GetBooksByPublicationDate(DateTime publicationDate)
        {
            return _bookRepository.GetBooksByPublicationDate(publicationDate);
        }

        public IList<Book> GetBooksByPublisher(string publisher)
        {
            return _bookRepository.GetBooksByPublisher(publisher);
        }

        public IList<Book> GetBooksByAvailabilityStatus(BookAvailabilityStatus status)
        {
            return _bookRepository.GetBooksByAvailabilityStatus(status);
        }

        public IList<Book> GetBooksByAccessibilityStatus(BookAccessibilityStatus status)
        {
            return _bookRepository.GetBooksByAccessibilityStatus(status);
        }


        public void RemoveBook(int id)
        {
            _bookRepository.RemoveBook(id);
        }

        public BaseResponse UpdateBook(int id, UpdateBookRequestModel model)
        {
            var book = _bookRepository.GetBook(id);

            book.Price = model.Price;
            book.BookImage = model.BookImage;
            book.BookPDF = model.BookPDF;
            book.AccessibilityStatus = model.AccessibilityStatus;
            book.AvailabilityStatus = model.AvailabilityStatus;

            _bookRepository.UpdateBook(book);

            return new BaseResponse
            {
                Status = true,
                Message = "Book updated successfully"
            };
        }
    }
}
