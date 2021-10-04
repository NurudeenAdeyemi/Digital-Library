using Core.DTOs;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public IActionResult Index()
        {
            var author = _authorService.GetAuthors();
            return View(author);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateAuthorRequestModel model)
        {
            _authorService.AddAuthor(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var author = _authorService.GetAuthor(id);
            return View(author);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var author = _authorService.GetAuthor(id);
            if (author == null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Update(int id, UpdateAuthorRequestModel model)
        {
            _authorService.UpdateAuthor(id, model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var author = _authorService.GetAuthor(id);
            if(author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost , ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _authorService.DeleteAuthor(id);
            return RedirectToAction("Index");
        }
    }
}
