using Core.DTOs;
using Core.Enums;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class BookController : Controller
    {
        private IBookService _bookService;
        private IAuthorService _authorService;
        private ICategoryService _categoryService;

        public BookController(IBookService bookService, ICategoryService categoryService, IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var books = _bookService.GetBooks();
            return View(books);
        }

        public IActionResult Add()
        {
            var authors = _authorService.GetAuthors();
            ViewData["Authors"] = new SelectList(authors, "Id", "FirstName");
            var categories = _categoryService.GetCategories();
            ViewData["Categories"] = new SelectList(categories, "Id", "Name");

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

        public IActionResult GetBooksBylabilityAvaiStatus(BookAvailabilityStatus status)
        {
            var books = _bookService.GetBooksByAvailabilityStatus(status);
            return View(books);
        }

        public IActionResult GetBooksByAccessibilityStatus(BookAccessibilityStatus status)
        {
            var books = _bookService.GetBooksByAccessibilityStatus(status);
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
