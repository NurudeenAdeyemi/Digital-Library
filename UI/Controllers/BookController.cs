using Core.DTOs;
using Core.Enums;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class BookController : Controller
    {
        private IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public IActionResult Index()
        {
            var books = _bookService.GetBooks();
            return View(books);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreateBookRequestModel model)
        {
            _bookService.AddBook(model);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var book = _bookService.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        public IActionResult Update( int id, UpdateBookRequestModel model)
        {
            _bookService.UpdateBook(id, model);
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(int id)
        {
            var book = _bookService.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _bookService.RemoveBook(id);
            return RedirectToAction("Index");
        }

       
        public IActionResult Details(int id)
        {
            var book = _bookService.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        public IActionResult GetBookByTitle(string title)
        {

            var book = _bookService.GetBookByTitle(title);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        public IActionResult GetBooksByPublicationDate(DateTime publicationDate)
        {
            var books = _bookService.GetBooksByPublicationDate(publicationDate);
            return View(books);
        }

        public IActionResult GetBooksByPublicationDate(string publisher)
        {
            var books = _bookService.GetBooksByPublisher(publisher);
            return View(books);
        }

        public IActionResult GetBooksByStatus(BookAvailabilityStatus status)
        {
            var books = _bookService.GetBooksByStatus(status);
            return View(books);
        }

        public IActionResult GetBooksByCategory(int categoryId)
        {
            var books = _bookService.GetBooksByCategory(categoryId);
            return View(books);
        }

        public IActionResult GetBooksByAuthor(int authorId)
        {
            var books = _bookService.GetBooksByAuthor(authorId);
            return View(books);
        }
    }
}
