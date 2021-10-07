using Core.DTOs;
using Core.Enums;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class BookController : Controller
    {
        private  readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public BookController(IBookService bookService, ICategoryService categoryService, IAuthorService authorService, IWebHostEnvironment webHostEnvironment)
        {
            _bookService = bookService;
            _authorService = authorService;
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
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
        public IActionResult Add(CreateBookRequestModel model, IFormFile file, IFormFile pdf)
        {
            if(file != null)
            {
                string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "bookImages");
                Directory.CreateDirectory(imageDirectory);
                string contentType = file.ContentType.Split('/')[1];
                string bookImage = $"{Guid.NewGuid()}.{contentType}";
                string fullPath = Path.Combine(imageDirectory, bookImage);
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                model.BookImage = bookImage;
            }
            if (pdf != null)
            {
                string pdfDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "bookPDFs");
                Directory.CreateDirectory(pdfDirectory);
                string contentType = pdf.ContentType.Split('/')[1];
                string bookPDF = $"{Guid.NewGuid()}.{contentType}";
                string fullPath = Path.Combine(pdfDirectory, bookPDF);
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    pdf.CopyTo(fileStream);
                }
                model.BookPDF = bookPDF;
            }

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
