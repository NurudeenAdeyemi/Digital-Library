using Core.Enums;
using Core.Interfaces.Repositories;
using Core.Models;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public Book AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public Book GetBook(int id)
        {
            return _context.Books
                .Include(b => b.BookAuthors)
                .ThenInclude(a => a.Author)
                .Include(bc => bc.BookCategories)
                .ThenInclude(c => c.Category).SingleOrDefault(s => s.Id == id);
        }

        public Book GetBookByTitle(string title)
        {
            return _context.Books
                .Include(b => b.BookAuthors)
                .ThenInclude(a => a.Author)
                .Include(bc => bc.BookCategories)
                .ThenInclude(c => c.Category)
                .FirstOrDefault(b => b.Title == title);
        }

        public IList<Book> GetBooks()
        {
            return _context.Books
                .Include(b => b.BookAuthors)
                .ThenInclude(a => a.Author)
                .Include(bc => bc.BookCategories)
                .ThenInclude(c => c.Category)
                .ToList();
        }

        public IList<Book> GetBooksByAuthor(int authorId)
        {
            return _context.Books
                .Include(b => b.BookAuthors)
                .ThenInclude(a => a.Author)
                .Include(bc => bc.BookCategories)
                .ThenInclude(c => c.Category)
                .Where(b => b.BookAuthors.All(b => b.AuthorId == authorId)).ToList();

        }

        public IList<Book> GetBooksByCategory(int categoryId)
        {
            return _context.Books
                .Include(bc => bc.BookCategories)
                .ThenInclude(c => c.Category)
                .Include(ba => ba.BookAuthors)
                .ThenInclude(a => a.Author)
                .Where(b => b.BookCategories.All(a => a.CategoryId == categoryId)).ToList();
        }

        public IList<Book> GetBooksByPublicationDate(DateTime publicationDate)
        {
            return _context.Books
                .Include(bc => bc.BookCategories)
                .ThenInclude(c => c.Category)
                .Include(ba => ba.BookAuthors)
                .ThenInclude(a => a.Author)
                .Where(b => b.PublicationDate == publicationDate).ToList();
        }

        public IList<Book> GetBooksByPublisher(string publisher)
        {
            return _context.Books
                .Include(bc => bc.BookCategories)
                .ThenInclude(c => c.Category)
                .Include(ba => ba.BookAuthors)
                .ThenInclude(a => a.Author)
                .Where(b => b.Publisher == publisher).ToList();
        }

        public IList<Book> GetBooksByAvailabilityStatus(BookAvailabilityStatus status)
        {
            return _context.Books
                .Include(bc => bc.BookCategories)
                .ThenInclude(c => c.Category)
                .Include(ba => ba.BookAuthors)
                .ThenInclude(a => a.Author)
                .Where(b => b.AvailabilityStatus == status).ToList();
        }

        public IList<Book> GetBooksByAccessibilityStatus(BookAccessibilityStatus status)
        {
            return _context.Books
                .Include(bc => bc.BookCategories)
                .ThenInclude(c => c.Category)
                .Include(ba => ba.BookAuthors)
                .ThenInclude(a => a.Author)
                .Where(b => b.AccessibilityStatus == status).ToList();
        }

        public void RemoveBook(int id)
        {
            var book = GetBook(id);

            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public Book UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
            return book;
        }
    }
}
